using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class DashboardPage : ContentPage
{
    Dashboard _dashboard;
    public DashboardPage()
	{
        _dashboard = new Dashboard();
		InitializeComponent();
        ddlDateRange.SelectedIndex = 0;
        Dashboard dash = _dashboard.GetDashboard();
        this.BindingContext = dash;
    }

    private async void btnNotification_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(NotificationsPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}