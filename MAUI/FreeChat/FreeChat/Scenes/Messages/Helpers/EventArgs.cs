namespace FreeChat.Scenes.Messages.Helpers;

public class MyFocusEventArgs : EventArgs
{
    public bool IsFocused { get; set; }
}

public class ScrollToItemEventArgs : EventArgs
{
    public object Item { get; set; }
    public int? Index { get; set; }
}

public class KeyboardAppearEventArgs : EventArgs
{
    public float KeyboardSize { get; set; }

    public KeyboardAppearEventArgs()
    {
    }
}
