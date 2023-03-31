using CommunityToolkit.Maui.Alerts;
using System;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class RequestsPage : ContentPage
{
    RequestServices _requestServices;
    public RequestsPage()
    {
        _requestServices = new RequestServices();
        InitializeComponent();
        GetDataAsync();
    }

    //protected override async void OnAppearing()
    //{
    //    await GetDataAsync();
    //    base.OnAppearing();
    //}

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Request>>> task = new Task<Response<List<Request>>>(() => _requestServices.GetTradeRequests());
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

    private async void btnAccept_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            SwipeItem a = (SwipeItem)sender;
            Request product = (Request)a.CommandParameter;

            Request request = new Request();
            request.TradeRequestId = product.TradeRequestId;
            request.IUserId = product.IUserId;

            Task<Response<List<Request>>> task = new Task<Response<List<Request>>>(() => _requestServices.AcceptTradeRequest(request));
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
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            SwipeItem a = (SwipeItem)sender;
            Request product = (Request)a.CommandParameter;

            Request request = new Request();
            request.TradeRequestId = product.TradeRequestId;

            Task<Response<List<Request>>> task = new Task<Response<List<Request>>>(() => _requestServices.CancelTradeRequest(request));
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
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnReject_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            SwipeItem a = (SwipeItem)sender;
            Request product = (Request)a.CommandParameter;

            Request request = new Request();
            request.TradeRequestId = product.TradeRequestId;
            request.IUserId = product.IUserId;

            Task<Response<List<Request>>> task = new Task<Response<List<Request>>>(() => _requestServices.RejectTradeRequest(request));
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
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnComments_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(CommentsPage)}", true);
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
}