using Models;

namespace FreeChat.Infrastructure.Persistence;

public interface IUsersDataStore: IDataStore<User>
{
    Task<User> GetCurrentUser();
    Task<List<User>> GetAllUsers();
}