using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeChat.Infrastructure.Navigation;
using Models;

namespace FreeChat.Scenes.Conversations.Components;

public partial class ConversationItemViewModel : ObservableObject
{
    private INavigationService _navigationService;
    public Conversation Conversation { get; }

    public ConversationItemViewModel(Conversation conversation)
    {
        Conversation = conversation;
        _navigationService = MauiApplication.Current.Services.GetService<INavigationService>();
    }

    public string Title => $"{Conversation.Peer?.FirstName} {Conversation?.Peer?.LastName}";
    public string? LastMessage => Conversation.LastMessage?.Content;
    public string Picture => Conversation.Peer.ProfilePic;

    [RelayCommand]
    private Task Open()
    {
        return _navigationService.GotoPage($"{Routes.MessagesRoute}?conversation_id={Conversation.Id}");
    }
}
