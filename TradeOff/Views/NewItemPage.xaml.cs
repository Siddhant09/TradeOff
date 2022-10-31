using CommunityToolkit.Maui.Alerts;

namespace TradeOff.Views;

public partial class NewItemPage : ContentPage
{
	public NewItemPage()
	{
		InitializeComponent();
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
            else
                await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Error: " + ex.Message);
            await toast.Show();
        }
    }

	private void btnUpload_Clicked(object sender, EventArgs e)
    {

    }
}