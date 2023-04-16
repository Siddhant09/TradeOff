using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class ProfilePage : ContentPage
{
    ProfileServices _profileServices;
    UploadImage _uploadImage { get; set; }
    byte[] _imageBytes;
    string _fileName;
    bool _reload = true;

    List<LookupOption> states = new List<LookupOption>() {
            new LookupOption() {LookupId = 1, LookupName = "Alabama"},
            new LookupOption() {LookupId = 2, LookupName = "Alaska"},
            new LookupOption() {LookupId = 3, LookupName = "Arizona"},
            new LookupOption() {LookupId = 4, LookupName = "Arkansas"},
            new LookupOption() {LookupId = 5, LookupName = "California"},
            new LookupOption() {LookupId = 6, LookupName = "Colorado"},
            new LookupOption() {LookupId = 7, LookupName = "Connecticut"},
            new LookupOption() {LookupId = 8, LookupName = "Delaware"},
            new LookupOption() {LookupId = 9, LookupName = "Florida"},
            new LookupOption() {LookupId = 10, LookupName = "Georgia"},
            new LookupOption() {LookupId = 11, LookupName = "Hawaii"},
            new LookupOption() {LookupId = 12, LookupName = "Idaho"},
            new LookupOption() {LookupId = 13, LookupName = "Illinois"},
            new LookupOption() {LookupId = 14, LookupName = "Indiana"},
            new LookupOption() {LookupId = 15, LookupName = "Iowa"},
            new LookupOption() {LookupId = 16, LookupName = "Kansas"},
            new LookupOption() {LookupId = 17, LookupName = "Kentucky"},
            new LookupOption() {LookupId = 18, LookupName = "Louisiana"},
            new LookupOption() {LookupId = 19, LookupName = "Maine"},
            new LookupOption() {LookupId = 20, LookupName = "Maryland"},
            new LookupOption() {LookupId = 21, LookupName = "Massachusetts"},
            new LookupOption() {LookupId = 22, LookupName = "Michigan"},
            new LookupOption() {LookupId = 23, LookupName = "Minnesota"},
            new LookupOption() {LookupId = 24, LookupName = "Mississippi"},
            new LookupOption() {LookupId = 25, LookupName = "Missouri"},
            new LookupOption() {LookupId = 26, LookupName = "Montana"},
            new LookupOption() {LookupId = 27, LookupName = "Nebraska"},
            new LookupOption() {LookupId = 28, LookupName = "Nevada"},
            new LookupOption() {LookupId = 29, LookupName = "New Hampshire"},
            new LookupOption() {LookupId = 30, LookupName = "New Jersey"},
            new LookupOption() {LookupId = 31, LookupName = "New Mexico"},
            new LookupOption() {LookupId = 32, LookupName = "New York"},
            new LookupOption() {LookupId = 33, LookupName = "North Carolina"},
            new LookupOption() {LookupId = 34, LookupName = "North Dakota"},
            new LookupOption() {LookupId = 35, LookupName = "Ohio"},
            new LookupOption() {LookupId = 36, LookupName = "Oklahoma"},
            new LookupOption() {LookupId = 37, LookupName = "Oregon"},
            new LookupOption() {LookupId = 38, LookupName = "Pennsylvania"},
            new LookupOption() {LookupId = 39, LookupName = "Rhode Island"},
            new LookupOption() {LookupId = 40, LookupName = "South Carolina"},
            new LookupOption() {LookupId = 41, LookupName = "South Dakota"},
            new LookupOption() {LookupId = 42, LookupName = "Tennessee"},
            new LookupOption() {LookupId = 43, LookupName = "Texas"},
            new LookupOption() {LookupId = 44, LookupName = "Utah"},
            new LookupOption() {LookupId = 45, LookupName = "Vermont"},
            new LookupOption() {LookupId = 46, LookupName = "Virginia"},
            new LookupOption() {LookupId = 47, LookupName = "Washington"},
            new LookupOption() {LookupId = 48, LookupName = "West Virginia"},
            new LookupOption() {LookupId = 49, LookupName = "Wisconsin"},
            new LookupOption() {LookupId = 50, LookupName = "Wyoming"}
        };

    public ProfilePage()
    {
        _uploadImage = new UploadImage();
        _profileServices = new ProfileServices();
        InitializeComponent();
        //GetDataAsync();
        //ddlState.SelectedIndex= 0;  
    }

    protected override async void OnAppearing()
    {
        if (_reload)
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

                response.Data.StatesList = states;
                this.BindingContext = response.Data;

                //txtCity.Text = response.Data.City;
                //txtPincode.Text = response.Data.Pincode;
                ddlState.SelectedItem = states.Where(x => x.LookupId == response.Data.StateId).FirstOrDefault();
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

    public List<LookupOption> GetStatesList()
    {
        List<LookupOption> states = new List<LookupOption>() { 
            new LookupOption() {LookupId = 1, LookupName = "Alabama"},
            new LookupOption() {LookupId = 2, LookupName = "Alaska"},
            new LookupOption() {LookupId = 3, LookupName = "Arizona"},
            new LookupOption() {LookupId = 4, LookupName = "Arkansas"},
            new LookupOption() {LookupId = 5, LookupName = "California"},
            new LookupOption() {LookupId = 6, LookupName = "Colorado"},
            new LookupOption() {LookupId = 7, LookupName = "Connecticut"},
            new LookupOption() {LookupId = 8, LookupName = "Delaware"},
            new LookupOption() {LookupId = 9, LookupName = "Florida"},
            new LookupOption() {LookupId = 10, LookupName = "Georgia"},
            new LookupOption() {LookupId = 11, LookupName = "Hawaii"},
            new LookupOption() {LookupId = 12, LookupName = "Idaho"},
            new LookupOption() {LookupId = 13, LookupName = "Illinois"},
            new LookupOption() {LookupId = 14, LookupName = "Indiana"},
            new LookupOption() {LookupId = 15, LookupName = "Iowa"},
            new LookupOption() {LookupId = 16, LookupName = "Kansas"},
            new LookupOption() {LookupId = 17, LookupName = "Kentucky"},
            new LookupOption() {LookupId = 18, LookupName = "Louisiana"},
            new LookupOption() {LookupId = 19, LookupName = "Maine"},
            new LookupOption() {LookupId = 20, LookupName = "Maryland"},
            new LookupOption() {LookupId = 21, LookupName = "Massachusetts"},
            new LookupOption() {LookupId = 22, LookupName = "Michigan"},
            new LookupOption() {LookupId = 23, LookupName = "Minnesota"},
            new LookupOption() {LookupId = 24, LookupName = "Mississippi"},
            new LookupOption() {LookupId = 25, LookupName = "Missouri"},
            new LookupOption() {LookupId = 26, LookupName = "Montana"},
            new LookupOption() {LookupId = 27, LookupName = "Nebraska"},
            new LookupOption() {LookupId = 28, LookupName = "Nevada"},
            new LookupOption() {LookupId = 29, LookupName = "New Hampshire"},
            new LookupOption() {LookupId = 30, LookupName = "New Jersey"},
            new LookupOption() {LookupId = 31, LookupName = "New Mexico"},
            new LookupOption() {LookupId = 32, LookupName = "New York"},
            new LookupOption() {LookupId = 33, LookupName = "North Carolina"},
            new LookupOption() {LookupId = 34, LookupName = "North Dakota"},
            new LookupOption() {LookupId = 35, LookupName = "Ohio"},
            new LookupOption() {LookupId = 36, LookupName = "Oklahoma"},
            new LookupOption() {LookupId = 37, LookupName = "Oregon"},
            new LookupOption() {LookupId = 38, LookupName = "Pennsylvania"},
            new LookupOption() {LookupId = 39, LookupName = "Rhode Island"},
            new LookupOption() {LookupId = 40, LookupName = "South Carolina"},
            new LookupOption() {LookupId = 41, LookupName = "South Dakota"},
            new LookupOption() {LookupId = 42, LookupName = "Tennessee"},
            new LookupOption() {LookupId = 43, LookupName = "Texas"},
            new LookupOption() {LookupId = 44, LookupName = "Utah"},
            new LookupOption() {LookupId = 45, LookupName = "Vermont"},
            new LookupOption() {LookupId = 46, LookupName = "Virginia"},
            new LookupOption() {LookupId = 47, LookupName = "Washington"},
            new LookupOption() {LookupId = 48, LookupName = "West Virginia"},
            new LookupOption() {LookupId = 49, LookupName = "Wisconsin"},
            new LookupOption() {LookupId = 50, LookupName = "Wyoming"}
        };

        return states;
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

    private async void btnUpdate_Clicked(object sender, EventArgs e)
    {
        try
        {
            _reload = true;
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
            else if (string.IsNullOrEmpty(txtAddress.Text))
            {
                var toast = Toast.Make("Adddress is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtCity.Text))
            {
                var toast = Toast.Make("City is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtPincode.Text))
            {
                var toast = Toast.Make("Pincode is required");
                await toast.Show();
            }
            else if (ddlState.SelectedItem == null)
            {
                var toast = Toast.Make("State is required");
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = true;
                User profile = new User();
                profile.FirstName = txtFirstName.Text;
                profile.LastName = txtLastName.Text;
                profile.Email = txtEmail.Text;
                profile.Address = txtAddress.Text;
                profile.City = txtCity.Text;
                profile.Pincode = txtPincode.Text;
                profile.StateId = ((LookupOption)ddlState.SelectedItem).LookupId;

                Task<Response<User>> task = new Task<Response<User>>(() => _profileServices.UpdateProfile(profile, _imageBytes, _fileName));
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
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
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

    private async void btnTimeSlots_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(TimeSlotsPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnMore_Clicked(object sender, EventArgs e)
    {
        try
        {
            string action = await DisplayActionSheet("More", "Cancel", "Logout", "Inbox", "Manage Availability", "View History", "Settings");
            if (action == "Manage Availability")
                await Shell.Current.GoToAsync($"{nameof(TimeSlotsPage)}", true);
            else if (action == "View History")
                await Shell.Current.GoToAsync($"{nameof(HistoryPage)}", true);
            else if (action == "Settings")
                await Shell.Current.GoToAsync($"{nameof(SettingsPage)}", true);
            else if (action == "Inbox")
                await Shell.Current.GoToAsync($"{nameof(InboxPage)}", true);
            else if (action == "Logout")
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
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnPic_Clicked(object sender, EventArgs e)
    {
        _reload = false;
        var img = await _uploadImage.OpenMediaPickerAsync();
        if (img != null)
        {
            var imagefile = await _uploadImage.Upload(img);
            _fileName = imagefile.FileName;
            _imageBytes = _uploadImage.StringToByteBase64(imagefile.byteBase64);
            btnPic.Source = ImageSource.FromFile(_fileName);
        }
    }
}