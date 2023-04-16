using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

[QueryProperty(nameof(Availability), "Availability")]
public partial class NewTimeSlotPage : ContentPage
{
    ProfileServices _profileServices;

    Availability availability;
    public Availability Availability
    {
        get => availability;
        set
        {
            availability = value;
            OnPropertyChanged();
        }
    }

    public NewTimeSlotPage()
	{
		InitializeComponent();
        _profileServices = new ProfileServices();
    }
    protected override void OnAppearing()
    {
        if (availability != null)
        {
            availability.FromTime = availability.From.Value.TimeOfDay;
            availability.ToTime = availability.To.Value.TimeOfDay;
            this.BindingContext = availability;
        }
        base.OnAppearing();
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
            if(tpFrom.Time >= tpTo.Time)
            {
                var toast = Toast.Make("To time must be greater than From time");
                await toast.Show();
            }
            else if(!cbMonday.IsChecked && !cbTuesday.IsChecked && !cbWednesday.IsChecked && !cbThursday.IsChecked && !cbFriday.IsChecked && !cbSaturday.IsChecked && !cbSunday.IsChecked)
            {
                var toast = Toast.Make("Select at least one day");
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Availability ava = new Availability();
                ava.AvailabilityId = availability != null ? availability.AvailabilityId : null;
                ava.From = DateTime.Now.Date.AddHours(tpFrom.Time.Hours).AddMinutes(tpFrom.Time.Minutes); // Convert.ToDateTime(tpFrom.Time);
                ava.To = DateTime.Now.Date.AddHours(tpTo.Time.Hours).AddMinutes(tpTo.Time.Minutes); // Convert.ToDateTime(tpTo.Time);
                ava.Monday = cbMonday.IsChecked;
                ava.Tuesday = cbTuesday.IsChecked;
                ava.Wednesday = cbWednesday.IsChecked;
                ava.Thursday = cbThursday.IsChecked;
                ava.Friday = cbFriday.IsChecked;
                ava.Saturday = cbSaturday.IsChecked;
                ava.Sunday = cbSunday.IsChecked;

                Task<Response<List<Availability>>> task = new Task<Response<List<Availability>>>(() => _profileServices.UpsertAvailability(ava));
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
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}