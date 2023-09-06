using SQLite;

namespace ExpenseTracker.Models
{
    public class User
    {
        [Unique, AutoIncrement]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        [PrimaryKey]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }

    }
}
