﻿using TradeOff.Views;

namespace TradeOff;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(EmailVerificationPage), typeof(EmailVerificationPage));
        Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
        Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        Routing.RegisterRoute(nameof(NotificationsPage), typeof(NotificationsPage));
        Routing.RegisterRoute(nameof(CommentsPage), typeof(CommentsPage));
        Routing.RegisterRoute(nameof(TimeSlotsPage), typeof(TimeSlotsPage));
        Routing.RegisterRoute(nameof(NewTimeSlotPage), typeof(NewTimeSlotPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(InboxPage), typeof(InboxPage));
        Routing.RegisterRoute(nameof(MessagesPage), typeof(MessagesPage));
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    }
}
