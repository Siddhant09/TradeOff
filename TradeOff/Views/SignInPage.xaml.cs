using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace TradeOff.Views;
public partial class SignInPage : ContentPage
{
    public SignInPage()
	{
		InitializeComponent();
    }

	private async void btnSignIn_Clicked(object sender, EventArgs e)
	{
        if (string.IsNullOrEmpty(txtEmail.Text))
        {
            var toast = Toast.Make("Email is required");
            await toast.Show();
        }
        else if (string.IsNullOrEmpty(txtPassword.Text))
        {
            var toast = Toast.Make("Password is required");
            await toast.Show();
        }
        else
            await Shell.Current.GoToAsync($"//{nameof(BrowsePage)}");
    }

	private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");
    }
}