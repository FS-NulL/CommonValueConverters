using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CommonValueConverters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) throw new InvalidCastException("BoolToVisibilityConverter.Convert: Value must be a bool.");

            bool b = (bool)value;

            if (b) return TrueVisibility;
            else return FalseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility)) throw new InvalidCastException("BoolToVisibilityConverter.ConvertBack: Value must be Visibility.");

            Visibility v = (Visibility)value;

            if (v == TrueVisibility) return true;
            else return false;      // This might not be perfect, but its maybe the best we can do?
        }

        public Visibility TrueVisibility  { get; set; } = Visibility.Visible;
        public Visibility FalseVisibility { get; set; } = Visibility.Collapsed;
    }
}
