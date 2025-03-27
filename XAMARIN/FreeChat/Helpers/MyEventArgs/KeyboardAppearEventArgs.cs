using System;
namespace FreeChat.Helpers.MyEventArgs
{
    public class KeyboardAppearEventArgs : EventArgs
    {
        public float KeyboardSize { get; set; }

        public KeyboardAppearEventArgs()
        {
        }
    }
}
