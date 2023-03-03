using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

public partial class BrowsePage : ContentPage
{
    BrowseServices _browseServices;
    InventoryServices _inventoryServices;
    IEnumerable<Product> _products;
    IEnumerable<Product> _inventory;
    public BrowsePage()
    {
        _browseServices = new BrowseServices();
        _inventoryServices = new InventoryServices();
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await GetDataAsync();
        await GetInventoryAsync();
        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _browseServices.GetBrowse(null));
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                _products = response.Data;
                this.BindingContext = _products;
            }
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

    public async Task GetInventoryAsync()
    {
        //actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _inventoryServices.GetInventory());
        task.Start();

        var response = await task;
        if (response != null)
        {
            //actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
                _inventory = response.Data;
        }
        else
        {
            //actInd.IsRunning = actInd.IsVisible = false;
            var toast = Toast.Make("Something went wrong, please try again");
            await toast.Show();
        }
    }

    private async void btnRequest_Clicked(object sender, EventArgs e)
    {
        try
        {
            SwipeItem a = (SwipeItem)sender;
            Product product = (Product)a.CommandParameter;

            string[] products = _inventory.Select(x => x.Title).ToArray();

            string action = await DisplayActionSheet(product.Title + ": Trade with?", "Cancel", null, products);
            if(!string.IsNullOrEmpty(action) && products.Contains(action))
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Request request = new Request();
                request.OProductId = _inventory.Where(x => x.Title == action).FirstOrDefault().ProductId;
                request.IProductId = product.ProductId;
                request.IUserId = product.UserId;

                Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _browseServices.RequestTrade(request));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                    {
                        _products = response.Data;
                        this.BindingContext = _products;
                    }
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

    private async void btnLike_Clicked(object sender, EventArgs e)
    {
        try
        {
            SwipeItem a = (SwipeItem)sender;
            Product product = (Product)a.CommandParameter;
            if(product.Liked == true)
            {
                var toast = Toast.Make("Product already liked");
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _browseServices.LikeProduct(product));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                    {
                        _products = response.Data;
                        this.BindingContext = _products;
                    }
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

    private async void btnDislike_Clicked(object sender, EventArgs e)
    {
        try
        {
            SwipeItem a = (SwipeItem)sender;
            Product product = (Product)a.CommandParameter;
            if (product.Disiked == true)
            {
                var toast = Toast.Make("Product already disliked");
                await toast.Show();
            }
            else
            {
                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<List<Product>>> task = new Task<Response<List<Product>>>(() => _browseServices.DislikeProduct(product));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                    {
                        _products = response.Data;
                        this.BindingContext = _products;
                    }
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
}