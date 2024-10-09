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
        // Validierung der Eingabefelder
        if (string.IsNullOrWhiteSpace(usernameEntry.Text) ||
            string.IsNullOrWhiteSpace(emailEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(confirmPasswordEntry.Text)) // Zusätzliches Feld für Passwortbestätigung
        {
            await DisplayAlert("Fehler", "Bitte alle Felder ausfüllen", "OK");
            return;
        }

        // Überprüfung, ob die Passwörter übereinstimmen
        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Fehler", "Die Passwörter stimmen nicht überein", "OK");
            return;
        }

        // Neuen Benutzer erstellen
        var user = new User
        {
            Username = usernameEntry.Text,
            Email = emailEntry.Text,
            Password = passwordEntry.Text // Hier könntest du auch eine Hash-Funktion verwenden
        };

        // Benutzer in der Datenbank speichern
        try
        {
            await App.Database.SaveUserAsync(user);  // Speichert den Benutzer in der SQLite-Datenbank
            await DisplayAlert("Erfolg", "Benutzer erfolgreich registriert", "OK");

            // Nach erfolgreicher Registrierung zur Login-Seite navigieren
            await Navigation.PushAsync(new LoginPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fehler", $"Fehler beim Speichern des Benutzers: {ex.Message}", "OK");
        }
    }
}