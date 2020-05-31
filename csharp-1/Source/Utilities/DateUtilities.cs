using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Utilities
{
    public static class DateUtilities
    {
        public static int CalculateAge(DateTime birthdate)
        {
            int age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
            {
                age -= 1;
            }
            return age;
        }
    }
}
