using System.Globalization;
using Humanizer;

namespace FreeChat.Scenes.Converters;

public class DateToHumanFormConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var date = (DateTime)value;

        if (date == null)
            return null;

        return date.Humanize(false);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}