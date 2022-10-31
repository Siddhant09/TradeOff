using TradeOff.Models;

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
}