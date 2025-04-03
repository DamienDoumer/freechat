using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeChat.Infrastructure.Navigation;
using Models;

namespace FreeChat.Scenes.Conversations.Components;

public partial class ConversationItemViewModel : ObservableObject
{
    private INavigationService _navigationService;
    [ObservableProperty] 
    private Conversation _conversation;

    public ConversationItemViewModel(Conversation conversation, INavigationService navigationService)
    {
        _navigationService = navigationService;
        _conversation = conversation;
    }

    public string Title => $"{Conversation.Peer?.FirstName} {Conversation?.Peer?.LastName}";
    public string? LastMessage => Conversation.LastMessage?.Content;
    public User Peer => Conversation.Peer;

    [RelayCommand]
    private Task OpenConversation()
    {
        return _navigationService.GotoPage($"{Routes.MessagesRoute}?conversation_id={Conversation.Id}");
    }
}
