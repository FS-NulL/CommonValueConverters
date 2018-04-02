using System;
using System.Globalization;
using System.Windows.Data;

namespace CommonValueConverters
{
    public class IntGreaterEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int i = (int)value;
            return (i >= Threshold);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Note: One way by design
            throw new NotImplementedException();
        }

        public int Threshold { get; set; } = 1;
    }
}
