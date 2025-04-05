using Models;

namespace FreeChat.Scenes.Conversations.Components;

public partial class ConversationItemView : ContentView
{
    public static readonly BindableProperty ConversationProperty =
        BindableProperty.Create(
            nameof(Conversation),
            typeof(Conversation),
            typeof(ConversationItemView),
            propertyChanged: OnConversationChanged);

    public Conversation Conversation
    {
        get => (Conversation)GetValue(ConversationProperty);
        set => SetValue(ConversationProperty, value);
    }

    private static void OnConversationChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is ConversationItemView view && newValue is Conversation conv)
        {
            view.BindingContext = new ConversationItemViewModel(conv);
        }
    }
    
    public ConversationItemView()
    {
        InitializeComponent();
    }
}