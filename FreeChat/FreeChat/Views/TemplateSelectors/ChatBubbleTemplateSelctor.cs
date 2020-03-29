using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FreeChat.Views.TemplateSelectors
{
    public class ChatBubbleTemplateSelctor : DataTemplateSelector
    {
        public IEnumerable<Message> Messages { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            throw new NotImplementedException();
        }
    }
}
