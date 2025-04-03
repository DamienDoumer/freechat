using System.Globalization;
using FreeChat.Scenes.Conversations.Components;
using Models;

namespace FreeChat.Scenes.Conversations.Converters;

public class ConversationItemToViewModelConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var conversation = value as Conversation;
        var parentViewModel = parameter as ConversationsViewModel;
        
        if (conversation == null || parentViewModel == null)
            return null;
        
        return new ConversationItemViewModel(conversation, parentViewModel.NavigationService);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}