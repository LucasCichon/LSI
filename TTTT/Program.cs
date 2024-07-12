using DevExpress.XtraEditors;
using ExportHistoryLib.Application.Services;
using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Common.ErrorHandling;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Infrastructure.Repositories;
using ExportHistoryViewer.Configuration;
using ExportHistoryViewer.Presenters;
using ExportHistoryViewer.Views;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace TTTT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppConfiguration.ConfigureLogger();
            Log.Information("Application Starting Up");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                var service = serviceProvider.GetRequiredService<IExportHistoryService>();
                var seedService = serviceProvider.GetRequiredService<ISeedDataService>();

                IMainView view = new MainView();
                var presenter = new ExportHistoryPresenter(view, service, seedService);

                
                Application.Run((XtraForm)view);
            }
            Log.Information("Application is Closing");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ExportHistoryDB"].ConnectionString;

            services.AddTransient<IErrorHandler, ErrorHandler>();
            services.AddSingleton<IExportHistoryRepository>(new ExportHistoryRepository(connectionString));
            services.AddSingleton<ISeedDataRepository>(new SeedDataRepository(connectionString));
            services.AddTransient<IExportHistoryService, ExportHistoryService>();
            services.AddTransient<ISeedDataService, SeedDataService>();
            services.AddSingleton<IMainView, MainView>();
            services.AddSingleton<ExportHistoryPresenter>();
        }
    }
}