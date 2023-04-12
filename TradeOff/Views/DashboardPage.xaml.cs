using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class DashboardPage : ContentPage
{
    DashboardServices _dashboardServices;
    public DashboardPage()
    {
        _dashboardServices = new DashboardServices();
        InitializeComponent();
        ddlDateRange.SelectedIndex = 0;
        GetDataAsync(ddlDateRange.SelectedIndex);
    }

    //protected override async void OnAppearing()
    //{
    //    await GetDataAsync();
    //    base.OnAppearing();
    //}

    public async void GetDataAsync(int filter)
    {
        //Dashboard dashboard = new Dashboard();
        //List<Product> mostLiked = new List<Product>();
        //List<Product> mostDisiked = new List<Product>();
        //List<Product> mostRequested = new List<Product>();
        //List<Product> users = new List<Product>();

        //Product item = new Product();
        //item.Title = "Coffee Table";
        //item.UserName = "Nithika Sanghi";
        //item.ProfilePicUrl = "temp2.jpg";
        //item.Date = "Member Since: " + DateTime.Now.ToShortDateString();
        //item.Likes = 15;
        //item.Dislikes = 5;
        //item.PicUrl = "https://tradeoffapi.siddhantchawade.com/Content/Images/Coffee Table_1_221206072712.jpg";

        //mostLiked.Add(item);
        //mostDisiked.Add(item);
        //mostRequested.Add(item);
        //users.Add(item);

        //Product item2 = new Product();
        //item2.Title = "Couch";
        //item2.UserName = "Katy Perry";
        //item2.ProfilePicUrl = "user_profile.jpg";
        //item2.Date = "Member Since: " + DateTime.Now.ToShortDateString(); 
        //item2.Likes = 10;
        //item2.Dislikes = 10;
        //item2.PicUrl = "https://tradeoffapi.siddhantchawade.com/Content/Images/Couch_1_221205145936.jpg";

        //mostLiked.Add(item2);
        //mostDisiked.Add(item2);
        //mostRequested.Add(item2);
        //users.Add(item2);

        //Product item3 = new Product();
        //item3.Title = "Couch";
        //item3.Likes = 10;
        //item3.Dislikes = 0;
        //item3.PicUrl = "https://tradeoffapi.siddhantchawade.com/Content/Images/Power Bank_1_221206072931.jpg";

        //mostLiked.Add(item);
        //mostLiked.Add(item2);
        //mostDisiked.Add(item3);
        //mostRequested.Add(item3);

        //dashboard.MostLiked = mostLiked.OrderByDescending(x => x.Likes).ToList();
        //dashboard.MostDisliked = mostDisiked.OrderByDescending(x => x.Dislikes).ToList();
        //dashboard.MostRequested = mostRequested.OrderByDescending(x => x.Likes).ToList();
        //dashboard.Users = users.OrderByDescending(x => x.Likes).ToList();
        //this.BindingContext = dashboard;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<Dashboard>> task = new Task<Response<Dashboard>>(() => _dashboardServices.GetDashboard(filter));
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

    private void ddlDateRange_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetDataAsync(ddlDateRange.SelectedIndex);
    }
}