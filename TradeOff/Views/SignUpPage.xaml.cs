using CommunityToolkit.Maui.Alerts;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class SignUpPage : ContentPage
{
    ProfileServices _profileServices;
	public SignUpPage()
	{
        _profileServices= new ProfileServices();
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
                actInd.IsRunning = actInd.IsVisible = true;
                User user = new User();
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.SignUp(user));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    if (response.Success)
                    {
                        Preferences.Default.Set("TempEmail", user.Email);
                        actInd.IsRunning = actInd.IsVisible = false;
                        var toast = Toast.Make(response.Message);
                        await toast.Show();
                        await Shell.Current.GoToAsync($"{nameof(EmailVerificationPage)}", true);
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