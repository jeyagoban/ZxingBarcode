using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanApp.ViewModels
{
    public partial class ScanTextViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _scanText;

        private readonly Guid _token = Guid.NewGuid();

        public ScanTextViewModel()
        {

            WeakReferenceMessenger.Default.Register<ScanResultMessage>(this, (recipient, message) =>
            {
                if (message.Token == _token)
                    ScanText = message.ScannedData;
            });
        }

        [RelayCommand]
        private void Scan()
        {
            ScanPopupViewModel scanViewModel = new ScanPopupViewModel(_token);
            App.ShowScanPopup(scanViewModel);
        }
    }
}
