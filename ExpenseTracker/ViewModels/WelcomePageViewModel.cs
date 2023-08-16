namespace ExpenseTracker.ViewModels
{
    public class WelcomePageViewModel
    {
        public ICommand LogoutCommand { get; set; }

        #region Constructor
        public WelcomePageViewModel()
        {
            LogoutCommand = new Command(async () => await LogoutCommandDefinition());
        }
        #endregion

        private async Task LogoutCommandDefinition()
        {
            ApplicationSettings.UserId = string.Empty;
            Application.Current.MainPage = new LoginPage();
            await UserAuthHelper.CleanAfterLogout();
        }
    }
}
