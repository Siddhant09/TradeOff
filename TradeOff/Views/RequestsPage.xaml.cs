using TradeOff.Models;

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
}