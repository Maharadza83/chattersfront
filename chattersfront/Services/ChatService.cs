using Microsoft.AspNetCore.SignalR.Client;
using chattersfront.Models;

namespace chattersfront.Services;

public class ChatService
{
    private HubConnection? _hub;
    public event Action<Message>? MessageReceived;

    public async Task ConnectAsync(string token)
    {
        _hub = new HubConnectionBuilder()
            .WithUrl("http://localhost:5244/chatHub", opts =>
                opts.AccessTokenProvider = () => Task.FromResult<string?>(token))
            .WithAutomaticReconnect()
            .Build();

        _hub.On<Message>("ReceiveMessage", msg => MessageReceived?.Invoke(msg));
        await _hub.StartAsync();
    }

    public Task SendMessageAsync(string text)
        => _hub is not null
            ? _hub.SendAsync("SendMessageToChannel", new { ChannelId = "general", Message = text })
            : Task.CompletedTask;
}
