using FreeChat.Services;
using FreeChat.Services.Navigation;
using Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeChat.ViewModels
{
    public class ConversationsViewModel : BaseViewModel
    {
        INavigationService _navigationService;
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { this.RaiseAndSetIfChanged(ref _searchText, value); }
        }

        private ObservableCollection<Conversation> _conversations;
        public ObservableCollection<Conversation> Conversations
        {
            get { return _conversations; }
            set { this.RaiseAndSetIfChanged(ref _conversations, value); }
        }

        public ICommand ConversationSelectedCommand { get; private set; }
        public ICommand FilterOptionChangedCommand { get; private set; }

        public ConversationsViewModel(IDataStore<User> userDataStore, IConversationsDataStore convDataStore, 
            IMessageDataStore messageDataStore, INavigationService navigationService) 
            : base(userDataStore, convDataStore, messageDataStore)
        {
            _navigationService = navigationService;
            ConversationSelectedCommand = ReactiveCommand.CreateFromTask<Conversation>(ConversationSelected);
            FilterOptionChangedCommand = ReactiveCommand.CreateFromTask<bool>(FilterOptionChanged, _notBusyObservable);
        }

        Task ConversationSelected(Conversation conversation)
        {
            return _navigationService.GotoPage($"{Constants.MessagesPageUrl}?conversation_id={conversation.Id}");
        }

        async Task FilterOptionChanged(bool notOnline)
        {
            IsBusy = true;
            if (!notOnline)
            {
                var conversations = await _conversationDataStore.GetConversationsForUser(AppLocator.CurrentUserId);
                Conversations = new ObservableCollection<Conversation>(conversations.Where(c => c.Peer.IsOnline));
            }
            else
            {
                await LoadConversations();
            }
            IsBusy = false;
        }

        public override async Task Initialize()
        {
            IsBusy = true;
            await LoadConversations();
            IsBusy = false;
        }

        async Task LoadConversations()
        {
            var conversations = await _conversationDataStore.GetConversationsForUser(AppLocator.CurrentUserId);
            conversations = conversations.OrderByDescending(c => c.LastMessage.CreationDate);
            Conversations = new ObservableCollection<Conversation>(conversations);
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
