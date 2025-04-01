namespace FreeChat.Infrastructure.Navigation;

public static class NavigationExtensions
{
    
    public static MauiAppBuilder AddNavitation(this MauiAppBuilder builder)
    {
        builder.Services
            .AddSingleton<INavigationService, SimpleNavigationService>();
        return builder;
    }
}