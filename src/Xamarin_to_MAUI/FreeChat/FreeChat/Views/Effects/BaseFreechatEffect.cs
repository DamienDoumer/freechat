using System;
using Xamarin.Forms;

namespace FreeChat.Views.Effects
{
    public class BaseFreechatEffect : RoutingEffect
    {
        public BaseFreechatEffect(string name) :
            base($"FreeChat.{name}")
        {
        }
    }
}
