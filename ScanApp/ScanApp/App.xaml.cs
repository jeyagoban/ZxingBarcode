using CommunityToolkit.Maui.Views;
using ScanApp.ViewModels;
using ScanApp.Views;

namespace ScanApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    public static void ShowScanPopup(ScanPopupViewModel viewModel)
    {
        var scanPopup = new ScanPopup(viewModel);
        Application.Current.MainPage.ShowPopup(scanPopup);
        viewModel.IsOpened = true;
    }
}
