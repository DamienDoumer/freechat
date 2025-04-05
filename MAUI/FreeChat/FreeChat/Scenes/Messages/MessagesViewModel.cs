using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeChat.Infrastructure.Persistence;
using FreeChat.Scenes.Shared;
using Models;

namespace FreeChat.Scenes.Messages;

[QueryProperty("ConversationId", "conversation_id")]
public class MessagesViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _conversationId;
    [ObservableProperty]
    private readonly Conversation _conversation;
    [ObservableProperty]
    private bool _isTyping;
    
    public MessagesViewModel(IUsersDataStore userDataStore,
        IConversationsDataStore convDataStore, IMessagesDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
    {
    }

    protected override Task OnInitialize()
    {
        throw new NotImplementedException();
    }

    protected override Task OnStop()
    {
        throw new NotImplementedException();
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    private Task SendMessage()
    {
        
    }
}