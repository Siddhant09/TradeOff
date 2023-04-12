using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class NewTimeSlotPage : ContentPage
{
    ProfileServices _profileServices;

    public NewTimeSlotPage()
	{
		InitializeComponent();
        _profileServices = new ProfileServices();
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            actInd.IsRunning = actInd.IsVisible = true;
            Availability availability = new Availability();
            availability.From = Convert.ToDateTime(tpFrom.Time);
            availability.To = Convert.ToDateTime(tpTo.Time);
            availability.Monday = cbMonday.IsChecked;
            availability.Tuesday = cbTuesday.IsChecked;
            availability.Wednesday = cbWednesday.IsChecked;
            availability.Thursday = cbThursday.IsChecked;
            availability.Friday = cbFriday.IsChecked;
            availability.Saturday = cbSaturday.IsChecked;
            availability.Sunday = cbSunday.IsChecked;

            Task<Response<List<Availability>>> task = new Task<Response<List<Availability>>>(() => _profileServices.UpsertAvailability(availability));
            task.Start();

            var response = await task;
            if (response != null)
            {
                actInd.IsRunning = actInd.IsVisible = false;
                if (response.Success)
                    this.BindingContext = response.Data;

                var toast = Toast.Make(response.Message);
                await toast.Show();
                await Navigation.PopAsync();
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