using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services
{
    public interface IMessageDataStore : IDataStore<Message>
    {
        Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId);
    }
}
