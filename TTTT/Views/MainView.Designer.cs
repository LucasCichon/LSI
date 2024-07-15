namespace ExportHistoryViewer.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            dateEditStartDate = new DevExpress.XtraEditors.DateEdit();
            dateEditEndDate = new DevExpress.XtraEditors.DateEdit();
            comboBoxEditLocation = new DevExpress.XtraEditors.ComboBoxEdit();
            gridControlExportHistory = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            simpleButtonSubmit = new DevExpress.XtraEditors.SimpleButton();
            simpleButtonSeedData = new DevExpress.XtraEditors.SimpleButton();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            simpleButtonNext = new DevExpress.XtraEditors.SimpleButton();
            simpleButtonPrevious = new DevExpress.XtraEditors.SimpleButton();
            labelControlPagination = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditLocation.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControlExportHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            SuspendLayout();
            // 
            // dateEditStartDate
            // 
            dateEditStartDate.EditValue = null;
            dateEditStartDate.Location = new System.Drawing.Point(29, 108);
            dateEditStartDate.Name = "dateEditStartDate";
            dateEditStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditStartDate.Properties.NullValuePrompt = "Od:";
            dateEditStartDate.Size = new System.Drawing.Size(225, 26);
            dateEditStartDate.TabIndex = 0;
            // 
            // dateEditEndDate
            // 
            dateEditEndDate.EditValue = null;
            dateEditEndDate.Location = new System.Drawing.Point(29, 156);
            dateEditEndDate.Name = "dateEditEndDate";
            dateEditEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditEndDate.Properties.NullValuePrompt = "Do:";
            dateEditEndDate.Size = new System.Drawing.Size(225, 26);
            dateEditEndDate.TabIndex = 0;
            // 
            // comboBoxEditLocation
            // 
            comboBoxEditLocation.Location = new System.Drawing.Point(29, 61);
            comboBoxEditLocation.Name = "comboBoxEditLocation";
            comboBoxEditLocation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            comboBoxEditLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            comboBoxEditLocation.Properties.NullValuePrompt = "Lokal:";
            comboBoxEditLocation.Size = new System.Drawing.Size(225, 26);
            comboBoxEditLocation.TabIndex = 1;
            // 
            // gridControlExportHistory
            // 
            gridControlExportHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gridControlExportHistory.Location = new System.Drawing.Point(305, 0);
            gridControlExportHistory.MainView = gridView1;
            gridControlExportHistory.Name = "gridControlExportHistory";
            gridControlExportHistory.Size = new System.Drawing.Size(856, 796);
            gridControlExportHistory.TabIndex = 2;
            gridControlExportHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControlExportHistory;
            gridView1.Name = "gridView1";
            // 
            // simpleButtonSubmit
            // 
            simpleButtonSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            simpleButtonSubmit.Location = new System.Drawing.Point(29, 716);
            simpleButtonSubmit.Name = "simpleButtonSubmit";
            simpleButtonSubmit.Size = new System.Drawing.Size(225, 51);
            simpleButtonSubmit.TabIndex = 3;
            simpleButtonSubmit.Text = "Zatwierdź";
            // 
            // simpleButtonSeedData
            // 
            simpleButtonSeedData.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            simpleButtonSeedData.Location = new System.Drawing.Point(29, 638);
            simpleButtonSeedData.Name = "simpleButtonSeedData";
            simpleButtonSeedData.Size = new System.Drawing.Size(225, 51);
            simpleButtonSeedData.TabIndex = 3;
            simpleButtonSeedData.Text = "Wypełnij testowymi danymi";
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(simpleButtonNext);
            panelControl1.Controls.Add(simpleButtonPrevious);
            panelControl1.Controls.Add(labelControlPagination);
            panelControl1.Controls.Add(comboBoxEditLocation);
            panelControl1.Controls.Add(simpleButtonSeedData);
            panelControl1.Controls.Add(dateEditStartDate);
            panelControl1.Controls.Add(simpleButtonSubmit);
            panelControl1.Controls.Add(dateEditEndDate);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(299, 796);
            panelControl1.TabIndex = 4;
            // 
            // simpleButtonNext
            // 
            simpleButtonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            simpleButtonNext.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            simpleButtonNext.Appearance.Options.UseBackColor = true;
            simpleButtonNext.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            simpleButtonNext.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonNext.ImageOptions.SvgImage");
            simpleButtonNext.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            simpleButtonNext.Location = new System.Drawing.Point(172, 482);
            simpleButtonNext.Name = "simpleButtonNext";
            simpleButtonNext.Size = new System.Drawing.Size(82, 65);
            simpleButtonNext.TabIndex = 5;
            // 
            // simpleButtonPrevious
            // 
            simpleButtonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            simpleButtonPrevious.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            simpleButtonPrevious.Appearance.Options.UseBackColor = true;
            simpleButtonPrevious.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            simpleButtonPrevious.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButtonPrevious.ImageOptions.SvgImage");
            simpleButtonPrevious.ImageOptions.SvgImageSize = new System.Drawing.Size(35, 35);
            simpleButtonPrevious.Location = new System.Drawing.Point(29, 482);
            simpleButtonPrevious.Name = "simpleButtonPrevious";
            simpleButtonPrevious.Size = new System.Drawing.Size(83, 65);
            simpleButtonPrevious.TabIndex = 5;
            // 
            // labelControlPagination
            // 
            labelControlPagination.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            labelControlPagination.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            labelControlPagination.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            labelControlPagination.Appearance.Options.UseFont = true;
            labelControlPagination.Appearance.Options.UseForeColor = true;
            labelControlPagination.Location = new System.Drawing.Point(78, 578);
            labelControlPagination.Name = "labelControlPagination";
            labelControlPagination.Size = new System.Drawing.Size(60, 24);
            labelControlPagination.TabIndex = 4;
            labelControlPagination.Text = "0-0/0";
            labelControlPagination.Visible = false;
            // 
            // MainView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1163, 796);
            Controls.Add(panelControl1);
            Controls.Add(gridControlExportHistory);
            MinimumSize = new System.Drawing.Size(847, 605);
            Name = "MainView";
            Text = "Raport";
            FormClosing += MainView_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditStartDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditEndDate.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)comboBoxEditLocation.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControlExportHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEditStartDate;
        private DevExpress.XtraEditors.DateEdit dateEditEndDate;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLocation;
        private DevExpress.XtraGrid.GridControl gridControlExportHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSubmit;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSeedData;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNext;
        private DevExpress.XtraEditors.SimpleButton simpleButtonPrevious;
        private DevExpress.XtraEditors.LabelControl labelControlPagination;
    }
}