using System.Net.Http.Json;
using chattersfront.Models;

namespace chattersfront.Services;

public class AuthService
{
    private readonly HttpClient _http;
    public string? Token { get; private set; }

    public AuthService(HttpClient http) => _http = http;

    public async Task<bool> LoginAsync(string email, string password)
    {
        var res = await _http.PostAsJsonAsync("api/auth/login", new LoginModel { Email = email, Password = password });
        if (!res.IsSuccessStatusCode) return false;
        var dto = await res.Content.ReadFromJsonAsync<LoginResponseModel>();
        Token = dto?.Token;
        return !string.IsNullOrEmpty(Token);
    }

    public async Task<bool> RegisterAsync(string email, string password, string fullName)
    {
        var req = new RegisterModel { Email = email, Password = password, FullName = fullName };
        var res = await _http.PostAsJsonAsync("api/auth/register", req);
        return res.IsSuccessStatusCode;
    }
}
