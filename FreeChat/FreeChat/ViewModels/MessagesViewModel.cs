using FreeChat.Services;
using Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FreeChat.ViewModels
{
    [QueryProperty("ConversationId", "conversation_id")]
    public class MessagesViewModel : BaseViewModel
    {
        public string ConversationId { get; set; }
        Conversation _conversation;
        public Conversation CurrentConversation
        {
            get => _conversation;
            set => this.RaiseAndSetIfChanged(ref _conversation, value);
        }
        public ICommand SendMessageCommand { get; private set; }
        public ICommand MessageSwipped { get; private set; }
        Message _replyMessage;
        public Message ReplyMessage
        {
            get => _replyMessage;
            set => this.RaiseAndSetIfChanged(ref _replyMessage, value);
        }
        public ObservableCollection<Message> Messages { get; set; }

        private string _currentMessage;
        public string CurrentMessage
        {
            get { return _currentMessage; }
            set { this.RaiseAndSetIfChanged(ref _currentMessage, value); }
        }



        public MessagesViewModel(IDataStore<User> userDataStore, IConversationsDataStore convDataStore, 
            IMessageDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
        {
            MessageSwipped = ReactiveCommand.Create<Message>(MessageSwiped);
            SendMessageCommand = ReactiveCommand.CreateFromTask(SendMeessage);
        }

        public async override Task Initialize()
        {
            CurrentConversation = await _conversationDataStore.GetItemAsync(ConversationId);
            var messages = await _messageDataStore.GetMessagesForConversation(ConversationId);
            Messages = new ObservableCollection<Message>();
        }

        void MessageSwiped(Message message)
        {
            ReplyMessage = message;
        }

        async Task SendMeessage()
        {
            await Task.CompletedTask;
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
