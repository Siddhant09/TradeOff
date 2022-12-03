using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class HistoryPage : ContentPage
{
    Request _request;
    public HistoryPage()
    {
        _request = new Request();
        InitializeComponent();
        IEnumerable<Request> requests = _request.GetRequests();
        this.BindingContext = requests;
    }
}