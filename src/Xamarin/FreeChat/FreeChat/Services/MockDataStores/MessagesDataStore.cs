using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services.MockDataStores
{
    public class MessagesDataStore : IMessageDataStore
    {
        readonly List<Message> _messages;

        public MessagesDataStore(Conversation conversation)
        {
            _messages = new List<Message>();

            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "I was at your office yesterday.",
                CreationDate = DateTime.Now - TimeSpan.FromDays(1),
                ISent = false,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                Content = "Ooh really ?",
                CreationDate = DateTime.Now - TimeSpan.FromDays(1),
                ISent = true,
                SenderId = conversation.UserIds[0],
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                ISentPreviousMessage = true,
                Content = "Yeah. But you were not arround",
                CreationDate = DateTime.Now - TimeSpan.FromMinutes(5),
                ISent = false,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                ISentPreviousMessage = false,
                Content = "Yeah I was not arround I left early yesterday",
                CreationDate = DateTime.Now - TimeSpan.FromMinutes(2),
                ISent = true,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer,
                ReplyTo = _messages[_messages.Count - 3]
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                ISentPreviousMessage = true,
                Content = "I sent this message",
                CreationDate = DateTime.Now - TimeSpan.FromMinutes(1),
                ISent = true,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer,
                ReplyTo = _messages[_messages.Count - 2]
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                ISentPreviousMessage = true,
                Content = "I called you, and I left you a message did you see it ?",
                CreationDate = DateTime.Now - TimeSpan.FromMinutes(1),
                ISent = false,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer,
                ReplyTo = _messages[_messages.Count - 2]
            });
            _messages.Add(new Message
            {
                ConversationId = conversation.Id,
                Id = Guid.NewGuid().ToString(),
                ISentPreviousMessage = false,
                Content = "I called you, and I left you a message did you see it ?",
                CreationDate = DateTime.Now ,
                ISent = false,
                SenderId = conversation.Peer.Id,
                Sender = conversation.Peer,
                ReplyTo = _messages[_messages.Count - 2]
            });
            conversation.LastMessage = _messages.Last();
        }

        public Task<bool> AddItemAsync(Message item)
        {
            item.Id = Guid.NewGuid().ToString();
            _messages.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId)
        {
            return Task.FromResult(_messages.Where(m => m.ConversationId == conversationId));
        }

        public Task<bool> UpdateItemAsync(Message item)
        {
            throw new NotImplementedException();
        }
    }
}
