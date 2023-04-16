using CommunityToolkit.Maui.Alerts;
using TradeOff.ClassLibrary;
using TradeOff.Services;

namespace TradeOff.Views;

[QueryProperty(nameof(Product), "Product")]
public partial class NewItemPage : ContentPage
{
    UploadImage _uploadImage { get; set; }
    InventoryServices _inventoryServices;
    byte[] _imageBytes;
    string _fileName;
    bool _reload = true;

    Product product;
    public Product Product
    {
        get => product;
        set
        {
            product = value;
            OnPropertyChanged();
        }
    }
    public NewItemPage()
    {
        _inventoryServices = new InventoryServices();
        _uploadImage = new UploadImage();
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        if(_reload )
            await GetDataAsync();

        base.OnAppearing();
    }

    public async Task GetDataAsync()
    {
        actInd.IsRunning = actInd.IsVisible = true;
        Task<Response<InventoryOptions>> task = new Task<Response<InventoryOptions>>(() => _inventoryServices.GetInventoryOptions());
        task.Start();

        var response = await task;
        if (response != null)
        {
            actInd.IsRunning = actInd.IsVisible = false;
            if (response.Success)
            {
                this.BindingContext = response.Data;
                if (product != null)
                {
                    txtTitle.Text = product.Title;
                    txtDescription.Text = product.Description;
                    ddlCategory.SelectedItem = response.Data.CategoryList.Where(x => x.LookupId == product.CategoryId).FirstOrDefault();
                    ddlCondition.SelectedItem = response.Data.ConditionList.Where(x => x.LookupId == product.ConditionId).FirstOrDefault();
                    ddlAge.SelectedItem = response.Data.AgeList.Where(x => x.LookupId == product.AgeId).FirstOrDefault();
                    txtTags.Text = product.Tags;
                }
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
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                var toast = Toast.Make("Title is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtDescription.Text))
            {
                var toast = Toast.Make("Description is required");
                await toast.Show();
            }
            else if (ddlCategory.SelectedItem == null)
            {
                var toast = Toast.Make("Category is required");
                await toast.Show();
            }
            else if (ddlAge.SelectedItem == null)
            {
                var toast = Toast.Make("Age is required");
                await toast.Show();
            }
            else if (ddlCondition.SelectedItem == null)
            {
                var toast = Toast.Make("Condition is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(txtTags.Text))
            {
                var toast = Toast.Make("Tag is required");
                await toast.Show();
            }
            else if (string.IsNullOrEmpty(_fileName) && product == null)
            {
                var toast = Toast.Make("Image is required");
                await toast.Show();
            }
            else
            {
                Product pro = new Product();
                pro.ProductId = product != null ? product.ProductId : null;
                pro.Title = txtTitle.Text;
                pro.Description = txtDescription.Text;
                pro.CategoryId = ((LookupOption)ddlCategory.SelectedItem).LookupId;
                pro.AgeId = ((LookupOption)ddlAge.SelectedItem).LookupId;
                pro.ConditionId = ((LookupOption)ddlCondition.SelectedItem).LookupId;
                pro.Tags = txtTags.Text;

                actInd.IsRunning = actInd.IsVisible = true;
                Task<Response<Inventory>> task = new Task<Response<Inventory>>(() => _inventoryServices.UpsertProduct(pro, _imageBytes, _fileName));
                task.Start();

                var response = await task;
                if (response != null)
                {
                    actInd.IsRunning = actInd.IsVisible = false;
                    if (response.Success)
                    {
                        var toast = Toast.Make(response.Message);
                        await toast.Show();
                        await Navigation.PopAsync();
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

    private async void btnUpload_Clicked(object sender, EventArgs e)
    {
        _reload = false;
        var img = await _uploadImage.OpenMediaPickerAsync();
        if(img != null)
        {
            var imagefile = await _uploadImage.Upload(img);
            _fileName = imagefile.FileName;
            _imageBytes = _uploadImage.StringToByteBase64(imagefile.byteBase64);
            btnUpload.Text = "1 Image Selected";
        }
    }
}