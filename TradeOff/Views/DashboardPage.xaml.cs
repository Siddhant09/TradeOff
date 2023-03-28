using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class DashboardPage : ContentPage
{
    DashboardServices _dashboardServices;
    public DashboardPage()
    {
        _dashboardServices = new DashboardServices();
        InitializeComponent();
        ddlDateRange.SelectedIndex = 0;
        GetDataAsync();
    }

    //protected override async void OnAppearing()
    //{
    //    await GetDataAsync();
    //    base.OnAppearing();
    //}

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<Dashboard>> task = new Task<Response<Dashboard>>(() => _dashboardServices.GetDashboard(1));
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
                this.BindingContext = response.Data;
            else
            {
                var toast = Toast.Make(response.Message);
                await toast.Show();
            }
        }
        else
        {
            actInd.IsRunning = actInd.IsVisible = false;
            var toast = Toast.Make("Something went wrong, please try again");
            await toast.Show();
        }
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