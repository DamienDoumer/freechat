using FreeChat.Services;
using Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeChat.ViewModels
{
    public class ConversationsViewModel : BaseViewModel
    {
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
            IMessageDataStore messageDataStore) 
            : base(userDataStore, convDataStore, messageDataStore)
        {
            ConversationSelectedCommand = ReactiveCommand.CreateFromTask<Conversation>(ConversationSelected);
            FilterOptionChangedCommand = ReactiveCommand.CreateFromTask<bool>(FilterOptionChanged);
        }

        Task ConversationSelected(Conversation conversation)
        {
            return Task.CompletedTask;
        }

        Task FilterOptionChanged(bool isOnline)
        {
            return Task.CompletedTask;
        }

        public override async Task Initialize()
        {
            IsBusy = true;

            var conversations = await _conversationDataStore.GetConversationsForUser(AppLocator.CurrentUserId);
            Conversations = new ObservableCollection<Conversation>(conversations);

            IsBusy = false;
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
