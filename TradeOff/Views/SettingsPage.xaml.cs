namespace TradeOff.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();

        if(Application.Current.UserAppTheme == AppTheme.Dark)
            ddlTheme.SelectedIndex = 0;
        else if (Application.Current.UserAppTheme == AppTheme.Light)
            ddlTheme.SelectedIndex = 1;
    }

    private void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex == 0)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else if (selectedIndex == 1)
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}