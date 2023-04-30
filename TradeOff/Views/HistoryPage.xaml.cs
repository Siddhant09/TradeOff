using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class HistoryPage : ContentPage
{
    ProfileServices _profileServices;
    public HistoryPage()
    {
        _profileServices = new ProfileServices();
        InitializeComponent();
        //GetDataAsync();
    }

    protected override async void OnAppearing()
    {
        await GetDataAsync();
        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Request>>> task = new Task<Response<List<Request>>>(() => _profileServices.GetTradeRequestHistory());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
                this.BindingContext = response.Data;
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

    private async void btnComments_Clicked(object sender, EventArgs e)
    {
        try
        {
            ImageButton a = (ImageButton)sender;
            Request request = (Request)a.CommandParameter;
            Product product = new Product() { 
                ProductId = Preferences.Default.Get("userName", string.Empty) == request.IUserName ? request.OProductId : request.IProductId,
                UserId = Preferences.Default.Get("userName", string.Empty) == request.IUserName ? request.OUserId : request.IUserId
            };
            var param = new Dictionary<string, object>
                {
                    { "Product", product }
                };
            await Shell.Current.GoToAsync($"{nameof(CommentsPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnComments1_Clicked(object sender, EventArgs e)
    {
        try
        {
            ImageButton a = (ImageButton)sender;
            Request request = (Request)a.CommandParameter;
            Product product = new Product()
            {
                ProductId = Preferences.Default.Get("authToken", string.Empty) != request.IUserName ? request.OProductId : request.IProductId,
                UserId = Preferences.Default.Get("authToken", string.Empty) != request.IUserName ? request.OUserId : request.IUserId
            };
            var param = new Dictionary<string, object>
                {
                    { "Product", product }
                };
            await Shell.Current.GoToAsync($"{nameof(CommentsPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}