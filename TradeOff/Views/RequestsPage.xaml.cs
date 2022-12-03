using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class RequestsPage : ContentPage
{
	Request _request;
	public RequestsPage()
	{
		_request = new Request();
		InitializeComponent();
		IEnumerable<Request> requests = _request.GetRequests();
		this.BindingContext = requests;
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
}