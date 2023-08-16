namespace ExpenseTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = ApplicationSettings.isLoggedIn ? new HomePage() : new LoginPage();
	}
}
