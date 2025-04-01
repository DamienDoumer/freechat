using System.Diagnostics;

namespace FreeChat;

public partial class App : Application
{
    Session _session;
    public App(Session session)
    {
        _session = session;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override void OnStart()
    {
        base.OnStart();
        Initialize(_session);
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