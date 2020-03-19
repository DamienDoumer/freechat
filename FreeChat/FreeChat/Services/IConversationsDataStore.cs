using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services
{
    public interface IConversationsDataStore : IDataStore<Conversation>
    {
        Task<IEnumerable<Conversation>> GetConversationsForUser(string userId);
    }
}
