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
}