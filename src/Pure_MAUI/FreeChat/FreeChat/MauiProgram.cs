using Android.Content.Res;
using FreeChat.Views.CustomControls;
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
			});

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
}
