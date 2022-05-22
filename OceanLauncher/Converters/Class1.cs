using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OceanLauncher.Converters
{
    public class TimeOut2Color : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {

                var r = int.Parse(value.ToString());
                if (r < 120)
                {
                    return "#27ae60";
                }
                else if (r < 240)
                {
                    return "#f39c12";
                }
                else
                {
                    return "gray";
                }
            }
            catch
            {
                return "#ff4757";
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
