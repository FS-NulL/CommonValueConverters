using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonValueConverters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) return DependencyProperty.UnsetValue;

            bool b = (bool)value;

            if (b) return TrueColor;
            else return FalseColor;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color)) return DependencyProperty.UnsetValue;

            Color c = (Color)value;

            if (c == TrueColor) return true;
            else return false;
        }

        public Color TrueColor  { get; set; } = Colors.Red;
        public Color FalseColor { get; set; } = Colors.Black;
    }
}
