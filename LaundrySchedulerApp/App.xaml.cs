using LaundrySchedulerApp.Data; 

namespace LaundrySchedulerApp
{
    public partial class App : Application
    {

        // Eine statische Instanz der UserDatabase, um sicherzustellen, dass sie nur einmal erstellt wird
        static UserDatabase database;

        // Property, um auf die Datenbank zuzugreifen
        public static UserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    // Datenbank initialisieren, falls noch keine Instanz existiert
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
                    database = new UserDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
