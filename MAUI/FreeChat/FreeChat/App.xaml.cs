using System.Diagnostics;

namespace FreeChat;

public partial class App : Application
{
    Session _session;
    public App(Session session)
    {
        _session = session;
        InitializeComponent();
#if ANDROID
        Initialize(_session);
#endif
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override void OnStart()
    {
        base.OnStart();
#if IOS
        Initialize(_session);
#endif
    }

    private async void Initialize(Session session)
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