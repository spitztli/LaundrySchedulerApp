using LaundrySchedulerApp.Data;

namespace LaundrySchedulerApp
{
    public partial class App : Application
    {
        public static UserDatabase Database { get; private set; }

        public App()
        {
            InitializeComponent();

            Database = new UserDatabase();
            MainPage = new AppShell();
        }
    }
}