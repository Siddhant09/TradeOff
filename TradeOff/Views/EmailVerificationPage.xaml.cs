using CommunityToolkit.Maui.Alerts;
using System.Text.Json;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class EmailVerificationPage : ContentPage
{
    private HttpClient _client = new HttpClient();
    JsonSerializerOptions _serializerOptions;
    ProfileServices _profileServices;
    public EmailVerificationPage()
    {
        _profileServices = new ProfileServices();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        InitializeComponent();
        string email = Preferences.Default.Get("TempEmail", string.Empty);
        if(!string.IsNullOrEmpty(email))
            lblEmail.Text = "A verification code has been sent to " + email + ". Please enter the code.";
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
                actInd.IsRunning = actInd.IsVisible = true;
                User user = new User();
                user.AuthToken = tXtCode.Text;
                user.Email = Preferences.Default.Get("TempEmail", string.Empty);

                Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.VerifyEmail(user));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    if (response.Success)
                    {
                        actInd.IsRunning = actInd.IsVisible = false;
                        var toast = Toast.Make(response.Message);
                        await toast.Show();
                        await Shell.Current.GoToAsync($"//{nameof(SignInPage)}", true);
                    }
                    else
                    {
                        actInd.IsRunning = actInd.IsVisible = false;
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