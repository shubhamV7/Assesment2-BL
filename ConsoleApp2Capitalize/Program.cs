using Assesment2_BL_StringHelper;
using System;
using System.Collections.Generic;

namespace ConsoleApp2Capitalize
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HashSet<string> ignore = new HashSet<string>(){ "and", "or", "but", "nor", "yet", "so", "for", "a",
                "an", "the", "in", "to", "of", "at", "by", "up", "for", "off", "on" };

            do
            {
                Console.WriteLine("Enter Sentence : ");
                string str = Console.ReadLine();

                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("You have entered an empty string ");
                }
                else
                {
                    Console.WriteLine("\nOutput String : ");
                    Console.WriteLine(StringHelper.CapitaliseFirstLetter(str, ignore));
                }

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
        /// Method to take and validate choice inputs (y/n)
        /// </summary>
        /// <returns>char either 'y' or 'n'</returns>
        private static char InputChoice()
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