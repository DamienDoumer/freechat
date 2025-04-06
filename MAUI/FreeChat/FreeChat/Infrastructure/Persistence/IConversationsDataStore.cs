using Models;

namespace FreeChat.Infrastructure.Persistence;

public interface IConversationsDataStore : IDataStore<Conversation>
{
    Task<IEnumerable<Conversation>> GetConversationsForUser(string userId);
    public Task Init(User currentUser, List<User> users);
}