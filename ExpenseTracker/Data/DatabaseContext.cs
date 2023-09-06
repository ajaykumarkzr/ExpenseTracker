using SQLite;
using System.Linq.Expressions;

namespace ExpenseTracker.Data
{
    public class DatabaseContext
    {
        private const string _dbName = "UsersDB.db3";
        private static string _dbPath => Path.Combine(FileSystem.AppDataDirectory, _dbName);
        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection _dataBase => (_connection ??= new SQLiteAsyncConnection(_dbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));

        public async Task CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            await _dataBase.CreateTableAsync<TTable>();
        }

        private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return _dataBase.Table<TTable>();
        }

        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.ToListAsync();
        }

        public async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        {
            await CreateTableIfNotExists<TTable>();
            return await action();
        }

        public async Task<TTable> GetById<TTable>(object id) where TTable : class, new()
        {
            return await Execute<TTable, TTable>(async () => await _dataBase.GetAsync<TTable>(id));
        }

        public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            var table = await GetTableAsync<TTable>();
            return await table.Where(predicate).ToListAsync();
        }

        public async Task<bool> InsertAsync<TTable>(TTable item) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await _dataBase.InsertAsync(item) > 0);
        }

        public async Task<bool> UpdateAsync<TTable>(TTable item) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await _dataBase.UpdateAsync(item) > 0);
        }

        public async Task<bool> DeleteAsync<TTable>(TTable item) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await _dataBase.DeleteAsync(item) > 0);
        }

        public async Task<bool> DeleteByIdAsync<TTable>(object id) where TTable : class, new()
        {
            return await Execute<TTable, bool>(async () => await _dataBase.DeleteAsync<TTable>(id) > 0);
        }

        public async ValueTask DisposeAsync() => await _connection?.CloseAsync();
    }
}
