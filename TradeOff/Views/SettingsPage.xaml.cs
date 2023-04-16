using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class SettingsPage : ContentPage
{
    ProfileServices _profileServices;
    public SettingsPage()
	{
        _profileServices = new ProfileServices();

        InitializeComponent();

        GetDataAsync();
        if (Application.Current.UserAppTheme == AppTheme.Dark)
            ddlTheme.SelectedIndex = 0;
        else if (Application.Current.UserAppTheme == AppTheme.Light)
            ddlTheme.SelectedIndex = 1;
    }
    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.GetSettings());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                btnPush.IsToggled = Convert.ToBoolean(response.Data.PushNotification);
                btnEmail.IsToggled = Convert.ToBoolean(response.Data.EmailNotification);
                ddlTheme.SelectedIndex = response.Data.IsDarkTheme == true ? 0 : 1;
                //this.BindingContext = response.Data;
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

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            User profile = new User();
            profile.PushNotification = btnPush.IsToggled;
            profile.EmailNotification = btnEmail.IsToggled;
            profile.IsDarkTheme = ddlTheme.SelectedIndex == 0;

            Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.UpdateSettings(profile));
            task.Start();

            var response = await task;
            if (response != null)
            {
                actInd.IsRunning = actInd.IsVisible = false;
                var toast = Toast.Make(response.Message);
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = false;
                var toast = Toast.Make("Something went wrong, please try again");
                await toast.Show();
            }
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else if (selectedIndex == 1)
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}