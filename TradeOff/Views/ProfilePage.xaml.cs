using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

	private async void btnLogout_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool confirm = await DisplayAlert("Logout", "Are you sure?", "Yes", "No");
            if (confirm)
                await Shell.Current.GoToAsync($"//{nameof(SignInPage)}", true);
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