using LaundrySchedulerApp.Data;

namespace LaundrySchedulerApp; 

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}
    private async void OnSendButtonClicked(object sender, EventArgs e)
    {
        var user = new User
        {
            Username = usernameEntry.Text,
            Email = emailEntry.Text,
            Password = passwordEntry.Text
        };
        
    }
}