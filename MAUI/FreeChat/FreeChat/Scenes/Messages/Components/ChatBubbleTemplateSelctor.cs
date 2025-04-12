using Models;

namespace FreeChat.Scenes.Messages.Components;

public class ChatBubbleTemplateSelctor: DataTemplateSelector
{
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var message = item as Message;
        
        if (message is null)
            throw new NullReferenceException("Message is null");

        if (message.ISent)
        {
            var messageTemplate = new MesageISentTemplate();
            messageTemplate.ParentContext = container.BindingContext;
            return new DataTemplate(() => messageTemplate);
        }
        else
        {
            var messageTemplate = new MessagePeerSentTemplate();
            messageTemplate.ParentContext = container.BindingContext;
            return new DataTemplate(() => messageTemplate);
        }
    }
}