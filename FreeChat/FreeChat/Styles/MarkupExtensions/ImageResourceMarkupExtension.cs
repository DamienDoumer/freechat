using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Styles.MarkupExtensions
{
    public class ImageResourceMarkupExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            var imageSrc = ImageSource.FromResource(Source, typeof(ImageResourceMarkupExtension).GetTypeInfo().Assembly);
            return imageSrc;
        }
    }
}
