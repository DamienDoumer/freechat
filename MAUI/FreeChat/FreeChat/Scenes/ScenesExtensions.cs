using FreeChat.Scenes.Conversations;
using FreeChat.Scenes.Messages;

namespace FreeChat.Scenes;

public static class ScenesExtensions
{
    public static MauiAppBuilder AddScenes(this MauiAppBuilder builder)
    {
        builder.Services
            .AddTransient<MessagesPage>()
            .AddTransient<MessagesViewModel>()
            .AddSingleton<ConversationsViewModel>();
        
        return builder;
    }
}