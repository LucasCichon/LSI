using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportHistoryLib.Common.ErrorHandling
{
    public interface IErrorHandler
    {
        //T Handle<T>(Func<T> request);
        Either<IError, T> Handle<T>(Func<Either<IError, T>> request);
        Task HandleAsync(Func<Task> request);
    }
}
