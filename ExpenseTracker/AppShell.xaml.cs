namespace ExpenseTracker;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("login", typeof(LoginPage));
		Routing.RegisterRoute("main", typeof(MainPage));
		Routing.RegisterRoute("home", typeof(HomePage));
		Routing.RegisterRoute("profile", typeof(ProfilePage));
	}
}
