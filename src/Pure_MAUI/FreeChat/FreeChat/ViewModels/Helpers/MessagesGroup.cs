using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FreeChat.ViewModels.Helpers
{
    public class MessagesGroup : ObservableCollection<Message>
    {
        public string GroupHeader { get; set; }
        public DateTime DateTime { get; set; }

        public MessagesGroup(DateTime dateTime, string groupHeader, IEnumerable<Message> messages): base(messages)
        {
            DateTime = dateTime;
            GroupHeader = groupHeader;
        }
    }
}
