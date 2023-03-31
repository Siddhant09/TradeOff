using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class MessagesPage : ContentPage
{
	public MessagesPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        GetDataAsync();
        base.OnAppearing();
    }

    public void GetDataAsync()
    {
        List<Notification> data = new List<Notification>();
        data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Hi", IsNew = true, DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "I am interseted in your couch", IsNew = true, DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Do you need an office chair?", IsNew = true, DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

        this.BindingContext = data;

        //actInd.IsRunning = actInd.IsVisible = true;
        //Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _profileServices.GetNotifications());
        //task.Start();

        //var response = await task;
        //if (response != null)
        //{
        //    actInd.IsRunning = actInd.IsVisible = false;
        //    if (response.Success)
        //    {
        //        this.BindingContext = response.Data;
        //    }
        //    else
        //    {
        //        var toast = Toast.Make(response.Message);
        //        await toast.Show();
        //    }
        //}
        //else
        //{
        //    actInd.IsRunning = actInd.IsVisible = false;
        //    var toast = Toast.Make("Something went wrong, please try again");
        //    await toast.Show();
        //}
    }
}