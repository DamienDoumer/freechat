namespace FreeChat.Infrastructure.Navigation;

public interface INavigationService
{
    Task GotoPage(string route);
}