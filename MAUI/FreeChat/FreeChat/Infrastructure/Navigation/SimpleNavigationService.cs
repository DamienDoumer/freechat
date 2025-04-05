using FreeChat.Scenes.Messages;

namespace FreeChat.Infrastructure.Navigation;

public class SimpleNavigationService: INavigationService
{
    private readonly IServiceProvider _services;

    public SimpleNavigationService(IServiceProvider services)
    {
        _services = services;
    }

    public Task GotoPage(string route)
    {
        return Shell.Current.GoToAsync(route);
    }
}