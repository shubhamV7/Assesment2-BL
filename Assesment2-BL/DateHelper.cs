using System;

namespace Assesment2_BL_DateHelper
{
    /// <summary>
    /// Structure to store Date values
    /// (Year, Month, Day)
    /// </summary>
    public struct DateResult
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public DateResult(int years, int months, int days)
        {
            Year = years;
            Month = months;
            Day = days;
        }
    }

    /// <summary>
    /// Helper Class to handle operations with DateTime
    /// </summary>
    public class DateHelper
    {
        /// <summary>
        /// Method to calculate difference in years, months and days
        /// between two DateTime objects
        /// </summary>
        /// <param name="fromDate">'From Date' object</param>
        /// <param name="toDate">'To Date object'</param>
        /// <returns>DateResult object as result</returns>
        /// <remarks>'FromDate' must be smaller than or equal to 'ToDate' otherwise it will return a result with negative value of either year,month or day</remarks>
        public static DateResult DateDifference(DateTime fromDate, DateTime toDate)
        {
            int[] daysInMonth = { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int days, months, years;

            int borrow = 0;

            //calculating days
            if (fromDate.Day > toDate.Day)
            {
                int prevMonth = ((toDate.Month - 2) >= 0 ? (toDate.Month - 2) : 11);
                borrow = daysInMonth[prevMonth];
            }

            //in case of feb and fromDate.Day > toDate.Day
            if (borrow == -1)
            {
                if (DateTime.IsLeapYear(toDate.Year))
                {
                    borrow = 29;
                }
                else
                {
                    borrow = 28;
                }
            }

            //if borrow taken
            if (borrow != 0)
            {
                days = (toDate.Day + borrow) - fromDate.Day;
                borrow = 1;
            }
            else
            {
                days = toDate.Day - fromDate.Day;
                borrow = 0;
            }

            // calculating month
            if ((toDate.Month - borrow) < fromDate.Month)
            {
                months = (toDate.Month - borrow + 12) - fromDate.Month;
                borrow = 1;
            }
            else
            {
                months = (toDate.Month - borrow) - fromDate.Month;
                borrow = 0;
            }

            //calculating year
            years = (toDate.Year - borrow) - fromDate.Year;

            return new DateResult(years, months, days);
        }

        /// <summary>
        /// Method to calculate difference in years, months and days
        /// between two DateTime objects and format the 'result' into a string <br/>
        /// For Example - "2 Year(s) and 3 Month(s) and 23 Day(s)"
        /// </summary>
        /// <param name="fromDate">'From Date' object</param>
        /// <param name="toDate">'To Date object'</param>
        /// <returns>result of type string</returns>
        /// <remarks>'FromDate' must be smaller than or equal to 'ToDate' otherwise it will return a result with negative value of either year,month or day</remarks>
        public static string GetDifferenceStringInYMD(DateTime fromDate, DateTime toDate)
        {
            DateResult resultDate = DateDifference(fromDate, toDate);

            return $"{resultDate.Year} Year(s) and {resultDate.Month} Month(s) and {resultDate.Day} Day(s)";
        }

        /// <summary>
        /// Method to calculate difference months and days
        /// between two DateTime objects and format the 'result' into a string <br/>
        /// For Example - "27 Month(s) and 23 Day(s)"
        /// </summary>
        /// <param name="fromDate">'From Date' object</param>
        /// <param name="toDate">'To Date object'</param>
        /// <returns>result of type string</returns>
        /// <remarks>'FromDate' must be smaller than or equal to 'ToDate' otherwise it will return a result with negative value of either month or day</remarks>
        public static string GetDifferenceStringInMD(DateTime fromDate, DateTime toDate)
        {
            DateResult resultDate = DateDifference(fromDate, toDate);
            int months = resultDate.Month + (resultDate.Year * 12);

            return $"{months} Month(s) and {resultDate.Day} Day(s)";
        }
    }
}