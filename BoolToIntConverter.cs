using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CommonValueConverters
{
    public class BoolToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) return DependencyProperty.UnsetValue;

            bool b = (bool)value;

            if (b) return TrueValue;
            else return FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int)) return DependencyProperty.UnsetValue;

            int c = (int)value;

            if (c == TrueValue) return true;
            else return false;
        }

        public int TrueValue  { get; set; } = 1;
        public int FalseValue { get; set; } = 0;
    }
}
