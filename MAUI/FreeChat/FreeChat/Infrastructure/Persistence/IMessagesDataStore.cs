using Models;

namespace FreeChat.Infrastructure.Persistence;

public interface IMessagesDataStore : IDataStore<Message>
{
    Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId);
    void Initialize(Conversation conversation);
}