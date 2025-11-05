using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CharactersOfCthulhu.Converters
{

    public class StringListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string> skills)
            {
                return string.Join(", ", skills);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}