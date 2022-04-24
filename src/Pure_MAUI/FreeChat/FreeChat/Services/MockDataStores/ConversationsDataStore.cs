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
        public List<Conversation> Conversation { get; private set; }

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

            Conversation = new List<Conversation>();

            foreach (var user in users)
            {
                int randomHours = new Random().Next(0, 24);
                Conversation.Add(new Conversation
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
            Conversation.OrderByDescending(c => c.LastMessage.CreationDate);
        }

        public Task<bool> AddItemAsync(Conversation item)
        {
            Conversation.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            var conversation = Conversation.Where(c => c.Id == id);
            if (!conversation.Any())
                return Task.FromResult(false);
            Conversation.Remove(conversation.FirstOrDefault());
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Conversation>> GetConversationsForUser(string userId)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return await Task.FromResult(Conversation.Where(c => c.UserIds[0] == userId));
        }

        public Task<Conversation> GetItemAsync(string id)
        {
            return Task.FromResult(Conversation.Where(c => c.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Conversation>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult((IEnumerable<Conversation>)Conversation);
        }

        public Task<bool> UpdateItemAsync(Conversation item)
        {
            var conv = Conversation.Where(c => c.Id == item.Id).FirstOrDefault();
            var i = Conversation.IndexOf(conv);
            Conversation[i] = conv;
            return Task.FromResult(true);
        }
    }
}
