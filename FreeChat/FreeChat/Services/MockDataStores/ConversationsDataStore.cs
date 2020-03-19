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
            _conversations = new List<Conversation>();
            foreach (var user in users)
            {
                _conversations.Add(new Conversation
                {
                    CreationDate = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    LastMessage = new Message
                    {
                        Content = "Hello, how are you ?",
                        ISent = true,
                        
                    },
                    Peer = user,
                    UserIds = new string[] { currentUser.Id, user.Id }
                });
            }
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
            await Task.Delay(TimeSpan.FromSeconds(2));
            return await Task.FromResult(_conversations.Where(c => c.UserIds[0] == userId));
        }

        public Task<Conversation> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Conversation>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult((IEnumerable<Conversation>)_conversations);
        }

        public Task<bool> UpdateItemAsync(Conversation item)
        {
            throw new NotImplementedException();
        }
    }
}
