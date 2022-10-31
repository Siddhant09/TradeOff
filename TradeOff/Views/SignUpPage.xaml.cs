using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

	private async void btnSignUp_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                var toast = Toast.Make("First Name is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                var toast = Toast.Make("Last Name is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                var toast = Toast.Make("Email is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                var toast = Toast.Make("Password is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                var toast = Toast.Make("Confirm Password is required");
                await toast.Show();
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                var toast = Toast.Make("Password do not match");
                await toast.Show();
            }
            else
            {
                //var toast = Toast.Make("Verification code sent!");
                //await toast.Show();
                await Shell.Current.GoToAsync($"{nameof(EmailVerificationPage)}", true);
            }
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}