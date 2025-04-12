namespace FreeChat.Infrastructure.Navigation;

public interface INavigationService
{
    Task GotoPage(string route);
    Task GoToMessagesPage(string conversationId);
}