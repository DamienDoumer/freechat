using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FreeChat.Views.Effects
{
    public class BorderlessEntryEffect : RoutingEffect
    {
        public BorderlessEntryEffect() : 
            base($"FreeChat.{nameof(BorderlessEntryEffect)}")
        {
        }
    }
}
