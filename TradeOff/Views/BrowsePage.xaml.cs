using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;

namespace TradeOff.Views;

public partial class BrowsePage : ContentPage
{
    Item _items;
    public BrowsePage()
    {
        _items = new Item();
        InitializeComponent();
        IEnumerable<Item> Items = _items.GetItems().OrderBy(x => x.Title).ToList();
        this.BindingContext = Items;
    }

    private void btnRequest_Clicked(object sender, EventArgs e)
    {

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