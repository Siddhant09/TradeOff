using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class TimeSlotsPage : ContentPage
{
    ProfileServices _profileServices;
    public TimeSlotsPage()
    {
        _profileServices = new ProfileServices();
        InitializeComponent();
        //GetDataAsync();
    }

    protected override void OnAppearing()
    {
        GetDataAsync();
        base.OnAppearing();
    }

    public async void GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Availability>>> task = new Task<Response<List<Availability>>>(() => _profileServices.GetAvailability());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                if (response.Data.Count > 0)
                    foreach (var item in response.Data)
                    {
                        item.Days = "";
                        if (item.Monday == true)
                            item.Days += "Monday ";
                        if (item.Tuesday == true)
                            item.Days += "Tuesday ";
                        if (item.Wednesday == true)
                            item.Days += "Wednesday ";
                        if (item.Thursday == true)
                            item.Days += "Thursday ";
                        if (item.Friday == true)
                            item.Days += "Friday ";
                        if (item.Saturday == true)
                            item.Days += "Saturday ";
                        if (item.Sunday == true)
                            item.Days += "Sunday";
                    }
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

    private async void btnNew_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(NewTimeSlotPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (await DisplayAlert("Confirm Delete", "Are you sure?", "Yes", "No"))
            {
                SwipeItem a = (SwipeItem)sender;
                Availability availability = (Availability)a.CommandParameter;

                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<List<Availability>>> task = new Task<Response<List<Availability>>>(() => _profileServices.DeleteAvailability(availability));
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
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        try
        {
            SwipeItem a = (SwipeItem)sender;
            Availability availability = (Availability)a.CommandParameter;
            var param = new Dictionary<string, object>
                {
                    { "Availability", availability }
                };
            await Shell.Current.GoToAsync($"{nameof(NewTimeSlotPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}