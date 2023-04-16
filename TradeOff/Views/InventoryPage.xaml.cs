using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class InventoryPage : ContentPage
{
    InventoryServices _inventoryServices;
	public InventoryPage()
    {
        _inventoryServices = new InventoryServices();
        InitializeComponent();
        //GetDataAsync();
    }

    protected override async void OnAppearing()
    {
        await GetDataAsync();
        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _inventoryServices.GetInventory());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
                this.BindingContext = response.Data;
            else
            {
                var toast = Toast.Make(response.Message);
                await toast.Show();
            }
        }
        else
        {
            actInd.IsRunning = actInd.IsVisible = false;
            var toast = Toast.Make("Something went wrong, please try again");
            await toast.Show();
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
            if(await DisplayAlert("Confirm Delete", "Are you sure?", "Yes", "No"))
            {
                SwipeItem a = (SwipeItem)sender;
                Product product = (Product)a.CommandParameter;

                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _inventoryServices.DeleteProduct(product));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                        this.BindingContext = response.Data;
                    else
                    {
                        var toast = Toast.Make(response.Message);
                        await toast.Show();
                    }
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

    private async void btnEdit_Clicked(object sender, EventArgs e)
    {
        try
        {
            SwipeItem a = (SwipeItem)sender;
            Product product = (Product)a.CommandParameter;
            var param = new Dictionary<string, object>
                {
                    { "Product", product }
                };
            await Shell.Current.GoToAsync($"{nameof(NewItemPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

    private async void btnComments_Clicked(object sender, EventArgs e)
    {
        try
        {
            ImageButton a = (ImageButton)sender;
            Product product = (Product)a.CommandParameter;
            var param = new Dictionary<string, object>
                {
                    { "Product", product }
                };
            await Shell.Current.GoToAsync($"{nameof(CommentsPage)}", true, param);
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }
}