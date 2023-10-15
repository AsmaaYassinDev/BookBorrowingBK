using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public static class Utilities
    {

        public static bool IsHoliday(DateTime dateTime)
        {
            return Constants.Weekends.Contains(dateTime.DayOfWeek);
        }
       
        public static DateTime AddBusinessDays(DateTime originalDateTime, int noOfDays)
        {
            var result = originalDateTime;

            for(var iCntr = 0; iCntr < noOfDays; iCntr++)
            {
                do
                {
                  result = result.AddDays(1);
                } while (IsHoliday(result));
            }

            return result;
        }

        public static int CountBusinessDays(DateTime dateTime1, DateTime dateTime2)
        {
            var result = 0;
            return result;
        }
    }
}