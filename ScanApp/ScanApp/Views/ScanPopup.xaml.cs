using CommunityToolkit.Maui.Views;
using ZXing.Net.Maui.Controls;
using ZXing.Net.Maui;
using ScanApp.ViewModels;

namespace ScanApp.Views;

public partial class ScanPopup : Popup
{
	public ScanPopup(ScanPopupViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

        cameraBarcodeReaderView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true,
        };
    }

    private void cameraBarcodeReaderView_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
    {
        try
        {
            Dispatcher.Dispatch((Action)(() =>
            {
                var viewModel = (ScanPopupViewModel)BindingContext;
                viewModel?.OnScanCompleted(e.Results);

                if (viewModel.IsOpened)
                {
                    Close();
                    viewModel.IsOpened = false;
                }
            }));
        }
        catch { }

    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}