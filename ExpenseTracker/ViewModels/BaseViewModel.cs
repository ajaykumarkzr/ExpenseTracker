using CommunityToolkit.Mvvm.ComponentModel;
using ExpenseTracker.Data;
using System.Security.Cryptography;
using System.Text;

namespace ExpenseTracker.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected string GetPasswordHash(string pwd, DatabaseContext _databaseContext)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        protected async Task<bool> AuthenticateUser(string username, string password, DatabaseContext _databaseContext)
        {
            var user = await _databaseContext.GetById<User>(username);
            string existingPasswordHash = GetPasswordHash(password, _databaseContext);
            return existingPasswordHash == user.PasswordHash;
        }

        protected async Task<bool> RegisterUser(User user, DatabaseContext _databaseContext)
        {
            return await _databaseContext.InsertAsync(user);
        }
    }
}
