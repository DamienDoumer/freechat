namespace FreeChat.Scenes.Shared;

public class BasePage: ContentPage
{
    public IViewModel ViewModel => (IViewModel)BindingContext;

    public BasePage()
    {
    }
        
    protected override void OnAppearing()
    {
        ViewModel?.InitializeCommand?.Execute(null);
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        ViewModel?.StopCommand?.Execute(null);
        base.OnDisappearing();
    }
}