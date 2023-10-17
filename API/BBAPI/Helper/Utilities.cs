using Microsoft.AspNetCore.JsonPatch.Internal;
using System;
using System.Buffers.Text;
using System.Collections.Generic;

namespace BBAPI.Helper
{
    public static class Utilities
    {
        public static decimal CalculatePenalty(int daysOverdue, DayOfWeek startDay, DayOfWeek endDay, int finePerDay)
        {
            
            decimal penaltyAmount = 0;

            for (int count = 1; count <= daysOverdue; count++)
            {
                DateTime currentDay = DateTime.Now.AddDays(-count);
                // Check if the current day is a weekend day based on the weekendConfiguration
                bool isWeekend = IsWeekendDay(currentDay,  startDay,  endDay);

                if (!isWeekend)
                {
                    penaltyAmount += finePerDay;
                }
            }

            return penaltyAmount;
        }

        private static bool IsWeekendDay(DateTime date, DayOfWeek startDay, DayOfWeek endDay)
        {

            return date.DayOfWeek ==startDay|| date.DayOfWeek == endDay;

        }
    }
}




       