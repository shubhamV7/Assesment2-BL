using Assesment2_BL_DateHelper;
using System;

namespace ConsoleApp1Dates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Valid date formats (yyyy-mm-dd) Or (yyyy/mm/dd)");

                DateTime fromDate = InputFromDate();
                DateTime toDate = InputToDate(fromDate);

                //Calculating total days between the fromDate and toDate
                int days = toDate.Subtract(fromDate).Days;

                //getting result string of total months and days between the fromDate and toDate
                string resultInMD = DateHelper.GetDifferenceStringInMD(fromDate, toDate);

                //getting result string of total years, months and days between the fromDate and toDate
                string resultInYMD = DateHelper.GetDifferenceStringInYMD(fromDate, toDate);

                Console.WriteLine("\n\tDays : {0}", days);
                Console.WriteLine("\t" + resultInMD);
                Console.WriteLine("\t" + resultInYMD);

                Console.WriteLine("\n\nDo you want to use again ? (y/n)");
                char ch = InputChoice();
                if (ch == 'n')
                {
                    Console.WriteLine("\nExiting...");
                    break;
                }
            } while (true);
        }

        /// <summary>
        /// This Method takes input from the user in (yyyy-mm-dd) format until valid 'From date' is entered
        /// </summary>
        /// <returns>Valid DateTime object</returns>
        internal static DateTime InputFromDate()
        {
            DateTime fDate;
            do
            {
                Console.Write("\nEnter FROM Date: ");
                if (DateTime.TryParse(Console.ReadLine(), out fDate))
                {
                    if (fDate >= DateTime.Today)
                    {
                        Console.WriteLine("FROM date must be less than Today's date (i.e. {0}) try again", DateTime.Today.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Date Format !!! try again");
                }
            } while (true);

            return fDate;
        }

        /// <summary>
        /// This Method takes input from the user in (yyyy-mm-dd) until valid 'To date' is entered
        /// valid ToDate is -> when 'To Date' is greater than or equal to 'From Date'
        /// </summary>
        /// <param name="fromDate">'From date' object is required to validate the 'To date'</param>
        /// <returns>Valid DateTime object</returns>
        internal static DateTime InputToDate(DateTime fromDate)
        {
            DateTime tDate;
            do
            {
                Console.Write("\nEnter TO Date: ");
                if (DateTime.TryParse(Console.ReadLine(), out tDate))
                {
                    if (tDate < fromDate)
                    {
                        Console.WriteLine("TO date must be equal or greater than FROM date (i.e. {0}), try again"
                            , fromDate.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Date !!! try again\n");
                }
            } while (true);

            return tDate;
        }

        /// <summary>
        /// Method to take and validate choice inputs (y/n)
        /// </summary>
        /// <returns>char either 'y' or 'n'</returns>
        internal static char InputChoice()
        {
            char ch;
            do
            {
                if (char.TryParse(Console.ReadLine(), out ch))
                {
                    if (char.ToLower(ch) == 'y' || char.ToLower(ch) == 'n')
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nWrong Choice try again (y/n): ");
                    }
                }
                else
                {
                    Console.Write("\nWrong Choice try again (y/n): ");
                }
            } while (true);

            return char.ToLower(ch);
        }
    }
}