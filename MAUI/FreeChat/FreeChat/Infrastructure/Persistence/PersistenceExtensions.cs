using FreeChat.Infrastructure.Persistence.FakeDataStores;

namespace FreeChat.Infrastructure.Persistence;

public static class PersistenceExtensions
{
    public static MauiAppBuilder AddPersistence(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<IConversationsDataStore, ConversationsDataStore>()
            .AddSingleton<IUsersDataStore, UsersDataStore>()
            .AddSingleton<IMessagesDataStore, MessagesDataStore>();
        return builder;
    }
}