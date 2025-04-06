using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FreeChat.Infrastructure.Persistence;
using FreeChat.Resources;
using FreeChat.Scenes.Messages.Helpers;
using FreeChat.Scenes.Shared;
using Models;

namespace FreeChat.Scenes.Messages;

[QueryProperty("ConversationId", "conversation_id")]
public partial class MessagesViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _conversationId;
    [ObservableProperty]
    private bool _isTyping;
    [ObservableProperty]
    Message _replyMessage;
    [ObservableProperty]
    ObservableCollection<MessagesGroup> _messages;
    [ObservableProperty]
    Conversation _currentConversation;
    private List<Message> _messagesInternal;
    [ObservableProperty]
    string _currentMessage;
    Session _session;
    
    public MessagesViewModel(IUsersDataStore userDataStore,
        IConversationsDataStore convDataStore, Session session,
        IMessagesDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
    {
        _session = session;
        _messagesInternal = new List<Message>();
    }

    protected override async Task OnInitialize()
    {
        CurrentConversation = await _conversationDataStore.GetItemAsync(ConversationId);
        var messages = await _messageDataStore.GetMessagesForConversation(ConversationId);

        _messagesInternal.AddRange(messages);
        var messagesGroups = _messagesInternal.GroupBy(m => m.CreationDate.Day)
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

        await Task.Delay(TimeSpan.FromSeconds(1));
        this.Messages = new ObservableCollection<MessagesGroup>(messagesGroups);

        //await Task.Delay(TimeSpan.FromSeconds(0.5));
        if (Messages.Any())
            ScrollToMessage(this.Messages?.Last()?.Last());
    }

    protected override Task OnStop()
    {
        return Task.CompletedTask;
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    void MessageSwiped(Message message)
    {
        ReplyMessage = message;
        WeakReferenceMessenger.Default.Send(new MyFocusEventArgs { IsFocused = true });
    }

    void ScrollToMessage(Message message)
    {
        WeakReferenceMessenger.Default.Send(new ScrollToItemEventArgs { Item = message });
    }

    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    private async Task SendMessage()
    {
        var message = new Message
        {
            Content = CurrentMessage,
            ReplyTo = ReplyMessage,
            CreationDate = DateTime.Now,
            Sender = _session.CurrentUser,
            ISentPreviousMessage = (bool)Messages?.Last()?.Last()?.ISent,
            ISent = true,
            ConversationId = CurrentConversation.Id,
            SenderId = _session.CurrentUser!.Id,
        };

        CurrentConversation.LastMessage = message;
        await _conversationDataStore.UpdateItemAsync(CurrentConversation);
        CurrentMessage = string.Empty;
        Messages!.Last().Add(message);
        ReplyMessage = null;
        await _messageDataStore.AddItemAsync(message);
        CurrentConversation.LastMessage = message;
        ScrollToMessage(message);
        await FakeMessaging();
    }
    
    [RelayCommand(CanExecute = nameof(CanExecuteCommandsWhenNotBusy))]
    public void CancelReply()
    {
        ReplyMessage = null;
        WeakReferenceMessenger.Default.Send(new MyFocusEventArgs { IsFocused = false });
    }
    
    public async Task FakeMessaging()
    {
        //var shouldReply = new Random().Next(0, 3) > 0 ? true : false;
        
        var shouldReply = true;

        if (shouldReply)
        {
            ScrollToMessage(Messages.Last().Last());
            IsTyping = true;
            await Task.Delay(TimeSpan.FromSeconds(3));
            var message = new Message
            {
                Content = "Hey here is a simple reply.",
                CreationDate = DateTime.Now,
                Sender = CurrentConversation.Peer,
                //ISentPreviousMessage = Messages.Last().Last().ISent,
                ISent = false,
                ConversationId = CurrentConversation.Id,
                SenderId = CurrentConversation.Peer.Id
            };
            Messages.Last().Add(message);
            CurrentConversation.LastMessage = message;
            await _conversationDataStore.UpdateItemAsync(CurrentConversation);

            IsTyping = false;
            ScrollToMessage(message);
            await _messageDataStore.AddItemAsync(message);
        }
    }
}

public class MessagesGroup : ObservableCollection<Message>
{
    public string GroupHeader { get; set; }
    public DateTime DateTime { get; set; }

    public MessagesGroup(DateTime dateTime, string groupHeader, IEnumerable<Message> messages): base(messages)
    {
        DateTime = dateTime;
        GroupHeader = groupHeader;
    }
}

