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
        //GetDataAsync();
    }

    protected override async void OnAppearing()
    {
        await GetDataAsync();
        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        int filter = ddlDateRange.SelectedIndex == 0 ? 1 : (ddlDateRange.SelectedIndex == 1 ? 2 : 3);
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<Dashboard>> task = new Task<Response<Dashboard>>(() => _dashboardServices.GetDashboard(filter));
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

    private async void btnMore_Clicked(object sender, EventArgs e)
    {
        try
        {
            string action = await DisplayActionSheet("More", "Cancel", "Logout", "Inbox", "Manage Availability", "View History", "Settings");
            if (action == "Manage Availability")
                await Shell.Current.GoToAsync($"{nameof(TimeSlotsPage)}", true);
            else if (action == "View History")
                await Shell.Current.GoToAsync($"{nameof(HistoryPage)}", true);
            else if (action == "Settings")
                await Shell.Current.GoToAsync($"{nameof(SettingsPage)}", true);
            else if (action == "Inbox")
                await Shell.Current.GoToAsync($"{nameof(InboxPage)}", true);
            else if (action == "Logout")
            {
                bool confirm = await DisplayAlert("Logout", "Are you sure?", "Yes", "No");
                if (confirm)
                {
                    Preferences.Default.Set("userId", string.Empty);
                    Preferences.Default.Set("userName", string.Empty);
                    Preferences.Default.Set("authToken", string.Empty);
                    await Shell.Current.GoToAsync($"//{nameof(SignInPage)}", true);
                }
            }
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private void ddlDateRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataAsync();
    }
}