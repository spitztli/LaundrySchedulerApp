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
            string.IsNullOrWhiteSpace(confirmPasswordEntry.Text)) // Zus�tzliches Feld f�r Passwortbest�tigung
        {
            await DisplayAlert("Fehler", "Bitte alle Felder ausf�llen", "OK");
            return;
        }

        // �berpr�fung, ob die Passw�rter �bereinstimmen
        if (passwordEntry.Text != confirmPasswordEntry.Text)
        {
            await DisplayAlert("Fehler", "Die Passw�rter stimmen nicht �berein", "OK");
            return;
        }

        // Neuen Benutzer erstellen
        var user = new User
        {
            Username = usernameEntry.Text,
            Email = emailEntry.Text,
            Password = passwordEntry.Text // Hier k�nntest du auch eine Hash-Funktion verwenden
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