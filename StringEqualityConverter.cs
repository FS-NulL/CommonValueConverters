using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace CommonValueConverters
{
    class StringEqualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return DependencyProperty.UnsetValue;
            if (!(parameter is string)) return DependencyProperty.UnsetValue;
            if (!(value is string)) return DependencyProperty.UnsetValue;

            string s = (string)value;

            if (string.IsNullOrEmpty(s)) return false;

            if (s == (string)parameter) return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) return DependencyProperty.UnsetValue;
            if (!(parameter is string)) return DependencyProperty.UnsetValue;
            if (!(value is bool)) return DependencyProperty.UnsetValue;

            bool b = (bool)value;

            if (b) return (string)parameter;
            else return string.Empty;
        }
    }
}
