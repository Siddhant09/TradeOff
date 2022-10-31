using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;
public partial class SignInPage : ContentPage
{
    public SignInPage()
	{
		InitializeComponent();
    }

	private async void btnSignIn_Clicked(object sender, EventArgs e)
	{
        try
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
                await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}", true);
        }
        catch(Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

	private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(SignUpPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}