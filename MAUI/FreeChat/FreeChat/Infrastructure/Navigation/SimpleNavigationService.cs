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
        return Shell.Current.GoToAsync(route, true);
    }

    public Task GoToMessagesPage(string conversationId)
    {
        //NOTE: MAUI doesn't support:
        /*
         * Modal nav and
           shell:Shell.NavBarHasShadow="False"
           shell:Shell.NavBarIsVisible="False"
           
           Tried that and didn't work
         */
        var messagesPage = _services.GetRequiredService<MessagesPage>();
        (messagesPage.ViewModel as MessagesViewModel)!.ConversationId = conversationId;
        return Application.Current.MainPage.Navigation.PushModalAsync(messagesPage, true);
    }
}