﻿using DevExpress.Mvvm.Native;
using DevExpress.XtraSplashScreen;
using ExportHistoryLib.Application.Services.Interfaces;
using ExportHistoryLib.Infrastructure.Filters;
using ExportHistoryLib.Models;
using ExportHistoryViewer.Converters;
using ExportHistoryViewer.ViewModels;
using ExportHistoryViewer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
            _view.SeedEventAsync += SeedExportHistory;
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
            var locations = await _service.GetLocations();
            _view.SetLocations(locations);
        }

        private void Clear(object sender, EventArgs e)
        {
            _view.IsSuccessfull = true;
            _view.Message = string.Empty;
        }

        private async Task SeedExportHistory(object sender, EventArgs args)
        {
            try
            {
                await _seedService.SeedExportHistoryData(1000);
            }
            catch (Exception ex)
            {
                _view.IsSuccessfull = false;
                _view.Message = ex.Message;
            }
        }

        private async Task SearchExportHistoryAsync(object sender, EventArgs args)
        {
            SplashScreenManager.ShowForm(typeof(HistoryWaitForm), true, true); 
            await GetExports();
            SplashScreenManager.CloseForm();
        }

        private async Task GetExports()
        {
           
            try
            {
                var exports = await _service.GetExportHistories(_view.StartDate, _view.EndDate, _view.Location, GetPagination());
                var exportView = exports.Items.Select(e => e.ToExportHistoryVm());
                _exportHistoryBinding.DataSource = exportView;
                _view.TotalCount = exports.TotalCount;

                _view.SetPagination();
            }
            catch (Exception ex)
            {
                _view.IsSuccessfull = false;
                _view.Message = ex.Message;
            }
        }

        private async Task GetLocations(object sender, EventArgs args)
        {
            _view.SetLocations(await _service.GetLocations());
        }

        private Pagination GetPagination()
        {
            var builder = new Pagination.Builder();
            builder.SetTake(_view.Take);
            builder.SetSkip(_view.Skip);

            return builder.Build();
        }

    }
}
