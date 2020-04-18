using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(FreeChat.iOS.Effects.BorderlessEditorEffect), nameof(FreeChat.iOS.Effects.BorderlessEditorEffect))]
namespace FreeChat.iOS.Effects
{
    public class BorderlessEditorEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            Control.Layer.BorderWidth = 0;
        }

        protected override void OnDetached()
        {
        }
    }
}
