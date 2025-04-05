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

    [ObservableProperty]
    private string? _lastMessage;
    [ObservableProperty]
    private DateTime? _lastMessageDate;
    [ObservableProperty]
    private User _peer;

    public ConversationItemViewModel(Conversation conversation)
    {
        _navigationService = Application.Current.Windows[0].Page.Handler.MauiContext.Services.GetService<INavigationService>();
        _conversation = conversation;
        
        LastMessage = conversation.LastMessage.Content;
        LastMessageDate = conversation.LastMessage.CreationDate;
        Peer = conversation.Peer;
    }

    [RelayCommand]
    private Task OpenConversation()
    {
        return _navigationService.GotoPage($"{Routes.MessagesRoute}?conversation_id={Conversation.Id}");
    }
}
