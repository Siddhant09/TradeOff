using CommunityToolkit.Maui.Alerts;
using System;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

[QueryProperty(nameof(Product), "Product")]
public partial class CommentsPage : ContentPage
{
    BrowseServices _browseServices;

    Product product;
    public Product Product
    {
        get => product;
        set
        {
            product = value;
            OnPropertyChanged();
        }
    }

    public CommentsPage()
	{
        //this.productId = productId; 
        //this.userId = userId;
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
        Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _browseServices.GetComments(product.ProductId));
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
            if (string.IsNullOrEmpty(txtComment.Text.Trim()))
            {
                var toast = Toast.Make("Comment cannot be empty");
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Notification comment = new Notification();
                comment.Message = txtComment.Text.Trim();
                comment.ProductId = product.ProductId;
                comment.ToUserId = product.UserId;
                Task<Response<List<Notification>>> task = new Task<Response<List<Notification>>>(() => _browseServices.InsertComment(comment));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                    {
                        this.BindingContext = response.Data;
                        txtComment.Text = string.Empty;
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
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}