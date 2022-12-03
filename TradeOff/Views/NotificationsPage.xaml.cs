using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class NotificationsPage : ContentPage
{
    Notification _notification;
	public NotificationsPage()
	{
		InitializeComponent();
		_notification = new Notification();
		List<Notification> notifications = _notification.GetNotifications();
		this.BindingContext = notifications;
    }

	private void btnDelete_Clicked(object sender, EventArgs e)
	{

	}
}