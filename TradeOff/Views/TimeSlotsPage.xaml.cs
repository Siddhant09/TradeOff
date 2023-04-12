using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class TimeSlotsPage : ContentPage
{
    ProfileServices _profileServices;
    public TimeSlotsPage()
	{
		InitializeComponent();
        GetDataAsync();
    }

    //protected override void OnAppearing()
    //{
    //    GetDataAsync();
    //    base.OnAppearing();
    //}

    public async void GetDataAsync()
    {
        //List<Availability> data = new List<Availability>();
        //data.Add(new Availability { From = "11:00 AM", To = "5:00 PM", Days = "Sunday, Saturday"});
        //data.Add(new Availability { From = "9:00 PM", To = "11:00 PM", Days = "Monday, Tuesday, Wednesday" });
        //data.Add(new Availability { From = "6:00 PM", To = "11:00 PM", Days = "Friday" });

        //this.BindingContext = data;

        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Availability>>> task = new Task<Response<List<Availability>>>(() => _profileServices.GetAvailability());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                foreach(var item in response.Data)
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
}