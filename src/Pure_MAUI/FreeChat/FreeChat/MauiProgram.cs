using Android.Content.Res;
using FreeChat.Services;
using FreeChat.Services.MockDataStores;
using FreeChat.Services.Navigation;
using FreeChat.ViewModels;
using FreeChat.Views.CustomControls;
using FreeChat.Views.Pages;
using Microsoft.Maui.Platform;
using Models;

namespace FreeChat;

public static class MauiProgram
{
	public static string CurrentUserId { get; set; }
	public static User CurrentUser { get; set; }

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Quicksand-Regular.ttf", "QuickSandRegular");
				fonts.AddFont("Quicksand-Light.ttf", "QuickSandLight");
				fonts.AddFont("Quicksand-Bold.ttf", "QuickSandBold");
				fonts.AddFont("Font Awesome 5 Brands-Regular-400.otf", "FontAwesomeBrandsRegular");
				fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "FontAwesome");
			})
			.RegisterViewModels()
			.RegisterPages()
			.RegisterServices();


		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(IView.Background), (handler, view) =>
		{
			if (view is BorderlessEntry)
			{
#if ANDROID
				handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS
                  handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
			}
		});

		return builder.Build();
	}

	static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
    {
		builder.Services.AddTransient<ConversationsPage>();
		builder.Services.AddTransient<SettingsPage>();
		builder.Services.AddTransient<MessagesPage>();

		return builder;
	}
		
	static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
		builder.Services.AddTransient<INavigationService, SimpleNavigationService>();
		var store = new UserDataStores();
		builder.Services.AddSingleton<IDataStore<User>>(store);
		var convo = new ConversationsDataStore(store.Users.Last(), new List<User>(store.Users));
		builder.Services.AddSingleton<IConversationsDataStore>(convo);
		builder.Services.AddSingleton<IMessageDataStore>(new MessagesDataStore(convo.Conversation.First()));

		CurrentUser = store.Users.Last();
		CurrentUserId = CurrentUser.Id;

		return builder;
	}

	static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
		builder.Services.AddTransient<ConversationsViewModel>();
		builder.Services.AddTransient<MessagesViewModel>();
		builder.Services.AddTransient<SettingsViewModel>();

		return builder;
    }
}
