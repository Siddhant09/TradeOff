using TradeOff.Views;

namespace TradeOff;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
    }
}
