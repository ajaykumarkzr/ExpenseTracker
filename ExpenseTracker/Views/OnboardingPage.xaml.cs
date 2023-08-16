namespace ExpenseTracker.Views;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		BindingContext = new WelcomePageViewModel();
		InitializeComponent();
	}
}