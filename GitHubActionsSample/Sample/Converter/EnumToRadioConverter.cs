using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Sample.Converter
{
    public class EnumToRadioConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.Equals(parameter);
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value?.Equals(true) == true ? parameter : Binding.DoNothing;
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
