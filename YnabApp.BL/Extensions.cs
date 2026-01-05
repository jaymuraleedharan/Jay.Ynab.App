using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YnabApp.BL
{
    public static class Extensions
    {
        public static string IsoFormat(this DateTime dateValue)
        {
            return dateValue.ToString("yyyy-MM-dd");
        }

        public static DateTime ConvertToDateTimeFromIso(this string isoDateValue)
        {
            if (string.IsNullOrWhiteSpace(isoDateValue))
                throw new ApplicationException("Invalid Date Format");

            var parts = isoDateValue.Split("-".ToCharArray());
            if(parts.Length != 3)
                throw new ApplicationException("Invalid Date Format");

            return DateTime.Parse($"{parts[1]}/{parts[2]}/{parts[0]}");
        }
    }
}
