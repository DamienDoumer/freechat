using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("FreeChat")]
[assembly: ExportEffect(typeof(FreeChat.iOS.Effects.BorderlessEntryEffect), nameof(FreeChat.iOS.Effects.BorderlessEntryEffect))]
namespace FreeChat.iOS.Effects
{
    class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.Layer.BorderWidth = 0;
            (Control as UITextField).BorderStyle = UITextBorderStyle.None;
        }

        protected override void OnDetached()
        {
        }
    }
}