using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class NotificationsPage : ContentPage
{
    ProfileServices _profileServices;
    public NotificationsPage()
    {
        _profileServices = new ProfileServices();
        InitializeComponent();
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
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.GetNotifications());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                this.BindingContext = response.Data;
            }
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

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await DisplayAlert("Delete All Notifications", "Are you sure?", "Yes", "No"))
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.DeleteNotifications());
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
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}