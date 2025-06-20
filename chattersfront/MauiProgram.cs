using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui;          // <-- Toolkit
using chattersfront.Services;

namespace chattersfront;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
          .UseMauiApp<App>()
          .UseMauiCommunityToolkit()     // <-- po UseMauiApp
          .ConfigureFonts(fonts =>
          {
              fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          });

        // HTTP client do backendu
        builder.Services.AddSingleton(sp => new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5244")
        });

        // Rejestracja usług
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<ChatService>();

        // Rejestracja widoków (ShellContent)
        builder.Services.AddTransient<Views.LoginPage>();
        builder.Services.AddTransient<Views.RegisterPage>();
        builder.Services.AddTransient<Views.ChatPage>();

        return builder.Build();
    }
}
