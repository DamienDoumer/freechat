using Models;

namespace FreeChat.Infrastructure.Persistence;

public interface IMessagesDataStore
{
    Task<IEnumerable<Message>> GetMessagesForConversation(string conversationId);
    void Initialize(Conversation conversation);
}