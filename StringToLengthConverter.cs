using System;
using System.Globalization;
using System.Windows.Data;

namespace CommonValueConverters
{
    class StringToLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
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
