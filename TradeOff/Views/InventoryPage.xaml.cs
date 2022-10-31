using CommunityToolkit.Maui.Alerts;
using System.Collections.ObjectModel;
using TradeOff.Models;

namespace TradeOff.Views;

public partial class InventoryPage : ContentPage
{
    Item _items;  
	public InventoryPage()
	{
        _items = new Item();
        InitializeComponent();
        IEnumerable<Item> Items = _items.GetItems();
        this.BindingContext = Items;
    }

    //protected override void OnAppearing()
    //{
    //    IEnumerable<Item> Items = _items.GetItems();
    //    this.BindingContext = Items;
    //    base.OnAppearing();
    //}

    public void GetInventory()
    {
        try
        {
            IEnumerable<Item> Items = _items.GetItems();
        }
        catch (Exception ex)
        {
            //var toast = Toast.Make("Error: " + ex.Message);
            //await toast.Show();
        }
    }

	private async void btnNew_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync($"{nameof(NewItemPage)}", true);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            await DisplayAlert("Delete Item", "Are you sure?", "Yes", "No");
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private void btnEdit_Clicked(object sender, EventArgs e)
    {

    }
}