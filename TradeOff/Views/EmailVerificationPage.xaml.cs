using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;

public partial class EmailVerificationPage : ContentPage
{
	public EmailVerificationPage()
	{
		InitializeComponent();
	}

	private async void btnVerify_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(tXtCode.Text))
            {
                var toast = Toast.Make("Verification code is required");
                await toast.Show();
            }
            else
            {
                //var toast = Toast.Make("Email verified successfully");
                //await toast.Show();
                await Shell.Current.GoToAsync($"//{nameof(SignInPage)}", true);
            }
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}