using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(FreeChat.iOS.Effects.iOSSafeAreaInsetEffect), nameof(FreeChat.iOS.Effects.iOSSafeAreaInsetEffect))]
namespace FreeChat.iOS.Effects
{
    public class iOSSafeAreaInsetEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Element is Layout element)
            {
                //returns the appropriate safe area taking into consideration iOS versions.
                var safeArea = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets;
                element.Margin = new Thickness(0, 0, 0, - safeArea.Bottom);
            }
        }

        protected override void OnDetached()
        {
            if (Element is Layout element)
            {
                element.Margin = new Thickness();
            }
        }
    }
}