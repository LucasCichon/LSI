using DevExpress.Mvvm.Native;
using DevExpress.XtraSplashScreen;
using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Common;
using ExportHistoryLib.Common.Error;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryViewer.Converters;
using ExportHistoryViewer.ViewModels;
using ExportHistoryViewer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportHistoryViewer.Presenters
{
    public class ExportHistoryPresenter
    {
        private readonly IMainView _view;
        private readonly IExportHistoryService _service;
        private readonly ISeedDataService _seedService;

        private BindingSource _exportHistoryBinding = new BindingSource();
        private List<string> _locations = new List<string>();

        public ExportHistoryPresenter(IMainView view, IExportHistoryService service, ISeedDataService seedService)
        {
            _exportHistoryBinding.DataSource = new List<ExportHistoryVm>();
            _view = view;
            _service = service;
            _seedService = seedService;

            _view.IsSuccessfull = true;
            _view.Message = string.Empty;

            _view.SearchEventAsync += SearchExportHistoryAsync;
            _view.ClearEvent += Clear;
            _view.SeedEventAsync += SeedExportHistoryAsync;
            _view.OnLoad += OnLoad;
            _view.PaginationIncrease += PaginationIncrease;
            _view.PaginationDecrease += PaginationDecrease;

            _view.SetExportHistories(_exportHistoryBinding);
        }

        private void PaginationDecrease(object sender, EventArgs e)
        {
            if (_view.Take <= _view.Skip) {
                _view.Skip -= _view.Take;
            }
            else
            {
                _view.Skip = 0;
            }
        }

        private void PaginationIncrease(object sender, EventArgs e)
        {
            _view.Skip += _view.Take;
        }

        private async Task OnLoad(object sender, EventArgs e)
        {
            await GetLocationsAsync();
        }

        private void Clear(object sender, EventArgs e)
        {
            _view.IsSuccessfull = true;
            _view.Message = string.Empty;
        }

        private async Task SeedExportHistoryAsync(object sender, EventArgs args)
        {
            SplashScreenManager.ShowSkinSplashScreen(title: "Czekaj", subtitle: "Trwa zapełnianie testowymi danymi");
            var test = await _seedService.SeedExportHistoryDataAsync(1000);
            await test.Match(HandleDbErrorAsync
            ,() => Task.CompletedTask);
            await GetLocationsAsync();

            SplashScreenManager.CloseForm();
        }

        private async Task SearchExportHistoryAsync(object sender, EventArgs args)
        {
            SplashScreenManager.ShowSkinSplashScreen(title: "Czekaj", subtitle: "Trwa pobieranie historii");
            await GetExportsAsync();
            SplashScreenManager.CloseForm();
        }

        private async Task GetExportsAsync()
        {
            var exports = await _service.GetExportHistoriesAsync(_view.StartDate, _view.EndDate, _view.Location, GetPagination());
            await exports.Match(async success =>
            {
                var exportView = success.Items.Select(e => e.ToExportHistoryVm());
                _exportHistoryBinding.DataSource = exportView;
                _view.TotalCount = success.TotalCount;
                _view.SetPagination();
                CheckResult();
            },
            HandleDbErrorAsync);
        }

        private void CheckResult()
        {
            if(_view.TotalCount == 0) 
            {
                MessageBox.Show($"Tabela '{ServiceConstants.ExportHistoryTableName}' jest pusta. Wypełnij tabelę danymi za pomocą przycisku 'Wypełnij testowymi danymi'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task GetLocationsAsync()
        {
            var locations = await _service.GetLocationsAsync();

            locations.Match(_view.SetLocations
            ,async error =>
            {
                if (error.Type == ErrorType.DbError_TableNotExists)
                {
                    await CreateExportHistoryTableAsync();
                }
                else
                {
                    _view.IsSuccessfull = false;
                    _view.Message = error.Message;
                }
            });
        }

        private PaginationFilter GetPagination()
        {
            var builder = new PaginationFilter.Builder();
            builder.SetTake(_view.Take);
            builder.SetSkip(_view.Skip);

            return builder.Build();
        }

        private async Task HandleDbErrorAsync(IError error)
        {
            if (error.Type == ErrorType.DbError_TableNotExists)
            {
                await CreateExportHistoryTableAsync();
            }
            else
            {
                _view.IsSuccessfull = false;
                _view.Message = error.Message;
            }
        }
        private async Task CreateExportHistoryTableAsync()
        {
            DialogResult dr = MessageBox.Show($"Tabela '{ServiceConstants.ExportHistoryTableName}' nie istnieje w bazie. Czy chcesz utworzyć tabelę?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                await _service.CreateExportHistoryTableIfNotExistsAsync();
            }
        }
    }
}
