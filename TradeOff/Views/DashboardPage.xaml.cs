using TradeOff.Models;

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
}