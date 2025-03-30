using FreeChat.Scenes.Conversations;
using FreeChat.Scenes.Messages;

namespace FreeChat;

public static class CustomHandlers
{
    public static MauiAppBuilder UseCustomHandlers(this MauiAppBuilder builder)
    {
        return builder
                .UseBorderlessEntryHandler()
                .UseBorderlessEditorHandler();
    }
    
    private static MauiAppBuilder UseBorderlessEntryHandler(this MauiAppBuilder builder)
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), 
            (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if ANDROID
        handler.PlatformView.Background = null;
        handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif IOS
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
        handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
            }
        });
    
        return builder;
    }
    
    private static MauiAppBuilder UseBorderlessEditorHandler(this MauiAppBuilder builder)
    {
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), 
            (handler, view) =>
            {
                if (view is BorderlessEditor)
                {
#if IOS
                    handler.PlatformView.Layer.BorderWidth = 0;
#elif ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
                }
            });
    
        return builder;
    }
}