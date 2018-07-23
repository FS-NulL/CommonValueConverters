using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows;

namespace CommonValueConverters.MultiValueconverters
{
    public class AddIntConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return values.Select((o) => int.Parse(o.ToString())).Sum(o => o);
            }
            catch (Exception)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
