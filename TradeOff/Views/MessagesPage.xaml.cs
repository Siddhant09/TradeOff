using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class MessagesPage : ContentPage
{
    ProfileServices _profileServices;
    long? userId = null;

    public MessagesPage()
	{
		InitializeComponent();
        _profileServices = new ProfileServices();
    }

    protected override void OnAppearing()
    {
        GetDataAsync();
        base.OnAppearing();
    }

    public async void GetDataAsync()
    {
        //List<Notification> data = new List<Notification>();
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Hi", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "I am interseted in your couch", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Do you need an office chair?", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

        //this.BindingContext = data;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.GetMessages(userId));
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
            message.ToUserId = userId;
            Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.SendMessage(message));
            task.Start();

            var response = await task;
            if (response != null)
            {
                actInd.IsRunning = actInd.IsVisible = false;
                if (response.Success)
                    this.BindingContext = response.Data;

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