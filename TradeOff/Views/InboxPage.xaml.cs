using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class InboxPage : ContentPage
{
    ProfileServices _profileServices;

    public InboxPage()
	{
        _profileServices = new ProfileServices();
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        GetDataAsync();
        base.OnAppearing();
    }

    public async void GetDataAsync()
    {
        //List<Notification> data = new List<Notification>();
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Nice collection, looks good", IsNew = true, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "pro.png", UserName = "John Snow", Message = "WOW", IsNew = false, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "user_profile.png", UserName = "Katy Perry", Message = "Its really nice", IsNew = false, DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

        //this.BindingContext = data;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.GetInbox());
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

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Notification message = (Notification)inboxList.SelectedItem;
            User user = new User() { 
                UserId = message.ToUserId, 
                FirstName = message.ToUserName };
            var param = new Dictionary<string, object>
                {
                    { "User", user }
                };
            await Shell.Current.GoToAsync($"{nameof(MessagesPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}