namespace FreeChat.Infrastructure.Navigation;

public class SimpleNavigationService: INavigationService
{
    public Task GotoPage(string route)
    {
        return Shell.Current.GoToAsync(route);
    }
}