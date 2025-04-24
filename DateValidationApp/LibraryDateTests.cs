using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DateValidationApp
{
    public class LibraryDateTests
    {
        private static readonly DateTime StartDate = new DateTime(1900, 1, 1);
        private static readonly DateTime CurrentDate = DateTime.Now;

        public bool ValidDate(string dateInput)
        {
            DateTime date;
            Regex regex = new Regex(@"^\d{2}\.\d{2}\.\d{4}$");
            if (!regex.IsMatch(dateInput))
            {
                date = default;
                return false;
            }


            if (DateTime.TryParseExact(dateInput, "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date >= StartDate && date <= CurrentDate;
            }
            date = default;
            return false;
        }
    }
}
