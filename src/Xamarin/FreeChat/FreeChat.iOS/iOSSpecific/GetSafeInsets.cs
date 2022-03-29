using System;
using FreeChat.iOS.iOSSpecific;
using FreeChat.PlatformSpecifics;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(
   typeof(GetSafeInsets))]
namespace FreeChat.iOS.iOSSpecific
{
    public class GetSafeInsets : IGetSafeAreaInsetiOS
    {
        public Thickness GetSafeInset()
        {
            var safeArea = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets;
            return new Thickness(safeArea.Left, safeArea.Top, safeArea.Right, safeArea.Bottom);
        }
    }
}
