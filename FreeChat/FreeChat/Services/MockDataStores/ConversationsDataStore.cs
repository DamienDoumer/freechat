using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services.MockDataStores
{
    public class ConversationsDataStore : IConversationsDataStore
    {
        readonly List<Conversation> _conversations;

        public ConversationsDataStore(User currentUser, List<User> users)
        {
            var msgs = new string[]
            {
                "Hi, am ok and you ?",
                "Hi, what's up ?", 
                "I was aware of that",
                "Get up.",
                "Hello how are you ?"
            };

            _conversations = new List<Conversation>();

            foreach (var user in users)
            {
                int randomHours = new Random().Next(0, 24);
                _conversations.Add(new Conversation
                {
                    Id = Guid.NewGuid().ToString(),
                    LastMessage = new Message
                    {
                        Content = msgs[new Random().Next(0, msgs.Length - 1)],
                        ISent = true,
                        CreationDate = DateTime.UtcNow - TimeSpan.FromHours(randomHours),
                        Sender = user
                    },
                    Peer = user,
                    UserIds = new string[] { currentUser.Id, user.Id }
                });
            }
            _conversations.OrderByDescending(c => c.LastMessage.CreationDate);
        }

        public Task<bool> AddItemAsync(Conversation item)
        {
            _conversations.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            var conversation = _conversations.Where(c => c.Id == id);
            if (!conversation.Any())
                return Task.FromResult(false);
            _conversations.Remove(conversation.FirstOrDefault());
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Conversation>> GetConversationsForUser(string userId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return await Task.FromResult(_conversations.Where(c => c.UserIds[0] == userId));
        }

        public Task<Conversation> GetItemAsync(string id)
        {
            return Task.FromResult(_conversations.Where(c => c.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Conversation>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult((IEnumerable<Conversation>)_conversations);
        }

        public Task<bool> UpdateItemAsync(Conversation item)
        {
            var conv = _conversations.Where(c => c.Id == item.Id).FirstOrDefault();
            var i = _conversations.IndexOf(conv);
            _conversations[i] = conv;
            return Task.FromResult(true);
        }
    }
}
