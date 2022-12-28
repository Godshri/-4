using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    public class Functions
    {
        public static DateTime StringToDateTime(string text)
        {
            if (DateTime.TryParseExact(text, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime tmp))
            {
                return tmp;
            }
            else
            {
                throw new UserExeption.UserExeption("Converting from String to DateTime failed!");
            }
        }
    }
}
