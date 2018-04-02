using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonValueConverters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = (Color)value;
            return new SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (SolidColorBrush)value;
            return b.Color;
        }
    }
}
