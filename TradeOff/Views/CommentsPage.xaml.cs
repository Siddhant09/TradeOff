using CommunityToolkit.Maui.Alerts;
using System;
using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class CommentsPage : ContentPage
{
	public CommentsPage()
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
        data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Nice collection, looks good", DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        data.Add(new Notification { UserProfilePicUrl = "pro.png", UserName = "John Snow", Message = "WOW", DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        data.Add(new Notification { UserProfilePicUrl = "user_profile.png", UserName = "Katy Perry", Message = "Its really nice", DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        data.Add(new Notification { UserProfilePicUrl = "temp1.jpg", UserName = "Siddhant Chawade", Message = "Thanks you so much", DateTIme = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

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