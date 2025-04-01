using System.Diagnostics;

namespace FreeChat;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
    
    private async void InitializeAsyncSafe(Session session)
    {
        try
        {
            await session.InitializeAsync();
        }
        catch (Exception ex)
        {
            // log or handle
            Debug.WriteLine($"[Init Error] {ex.Message}");
        }
    }
}