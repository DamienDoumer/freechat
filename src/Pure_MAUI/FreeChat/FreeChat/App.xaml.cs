using FreeChat.Views.Pages;
using FreeChat.Views.Styles;

namespace FreeChat;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
