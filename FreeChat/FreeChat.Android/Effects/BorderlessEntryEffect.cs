using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("FreeChat")]
[assembly: ExportEffect(typeof(FreeChat.Droid.Effects.BorderlessEntryEffect), nameof(FreeChat.Droid.Effects.BorderlessEntryEffect))]
namespace FreeChat.Droid.Effects
{
    public class BorderlessEntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.Background = null;
        }

        protected override void OnDetached()
        {
        }
    }
}