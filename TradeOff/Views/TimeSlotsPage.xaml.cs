using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class TimeSlotsPage : ContentPage
{
	public TimeSlotsPage()
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
        List<Availability> data = new List<Availability>();
        data.Add(new Availability { From = "11:00 AM", To = "5:00 PM", Days = "Sunday, Saturday"});
        data.Add(new Availability { From = "9:00 PM", To = "11:00 PM", Days = "Monday, Tuesday, Wednesday" });
        data.Add(new Availability { From = "6:00 PM", To = "11:00 PM", Days = "Friday" });

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