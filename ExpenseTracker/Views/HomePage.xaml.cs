namespace ExpenseTracker.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		BindingContext = new HomePageViewModel();
		InitializeComponent();
	}
}