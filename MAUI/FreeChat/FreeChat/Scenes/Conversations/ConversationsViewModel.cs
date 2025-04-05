using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FreeChat.Infrastructure.Navigation;
using FreeChat.Infrastructure.Persistence;
using FreeChat.Scenes.Shared;
using Models;

namespace FreeChat.Scenes.Conversations;

public partial class ConversationsViewModel(
    Session session,
    IUsersDataStore userDataStore,
    IConversationsDataStore convDataStore,
    IMessagesDataStore messageDataStore,
    INavigationService navigationService)
    : BaseViewModel(userDataStore, convDataStore, messageDataStore)
{
    [ObservableProperty]
    private string _searchText = string.Empty;
    public INavigationService NavigationService => navigationService;
    [ObservableProperty]
    private ObservableCollection<Conversation> _conversations = new();
    
    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    private async Task FilterOptionChanged(bool notOnline)
    {
        IsBusy = true;

        if (!notOnline)
        {
            var conversations = await _conversationDataStore.GetConversationsForUser(session.CurrentUser!.Id);
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
        await _conversationDataStore.Init(session.CurrentUser!, await _userDataStore.GetAllUsers());
        var conversations = await _conversationDataStore.GetConversationsForUser(session.CurrentUser!.Id);
        var sorted = conversations.OrderByDescending(c => c.LastMessage?.CreationDate);
        this.Conversations = new ObservableCollection<Conversation>(sorted);
    }
}