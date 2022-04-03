using FreeChat.Views.Pages;

namespace FreeChat;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
