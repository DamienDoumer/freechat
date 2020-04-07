using FreeChat.Resources;
using FreeChat.Services;
using FreeChat.ViewModels.Helpers;
using Humanizer;
using Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ICommand MessageSwippedCommand { get; private set; }
        public ICommand CancelReplyCommand { get; private set; }
        public ICommand ReplyMessageSelectedCommand { get; private set; }
        private bool _isTyping;

        public bool IsTyping
        {
            get { return _isTyping; }
            set { this.RaiseAndSetIfChanged(ref _isTyping, value); }
        }

        Message _replyMessage;
        public Message ReplyMessage
        {
            get => _replyMessage;
            set => this.RaiseAndSetIfChanged(ref _replyMessage, value);
        }
        ObservableCollection<MessagesGroup> _messagesGroups;
        public ObservableCollection<MessagesGroup> Messages
        {
            get => _messagesGroups;
            set => this.RaiseAndSetIfChanged(ref _messagesGroups, value);
        }
        private List<Message> _messages;

        private string _currentMessage;
        public string CurrentMessage
        {
            get { return _currentMessage; }
            set { this.RaiseAndSetIfChanged(ref _currentMessage, value); }
        }

        public MessagesViewModel(IDataStore<User> userDataStore, IConversationsDataStore convDataStore, 
            IMessageDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
        {
            ReplyMessageSelectedCommand = ReactiveCommand.Create<Message>(ReplyMessageSelected);
            MessageSwippedCommand = ReactiveCommand.Create<Message>(MessageSwiped);
            SendMessageCommand = ReactiveCommand.CreateFromTask(SendMeessage, this.WhenAnyValue(vm => vm.CurrentMessage, curm => !String.IsNullOrEmpty(curm)));
            CancelReplyCommand = ReactiveCommand.Create(CancelReply);
            _messages = new List<Message>();
        }

        public void CancelReply()
        {
            ReplyMessage = null;
        }

        private void ReplyMessageSelected(Message message)
        {

        }

        public async override Task Initialize()
        {
            CurrentConversation = await _conversationDataStore.GetItemAsync(ConversationId);
            var messages = await _messageDataStore.GetMessagesForConversation(ConversationId);

            _messages.AddRange(messages);
            var messagesGroups = _messages.GroupBy(m => m.CreationDate.Day)
                .Select(grp => 
                {
                    var messagesGrp = grp.ToList().OrderBy(m => m.CreationDate);
                    var msg = messagesGrp.First();
                    var date = msg.CreationDate.Date;
                    var dayDiff = DateTime.Now.Day - date.Day;
                    string groupHeader = string.Empty;

                    if (dayDiff == 0)
                        groupHeader = TextResources.Today;
                    else if (dayDiff == 1)
                        groupHeader = TextResources.Yesterday;
                    else groupHeader = date.ToString("MM-dd-yyyy");

                    return new MessagesGroup
                    (
                        dateTime : date,
                        groupHeader : groupHeader,
                        messages : new ObservableCollection<Message>(messagesGrp)
                    );
                })
                .OrderBy(m => m.DateTime.Day)
                .ToList();

            Messages = new ObservableCollection<MessagesGroup>(messagesGroups);
        }

        void MessageSwiped(Message message)
        {
            ReplyMessage = message;
        }

        async Task SendMeessage()
        {
            var message = new Message
            {
                Content = CurrentMessage,
                ReplyTo = ReplyMessage,
                CreationDate = DateTime.Now,
                Sender = AppLocator.CurrentUser,
                ISentPreviousMessage = (bool) Messages?.Last()?.Last()?.ISent,
                ISent = true,
                ConversationId = CurrentConversation.Id,
                SenderId = AppLocator.CurrentUserId
            };
            CurrentMessage = string.Empty;
            Messages.Last().Add(message);
            ReplyMessage = null;
            await _messageDataStore.AddItemAsync(message);
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }

        public async Task FakeMessaging()
        {
            var shouldReply = new Random().Next(0, 1) == 1 ? true : false;

            if (shouldReply)
            {
                IsTyping = true;
                await Task.Delay(TimeSpan.FromSeconds(2));
                var message = new Message
                {
                    Content = "Hey here is a simple rely.",
                    CreationDate = DateTime.Now,
                    Sender = CurrentConversation.Peer,
                    ISentPreviousMessage = Messages.Last().Last().ISent,
                    ISent = false,
                    ConversationId = CurrentConversation.Id,
                    SenderId = CurrentConversation.Peer.Id
                };
                Messages.Last().Add(message);

                IsTyping = false;
                Messages.Last().Add(message);
                await _messageDataStore.AddItemAsync(message);
            }
        }
    }
}
