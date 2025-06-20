using chattersfront.Services;

namespace chattersfront.Views;

public partial class RegisterPage : ContentPage
{
    private readonly AuthService _auth;

    public RegisterPage(AuthService auth)
    {
        InitializeComponent();
        _auth = auth;
    }

    async void OnRegisterClicked(object sender, EventArgs e)
    {
        bool ok = await _auth.RegisterAsync(
            EmailEntry.Text,
            PasswordEntry.Text,
            FullNameEntry.Text);

        if (ok)
            await DisplayAlert("Sukces", "Zarejestrowano pomyœlnie", "OK");
        else
            await DisplayAlert("B³¹d", "Rejestracja nieudana", "OK");
    }
}
