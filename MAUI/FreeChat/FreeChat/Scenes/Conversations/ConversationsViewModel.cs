using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeChat.Infrastructure.Navigation;
using FreeChat.Infrastructure.Persistence;
using FreeChat.Scenes.Shared;
using Models;

namespace FreeChat.Scenes.Conversations;

public partial class ConversationsViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IUsersDataStore _userDataStore;
    private readonly IConversationsDataStore _conversationDataStore;
    private readonly IMessagesDataStore _messageDataStore;
    private readonly Session _session;
    
    public ConversationsViewModel(
        Session session,
        IUsersDataStore userDataStore,
        IConversationsDataStore convDataStore,
        IMessagesDataStore messageDataStore,
        INavigationService navigationService)
        : base(userDataStore, convDataStore, messageDataStore)
    {
        _session = session;
        _navigationService = navigationService;
        _userDataStore = userDataStore;
        _conversationDataStore = convDataStore;
        _messageDataStore = messageDataStore;
    }

    [ObservableProperty]
    private string _searchText;

    [ObservableProperty]
    private ObservableCollection<Conversation> _conversations = new();

    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    private async Task FilterOptionChanged(bool notOnline)
    {
        IsBusy = true;

        if (!notOnline)
        {
            var conversations = await _conversationDataStore.GetConversationsForUser(_session.CurrentUser!.Id);
            Conversations = new ObservableCollection<Conversation>(conversations.Where(c => c.Peer.IsOnline));
        }
        else
        {
            await LoadConversations();
        }

        IsBusy = false;
    }
    
    protected override async Task OnInitialize()
    {
        await LoadConversations();
    }

    protected override Task OnStop()
    {
        return Task.CompletedTask;
    }

    private async Task LoadConversations()
    {
        var conversations = await _conversationDataStore.GetConversationsForUser(_session.CurrentUser!.Id);
        var sorted = conversations.OrderByDescending(c => c.LastMessage?.CreationDate);
        this.Conversations = new ObservableCollection<Conversation>(sorted);
    }
}