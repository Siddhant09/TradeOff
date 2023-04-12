using CommunityToolkit.Maui.Alerts;
using System;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class CommentsPage : ContentPage
{
    BrowseServices _browseServices;
    long? productId = null;

    public CommentsPage()
	{
        _browseServices = new BrowseServices();
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
        //data.Add(new Notification { UserProfilePicUrl = "temp2.jpg", UserName = "Nithika Sanghi", Message = "Nice collection, looks good", DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "pro.png", UserName = "John Snow", Message = "WOW", DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "user_profile.png", UserName = "Katy Perry", Message = "Its really nice", DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });
        //data.Add(new Notification { UserProfilePicUrl = "temp1.jpg", UserName = "Siddhant Chawade", Message = "Thanks you so much", DateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt") });

        //this.BindingContext = data;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _browseServices.GetComments(productId));
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

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            Notification comment = new Notification();
            comment.Message = txtComment.Text;
            comment.ProductId = productId;
            comment.ToUserId = 1; 
            Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _browseServices.InsertComment(comment));
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