namespace FreeChat;

public static class MauiProgram
{
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

		return builder.Build();
	}
}
