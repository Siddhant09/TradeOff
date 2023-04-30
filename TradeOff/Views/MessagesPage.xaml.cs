using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

[QueryProperty(nameof(User), "User")]
public partial class MessagesPage : ContentPage
{
    ProfileServices _profileServices;

    User user;
    public User User
    {
        get => user;
        set
        {
            user = value;
            OnPropertyChanged();
        }
    }

    public MessagesPage()
	{
		InitializeComponent();
        _profileServices = new ProfileServices();
    }

    protected override void OnAppearing()
    {
        GetDataAsync();
        base.OnAppearing();

        if (user != null)
            lblTitle.Text = user.FirstName;
    }

    public async void GetDataAsync()
    {
        //List<Notification> data = new List<Notification>();
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Hi", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "I am interseted in your couch", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Do you need an office chair?", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

        //this.BindingContext = data;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.GetMessages(user.UserId));
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
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

    private async void btnSend_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            Notification message = new Notification();
            message.Message = txtComment.Text;
            message.ToUserId = user.UserId;
            Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.SendMessage(message));
            task.Start();

            var response = await task;
            if (response != null)
            {
                actInd.IsRunning = actInd.IsVisible = false;
                if (response.Success)
                {
                    txtComment.Text = string.Empty;
                    this.BindingContext = response.Data;
                }

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
}