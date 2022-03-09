using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wpf03Convertors.Convertors
{
    internal class NumberToTextConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int? /*&& targetType == typeof(string)*/)
            {
                switch (value as int?)
                {
                    case 0: return "Nula";
                    case 1: return "Jedna";
                    case 2: return "Dva";
                    case 3: return "Tři";
                    case 4: return "Čtyři";
                    default: return "Moc";
                }
            }
            return value.ToString();
            // return null;
            // return default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
