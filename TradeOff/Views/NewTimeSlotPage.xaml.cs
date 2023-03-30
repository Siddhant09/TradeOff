using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;

public partial class NewTimeSlotPage : ContentPage
{
	public NewTimeSlotPage()
	{
		InitializeComponent();
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
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}