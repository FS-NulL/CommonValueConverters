using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CommonValueConverters
{
    class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) return DependencyProperty.UnsetValue;

            bool b = (bool)value;

            if (b) return TrueString;
            else return FalseString;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            string c = (string)value;

            if (c == TrueString) return true;
            else return false;
        }

        public string TrueString { get; set; } = "True";
        public string FalseString { get; set; } = "False";
    }
}