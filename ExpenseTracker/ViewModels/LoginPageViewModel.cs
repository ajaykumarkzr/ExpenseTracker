using ExpenseTracker.Data;
using ExpenseTracker.Services;
using System.Text.RegularExpressions;

namespace ExpenseTracker.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private Auth _credentials = new Auth();
        private DatabaseContext _databaseContext;
        public Auth Credentials 
        { 
            get => _credentials; 
            set => SetProperty(ref _credentials, value, nameof(Credentials)); }
        
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        #region Constructor
        public LoginPageViewModel()
        {
            _databaseContext = ServiceHelper.GetService<DatabaseContext>();
            LoginCommand = new Command(async () => await LoginCommandDefinition());
            RegisterCommand = new Command(async() => await RegisterCommandDefinition());
        }
        #endregion

        #region Private Methods
        private async Task LoginCommandDefinition()
        {
            try
            {
                if (Regex.IsMatch(_credentials?.Username, Strings.RegExpEmail))
                {
                    bool isAuthenticated = await AuthenticateUser(_credentials.Username, _credentials.Password, _databaseContext);
                    if (isAuthenticated)
                    {
                        ApplicationSettings.UserId = Credentials?.Username;
                        Application.Current.MainPage = new HomePage();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }

        private async Task RegisterCommandDefinition()
        {
            try
            {
                if (Regex.IsMatch(_credentials?.Username, Strings.RegExpEmail))
                {
                    var usr = new User() { Email = _credentials?.Username };
                    usr.PasswordHash = GetPasswordHash(_credentials.Password, _databaseContext);

                    bool isRegistered = await RegisterUser(usr, _databaseContext);
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
