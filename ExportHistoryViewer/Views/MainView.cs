using DevExpress.XtraEditors;
using ExportHistoryViewer.Configuration;
using Microsoft.VisualStudio.Threading;
using Serilog;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ExportHistoryViewer.Views
{
    public partial class MainView : XtraForm, IMainView
    {
        private bool _isSuccessfull;
        private string _message;
        private List<string> _locations;
        private int _skip;
        private int _take = 100;
        private int _totalCount;

        public event AsyncEventHandler SearchEventAsync;
        public event AsyncEventHandler SeedEventAsync;
        public event AsyncEventHandler OnLoad;
        public event EventHandler ClearEvent;
        public event EventHandler PaginationIncrease;
        public event EventHandler PaginationDecrease;

        public DateTime? StartDate { get => dateEditStartDate.EditValue as DateTime?; set => dateEditStartDate.EditValue = value; }
        public DateTime? EndDate { get => dateEditEndDate.EditValue as DateTime?; set => dateEditEndDate.EditValue = value; }
        public new string Location { get => comboBoxEditLocation.Text; set => comboBoxEditLocation.Text = value; }
        public bool IsSuccessfull { get => _isSuccessfull; set => _isSuccessfull = value; }
        public string Message { get => _message; set => _message = value; }
        public List<string> Locations
        {
            get => _locations;
            set
            {
                _locations = value;
                SetLocations(_locations);
            }
        }
        public int Skip
        {
            get => _skip; set
            {
                _skip = value;
                UpdatePaginationButtons();
            }
        }
        public int Take { get => _take; set => _take = value; }
        public int TotalCount { get => _totalCount; set => _totalCount = value; }

        public MainView()
        {
            InitializeComponent();
            AssociateAndRiseViewEvents();
        }

        private async void AssociateAndRiseViewEvents()
        {
            this.Load += async (s, e) =>
            {
                await OnLoad?.Invoke(this, e);
                if (IsSuccessfull)
                {
                    TryRestoreLayoutFromRegistry();
                }
            };
            simpleButtonSeedData.Click += async (s, e) =>
            {
                await SeedEventAsync.InvokeAsync(this, EventArgs.Empty);
                if (!IsSuccessfull)
                {
                    XtraMessageBox.Show(_message);
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            simpleButtonSubmit.Click += async (s, e) =>
            {
                await SearchEventAsync.InvokeAsync(this, EventArgs.Empty);
                if (!IsSuccessfull)
                {
                    XtraMessageBox.Show(_message);
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    labelControlPagination.Visible = true;
                }
            };

            simpleButtonNext.Click += async (s, e) =>
            {
                PaginationIncrease.Invoke(this, EventArgs.Empty);
                await SearchEventAsync?.InvokeAsync(this, EventArgs.Empty);
                if (!IsSuccessfull)
                {
                    XtraMessageBox.Show(_message);
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    labelControlPagination.Visible = true;
                }
            };

            simpleButtonPrevious.Click += async (s, e) =>
            {
                PaginationDecrease.Invoke(this, EventArgs.Empty);
                await SearchEventAsync?.InvokeAsync(this, EventArgs.Empty);
                if (!IsSuccessfull)
                {
                    XtraMessageBox.Show(_message);
                    ClearEvent?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    labelControlPagination.Visible = true;
                }
            };
        }

        public void SetExportHistories(BindingSource exportHistories)
        {
            gridControlExportHistory.DataSource = exportHistories;
        }

        public void SetLocations(List<string> locations)
        {
            comboBoxEditLocation.Properties.Items.Clear();
            comboBoxEditLocation.Properties.Items.AddRange(locations);
        }
        private void UpdatePaginationButtons()
        {
            if (_skip == 0)
            {
                simpleButtonPrevious.Enabled = false;
            }
            else
            {
                simpleButtonPrevious.Enabled = true;
            }
            if (Skip + Take >= _totalCount)
            {
                simpleButtonNext.Enabled = false;
            }
            else
            {
                simpleButtonNext.Enabled = true;
            }
        }

        public void SetPagination()
        {
            labelControlPagination.Text =
                $"{Skip + 1}-{Skip + Take}/ {_totalCount}";
            UpdatePaginationButtons();
        }

        public void SaveLayoutToRegistry()
        {
            gridView1.SaveLayoutToRegistry(LayoutConfigurationHelper.GetLayoutRegKey(nameof(gridView1)));
        }

        public void TryRestoreLayoutFromRegistry()
        {
            try
            {
                gridView1.RestoreLayoutFromRegistry(LayoutConfigurationHelper.GetLayoutRegKey(nameof(gridView1)));
            }
            catch (Exception ex)
            {
                Log.Error($"Could not restore Layouts from Registry. {ex.Message}");
            }
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLayoutToRegistry();
        }
    }
}