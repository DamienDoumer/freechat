namespace FreeChat;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        SetTabBarIsVisible(this, false);
    }
}