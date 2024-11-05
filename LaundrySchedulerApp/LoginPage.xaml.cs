using LaundrySchedulerApp.Data;
using Microsoft.Maui.Controls;

namespace LaundrySchedulerApp;

public partial class LoginPage : ContentPage
{
       private UserDatabase _userDb = new UserDatabase();

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // Validierung der Eingabefelder
        if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text))
        {
            await DisplayAlert("Fehler", "Bitte alle Felder ausf�llen", "OK");
            return;
        }

        // �berpr�fung der Benutzerdaten
        bool isValidUser = await _userDb.ValidateUserLoginAsync(usernameEntry.Text, passwordEntry.Text);
        if (isValidUser)
        {
            User user = await _userDb.GetUserByUsernameAsync(usernameEntry.Text);
            UserSession.CurrentUserId = user.Id;  // Speichern der Benutzer-ID in der Session
            // Weiterleitung zum Hauptmen� oder �hnlichem
            await DisplayAlert("Erfolg", "Login erfolgreich!", "OK");
            // Navigation Code hier einf�gen
            await Navigation.PushAsync(new Dashboard());

        }
        else
        {
            await DisplayAlert("Fehler", "Benutzername oder Passwort ung�ltig.", "OK");
        }
    }
}