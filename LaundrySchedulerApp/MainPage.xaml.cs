namespace LaundrySchedulerApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginBtnClicked(object sender, EventArgs e)
        {
            // Navigiere zur Login Page
            await Navigation.PushAsync(new LoginPage());
        }
        private async void OnSignUpBtnClicked(object sender, EventArgs e)
        {
            // Navigiere zur SignUpPage
            await Navigation.PushAsync(new SignUpPage());
        }
    }

}
