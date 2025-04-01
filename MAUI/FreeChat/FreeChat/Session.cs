using FreeChat.Infrastructure.Persistence;
using Models;

namespace FreeChat;

public class Session
{
    IUsersDataStore _usersDataStore;
    public User? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;

    public Session(IUsersDataStore usersDataStore)
    {
        _usersDataStore = usersDataStore;
    }
    
    public void ClearUser()
    {
        CurrentUser = null;
    }

    public async Task InitializeAsync()
    {
        CurrentUser = await _usersDataStore.GetCurrentUser();
    }
}