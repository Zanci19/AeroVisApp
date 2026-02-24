using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AeroVis.Converters
{
    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class HexToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var hex = value?.ToString() ?? "#FF6B00";
                return (SolidColorBrush)new BrushConverter().ConvertFrom(hex)!;
            }
            catch { return Brushes.OrangeRed; }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
