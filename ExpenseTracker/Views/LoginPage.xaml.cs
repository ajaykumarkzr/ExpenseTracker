using ExpenseTracker.Data;

namespace ExpenseTracker.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		BindingContext = new LoginPageViewModel();
		InitializeComponent();
	}
}