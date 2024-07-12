using Serilog;
using System.Data.SqlClient;

namespace ExportHistoryLib.Common.ErrorHandling
{
    public class ErrorHandler : IErrorHandler
    {
        public T Handle<T>(Func<T> request)
        {
            T result = default(T);
            try
            {
                result = request.Invoke();
            }
            catch (SqlException ex)
            {
                Log.Error(ex, "Błąd SQL podczas operacji SomeOperation");
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Błąd HTTP podczas komunikacji z Allegro API");
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, "Błąd IO podczas próby odczytania pliku");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Wystąpił nieoczekiwany błąd");
            }
            finally
            {
                Log.Information("Application is Closing");
                Log.CloseAndFlush();
            }
            return result;
        }

        public Either<IError, T> Handle<T>(Func<Either<IError, T>> request)
        {
            Either<IError, T> result = default;
            try
            {
                result = request.Invoke();
            }
            catch (SqlException ex)
            {
                Log.Error(ex, "Błąd SQL podczas operacji SomeOperation");
                result = Either<IError, T>.Error(new Error(ex.Message));
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Błąd HTTP podczas komunikacji z Allegro API");
                result = Either<IError, T>.Error(new Error(ex.Message));
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, "Błąd IO podczas próby odczytania pliku");
                result = Either<IError, T>.Error(new Error(ex.Message));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Wystąpił nieoczekiwany błąd");
                result = Either<IError, T>.Error(new Error(ex.Message));
            }
            finally
            {
                Log.Information("Application is Closing");
                Log.CloseAndFlush();
            }
            return result;
        }

        public async Task HandleAsync(Func<Task> request)
        {
            try
            {
                await request.Invoke();
            }
            catch (SqlException ex)
            {
                Log.Error(ex, "Błąd SQL podczas operacji SomeOperation");
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Błąd HTTP podczas komunikacji z Allegro API");
                if (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Log.Error("Upewnij się że posiadasz ważny Token");
                }
            }
            catch (FileNotFoundException ex)
            {
                Log.Error(ex, "Błąd IO podczas próby odczytania pliku");
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, "Wystąpił nieoczekiwany błąd");
                if (ex.Source == "System.Data.SqlClient")
                {
                    Log.Error("Upewnij się ze ConnectionString jest poprawny.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Wystąpił nieoczekiwany błąd");
            }
            finally
            {
                Log.Information("Application is Closing");
                Log.CloseAndFlush();
            }
        }
    }
}
