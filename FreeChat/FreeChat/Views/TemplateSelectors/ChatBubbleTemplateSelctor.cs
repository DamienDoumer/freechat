using FreeChat.ViewModels.Helpers;
using FreeChat.Views.DataTemplates;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FreeChat.Views.TemplateSelectors
{
    public class ChatBubbleTemplateSelctor : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var message = item as Message;

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
}
