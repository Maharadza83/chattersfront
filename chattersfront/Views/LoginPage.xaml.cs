using chattersfront.Services;

namespace chattersfront.Views;

public partial class LoginPage : ContentPage
{
    private readonly AuthService _auth;
    public LoginPage(AuthService auth)
    {
        InitializeComponent();
        _auth = auth;
    }

    async void OnLoginClicked(object s, EventArgs e)
    {
        if (await _auth.LoginAsync(EmailEntry.Text, PasswordEntry.Text))
            await Shell.Current.GoToAsync("ChatPage");
        else
            await DisplayAlert("B³¹d", "Logowanie nieudane", "OK");
    }

    async void OnRegisterClicked(object s, EventArgs e)
        => await Shell.Current.GoToAsync("RegisterPage");
}
