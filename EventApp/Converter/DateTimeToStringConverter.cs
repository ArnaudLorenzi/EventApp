using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace EventApp.Converter
{
    /// <summary>
    ///     Value converter that translates true to false and vice versa.
    /// </summary>
    public sealed class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value == null || !(value is DateTime)) ? string.Empty : ((DateTime)value).ToString("dd/MM/yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value.GetType() == typeof(DateTime))
                    return value;
                var str = (String)value;
                if (str == null || str.Trim().Equals(""))
                    return null;

                return DateTime.Parse(str.Trim());
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
        }
    }
}
