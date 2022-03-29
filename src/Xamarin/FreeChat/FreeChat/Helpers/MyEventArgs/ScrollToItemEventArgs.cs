using System;
using System.Collections.Generic;
using System.Text;

namespace FreeChat.Helpers.MyEventArgs
{
    public class ScrollToItemEventArgs : EventArgs
    {
        public object Item { get; set; }
        public int? Index { get; set; }
    }
}
