using chattersfront.Services;

namespace chattersfront.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _auth;

    public LoginPage(AuthService auth)
    {
        InitializeComponent();     // teraz jest wygenerowane
        _auth = auth;
    }

    async void OnLoginClicked(object sender, EventArgs e)
    {
        bool ok = await _auth.LoginAsync(EmailEntry.Text, PasswordEntry.Text);
        if (ok)
            await Shell.Current.GoToAsync("ChatPage");
        else
            await DisplayAlert("B³¹d", "Logowanie nieudane", "OK");
    }

    async void OnRegisterClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("RegisterPage");
}
