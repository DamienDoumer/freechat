using FreeChat.Scenes.Messages;

namespace FreeChat;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        SetTabBarIsVisible(this, false);
        Routing.RegisterRoute(Routes.MessagesRoute, typeof(MessagesPage));
    }
}