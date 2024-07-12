using DevExpress.XtraEditors;
using ExportHistoryLib.Application.Services;
using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Infrastructure.Interfaces;
using ExportHistoryLib.Infrastructure.Repositories;
using ExportHistoryViewer.Presenters;
using ExportHistoryViewer.Views;
using Microsoft.Extensions.DependencyInjection;
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
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ExportHistoryDB"].ConnectionString;

            services.AddSingleton<IExportHistoryRepository>(new ExportHistoryRepository(connectionString));
            services.AddSingleton<ISeedDataRepository>(new SeedDataRepository(connectionString));
            services.AddSingleton<IExportHistoryService, ExportHistoryService>();
            services.AddSingleton<ISeedDataService, SeedDataService>();
            services.AddSingleton<IMainView, MainView>();
            services.AddSingleton<ExportHistoryPresenter>();
            services.AddSingleton<MainView>();
        }
    }
}