using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Views.Helpers
{
    static public class ViewHelpers
    {
        /// <summary>
        /// Scale a given view slightly. This is used to play a scale animation when view is tapped
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public static async Task PlayScale(this View view)
        {
            await view.PlayScale(0.99f, 1f);
        }
        public static async Task PlayScale(this View view, float start, float end)
        {
            await view.ScaleTo(start, 50, Easing.Linear);
            await Task.Delay(100);
            await view.ScaleTo(end, 50, Easing.Linear);
        }
    }
}
