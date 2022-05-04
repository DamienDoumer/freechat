using FreeChat.Views.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Views.Behaviors
{
    public class ScaleViewOnTapBehavior : Behavior<View>
    {
        TapGestureRecognizer _tapGestureRecognizer;

        protected override void OnAttachedTo(View view)
        {
            _tapGestureRecognizer = new TapGestureRecognizer();
            _tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            view.GestureRecognizers.Add(_tapGestureRecognizer);
            base.OnAttachedTo(view);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view = ((View)sender);
            await view.PlayScale(0.99f, 1f);
        }

        protected override void OnDetachingFrom(View view)
        {
            _tapGestureRecognizer.Tapped -= TapGestureRecognizer_Tapped;
            view.GestureRecognizers.Remove(_tapGestureRecognizer);
            base.OnDetachingFrom(view);
        }
    }
}
