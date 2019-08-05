using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Grouping
{
    public class GroupHeaderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType.Name == "Color")
            {
                if ((int)value == 1)
                    return Color.FromHex("#D3D3D3");
                else
                    return Color.Transparent;
            }
            else
            {
                if ((int)value == 1)
                    return new Thickness(5, 5, 5, 0);
                else
                    return new Thickness((int)value * 15, 5, 5, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
