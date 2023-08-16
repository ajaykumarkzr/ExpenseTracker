namespace ExpenseTracker.Settings
{
    public class ApplicationSettings
    {
        public static string UserId
        {
            get => Preferences.Get(nameof(UserId), string.Empty);
            set => Preferences.Set(nameof(UserId), value);
        }
        public static bool isLoggedIn => !string.IsNullOrWhiteSpace(UserId);
    }
}
