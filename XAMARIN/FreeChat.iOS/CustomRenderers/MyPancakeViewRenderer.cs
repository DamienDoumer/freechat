using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using FreeChat.iOS.CustomRenderers;
using FreeChat.Views.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PancakeView.iOS;
using System.ComponentModel;

//[assembly: ExportRenderer(typeof(MyPancakeView), typeof(MyPancakeViewRenderer))]
namespace FreeChat.iOS.CustomRenderers
{
    public class MyPancakeViewRenderer : ViewRenderer<PancakeView, UIView>
    {
//TODO: Remove this later, this was a custom renderer to modifie the pancake view but with new releases of pancake view, it is kind of useless now
    }
}