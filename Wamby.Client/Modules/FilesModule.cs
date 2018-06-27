﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Wamby.Client.Modules
{
    public partial class FilesModule : DevExpress.XtraEditors.XtraUserControl, 
        Interfaces.IModule, Interfaces.IModulePrintAndExport, Interfaces.IModuleFiles
    {
        [Browsable(false)]
        public API.Services.FileSystemScanService FileSystemScanService { get; private set; }
        public bool Initialized { get; private set; }

        public FilesModule()
        {
            InitializeComponent();
        }

        public void InitializeControl(API.Services.FileSystemScanService scanService)
        {
            FileSystemScanService = scanService;
            Initialized = true;
            setEventHandlers();
        }

        private void setEventHandlers()
        {
            
        }

        public void RefreshModuleData()
        {
            resultsBindingSource.DataSource = FileSystemScanService.ScanResult.WambyFolderInfo.AllFiles;
        }

        public void Print()
        {
            gridControlFiles.ShowRibbonPrintPreview();
        }

        public void ExportToXls()
        {
            var filename = FileSystemScanService.GetTempFileName("xlsx");
            gridControlFiles.ExportToXlsx(filename);
            System.Diagnostics.Process.Start(filename);
        }

        public void ExportToPdf()
        {
            var filename = FileSystemScanService.GetTempFileName("pdf");
            gridControlFiles.ExportToPdf(filename);
            System.Diagnostics.Process.Start(filename);
        }

    }
}