using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CommonValueConverters
{
    public class CaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;

            string s = (string)value;

            if (string.IsNullOrEmpty(s)) return null;
            else
            {
                switch (To)
                {
                    case CaseConversion.Upper:
                        return s.ToUpper();
                    case CaseConversion.Lower:
                        return s.ToLower();
                }

            }

            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Note: One way by design
            throw new NotImplementedException();
        }

        public CaseConversion To { get; set; } = CaseConversion.Upper;
    }
}
