using ExpenseTracker.Models;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private Auth _credentials = new Auth();
        public Auth Credentials 
        { 
            get => _credentials; 
            set => SetProperty(ref _credentials, value, nameof(Credentials)); }
        
        public ICommand LoginCommand { get; set; }

        #region Constructor
        public LoginPageViewModel()
        {
            LoginCommand = new Command(() => LoginCommandDefinition());
        }
        #endregion

        #region Private Methods
        private void LoginCommandDefinition()
        {
            try
            {
                if (Regex.IsMatch(Credentials?.Username, Strings.RegExpEmail))
                {
                    ApplicationSettings.UserId = Credentials?.Username;
                    Application.Current.MainPage = new HomePage();
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
            
        }
        #endregion
    }
}
