using FreeChat.Scenes.Conversations;

namespace FreeChat.Scenes;

public static class ScenesExtensions
{
    public static MauiAppBuilder AddScenes(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<ConversationsViewModel>();
        return builder;
    }
}