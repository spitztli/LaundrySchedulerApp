using SQLite;
using System.Diagnostics;

namespace LaundrySchedulerApp.Data
{
    public class UserDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public UserDatabase()
        {
            // Der path wird hier später angepasst damit es über einen Gehosteten Datenbank Server läuft 
            var dbPath = @"C:\Users\samvo\source\repos\LaundrySchedulerApp\LaundrySchedulerApp\UserDatabase.db3";
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait(); // Erstellt die Tabelle, wenn sie noch nicht existiert

            if (File.Exists(dbPath))
            {
                Trace.WriteLine("Datenbankdatei wurde erfolgreich erstellt.");
            }
            else
            {
                Trace.WriteLine("Fehler: Datenbankdatei wurde nicht erstellt.");
            }
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _database.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _database.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return _database.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        // Neue Methode für Benutzerlogin
        public async Task<bool> ValidateUserLoginAsync(string username, string password)
        {
            var user = await _database.Table<User>()
                                      .Where(u => u.Username == username && u.Password == password)
                                      .FirstOrDefaultAsync();
            return user != null;
        }
    }
}