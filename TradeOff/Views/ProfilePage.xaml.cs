using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class ProfilePage : ContentPage
{
    ProfileServices _profileServices;
    public ProfilePage()
    {
        _profileServices = new ProfileServices();
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await GetDataAsync();
        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.GetProfile());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                if (string.IsNullOrEmpty(response.Data.ProfilePicUrl))
                    response.Data.ProfilePicUrl = "user_profile.png";
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

    private async void btnLogout_Clicked(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnHistory_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(HistoryPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
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