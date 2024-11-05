using LaundrySchedulerApp.Data;
using Microsoft.Maui.Controls;

namespace LaundrySchedulerApp;

public partial class Dashboard : ContentPage
{
    private readonly UserDatabase _userDb = new UserDatabase();
    public Dashboard()
	{
		InitializeComponent();
        LoadUserData();
    }

    private async void LoadUserData()
    {
        User currentUser = await _userDb.GetUserByIdAsync(UserSession.CurrentUserId);
        if (currentUser != null)
        {
            var welcomeLabel = this.FindByName<Label>("welcomeLabel");
            welcomeLabel.Text = $"Willkommen, {currentUser.Username}!";
        }
    }

    private async void OnCreatBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreatScheduler());
    }
}