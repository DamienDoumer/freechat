using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
                fonts.AddFont("Font Awesome 5 Brands-Regular-400.otf", "FontAwesomeBrandsRegular");
                fonts.AddFont("Font Awesome 5 Free-Solid-900.otf", "FontAwesome");
                fonts.AddFont("Quicksand-Light.ttf", "QuickSandLight");
                fonts.AddFont("Quicksand-Bold.ttf", "QuickSandBold");
                fonts.AddFont("Quicksand-Regular.ttf", "QuickSandRegular");
            })
            .UseMauiCommunityToolkit()
            .UseCustomHandlers();
        
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}