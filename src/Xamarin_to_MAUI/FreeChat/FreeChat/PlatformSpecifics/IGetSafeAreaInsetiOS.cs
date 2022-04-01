using System;
using Xamarin.Forms;

namespace FreeChat.PlatformSpecifics
{
    public interface IGetSafeAreaInsetiOS
    {
        Thickness GetSafeInset();
    }
}
