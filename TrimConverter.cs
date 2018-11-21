using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CommonValueConverters
{
    class TrimConverter : IValueConverter
    {
        public string TrimChars { get; set; } = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                if (TrimChars != null)
                {
                    return s.Trim(TrimChars.ToCharArray());
                }

                return s.Trim();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
