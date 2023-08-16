namespace ExpenseTracker.Helpers
{
    public static class UserAuthHelper
    {
        public static async Task CleanAfterLogout()
        {
            await Task.Run(() => { });
        }
    }
}
