using Microsoft.Maui.ApplicationModel;
using chattersfront.Services;
using chattersfront.Models;

namespace chattersfront.Views;

public partial class ChatPage : ContentPage
{
    private readonly ChatService _chat;
    private readonly AuthService _auth;

    public ChatPage(ChatService chat, AuthService auth)
    {
        InitializeComponent();
        _chat = chat;
        _auth = auth;

        _chat.MessageReceived += msg =>
            MainThread.BeginInvokeOnMainThread(() =>
                MessagesList.Children.Add(
                    new Label { Text = $"{msg.Sender}: {msg.Text}" }));

        _ = _chat.ConnectAsync(_auth.Token!);
    }

    async void OnSendClicked(object s, EventArgs e)
    {
        await _chat.SendMessageAsync(MsgEntry.Text);
        MsgEntry.Text = "";
    }
}
