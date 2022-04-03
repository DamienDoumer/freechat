using System.Globalization;
using System.Reflection;

namespace FreeChat.Styles.ValueConverters
{
    public class ImageResourceValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value as string == null)
                return null;

            var imageSrc = ImageSource.FromResource($"FreeChat.Resources.Images.{value.ToString()}", typeof(ImageResourceValueConverter).GetTypeInfo().Assembly);
            return imageSrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
