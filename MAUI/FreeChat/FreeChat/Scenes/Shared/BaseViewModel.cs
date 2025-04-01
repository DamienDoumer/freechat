using System.Windows.Input;
using FreeChat.Infrastructure.Persistence;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace FreeChat.Scenes.Shared;

public abstract partial class BaseViewModel : ObservableObject, IViewModel
{
    [ObservableProperty]
    private bool _isBusy;

    protected readonly IUsersDataStore _userDataStore;
    protected readonly IMessagesDataStore _messageDataStore;
    protected readonly IConversationsDataStore _conversationDataStore;

    public ICommand InitializeCommand { get; set; }
    public ICommand StopCommand { get; set; }
    
    protected BaseViewModel(
        IUsersDataStore userDataStore,
        IConversationsDataStore convDataStore,
        IMessagesDataStore messageDataStore)
    {
        _userDataStore = userDataStore;
        _conversationDataStore = convDataStore;
        _messageDataStore = messageDataStore;
        
        var notBusyDelegate = () => !_isBusy;
        InitializeCommand = new AsyncRelayCommand(Initialize, notBusyDelegate);
        StopCommand = new AsyncRelayCommand(Stop, notBusyDelegate);
    }

    /// <summary>
    /// Override to handle view model setup
    /// </summary>
    private async Task Initialize()
    {
        IsBusy = true;
        await OnInitialize();
        IsBusy = false;
    }

    protected abstract Task OnInitialize();

    /// <summary>
    /// Override to handle teardown / cleanup
    /// </summary>
    private async Task Stop()
    {
        IsBusy = true;
        await OnStop();
        IsBusy = false;
    }
    
    protected abstract Task OnStop();
}

public interface IViewModel
{
    ICommand InitializeCommand { get; protected set; }
    ICommand StopCommand { get; protected set; }
}