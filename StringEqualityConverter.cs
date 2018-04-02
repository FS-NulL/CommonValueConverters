using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace CommonValueConverters
{
    public class StringEqualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return DependencyProperty.UnsetValue;
            if (!(parameter is string)) return DependencyProperty.UnsetValue;
            if (!(value is string)) return DependencyProperty.UnsetValue;

            string s = (string)value;

            if (s == null) return false;

            if (s == (string)parameter) return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
