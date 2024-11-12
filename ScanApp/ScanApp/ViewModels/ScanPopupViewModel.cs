using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;

namespace ScanApp.ViewModels
{
    public partial class ScanPopupViewModel : ObservableObject
    {
        //[ObservableProperty]
        //private string _scannedCode;

        //[ObservableProperty]
        //private string _propertyName;

        //public ScanViewModel() { }

        //public void HandleBarcodesDetected(IEnumerable<BarcodeResult> barcodes)
        //{
        //    if (barcodes != null && barcodes.Any())
        //    {
        //        ScannedCode = barcodes.First().Value;
        //    }
        //}

        [ObservableProperty]
        private bool _isOpened;

        private Guid _token;

        public ScanPopupViewModel(Guid token)
        {
            _token = token;
        }

        public void OnScanCompleted(IEnumerable<BarcodeResult> barcodes)
        {
            if (barcodes != null && barcodes.Any())
            {
                WeakReferenceMessenger.Default.Send(new ScanResultMessage($"{barcodes.First().Value}", _token));
            }
        }
    }
}
