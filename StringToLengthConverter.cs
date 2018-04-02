using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CommonValueConverters
{
    public class StringToLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            string s = (string)value;

            if (string.IsNullOrEmpty(s)) return 0;
            else return s.Length;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Note: One way by design
            throw new NotImplementedException();
        }
    }
}
