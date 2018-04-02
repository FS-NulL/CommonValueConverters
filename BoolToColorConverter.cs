using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonValueConverters
{
    class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) throw new InvalidCastException("BoolToColorConverter.Convert: Value must be a bool.");

            bool b = (bool)value;

            if (b) return TrueColor;
            else return FalseColor;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Color)) throw new InvalidCastException("BoolToColorConverter.Convert: Value must be a Color.");

            Color c = (Color)value;

            if (c == TrueColor) return true;
            else return false;
        }

        public Color TrueColor  { get; set; } = Colors.Red;
        public Color FalseColor { get; set; } = Colors.Black;
    }
}
