using System.Globalization;

namespace FreeChat.Scenes.Converters;

public class IsNullConverter: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool returenedValue = string.IsNullOrEmpty(value?.ToString()) && value == null;
        return !returenedValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}