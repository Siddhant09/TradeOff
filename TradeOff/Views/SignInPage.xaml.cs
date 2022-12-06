using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;
public partial class SignInPage : ContentPage
{
    ProfileServices _profileServices;
    public SignInPage()
    {
        _profileServices = new ProfileServices();
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        if (!string.IsNullOrEmpty(Preferences.Default.Get("userId", string.Empty)))
            await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}", true);

        base.OnAppearing();
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
            {
                actInd.IsRunning = actInd.IsVisible = true;
                User user = new User();
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.SignIn(user));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    if (response.Success)
                    {
                        //to set session values
                        Preferences.Default.Set("userId", response.Data.strUserId);
                        Preferences.Default.Set("userName", response.Data.FirstName + " " + response.Data.LastName);
                        Preferences.Default.Set("authToken", response.Data.AuthToken);
                        actInd.IsRunning = actInd.IsVisible = false;
                        var toast = Toast.Make(response.Message);
                        await toast.Show();
                        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}", true);
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