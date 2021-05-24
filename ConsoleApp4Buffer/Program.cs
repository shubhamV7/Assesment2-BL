using Assesment2_BL_DataStoreHelper;
using System;

namespace ConsoleApp4Buffer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                int bufferSize = TakeBufferInput();

                DataStoreHelper dsHelper = new DataStoreHelper(bufferSize);

                //calling function to take input and store it
                TakeInputs(dsHelper);

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
        /// Method to take input from console and store the input into buffer
        /// </summary>
        /// <param name="dsHelper">Object of DataStoreHelper</param>
        private static void TakeInputs(DataStoreHelper dsHelper)
        {
            Console.WriteLine("Ënter string values one by one (Enter ? anytime to print all values)");
            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("?"))
                {
                    PrintAllValues(dsHelper);
                    Console.Write("\n\nDo you want to continue entering values (y/n) : ");

                    char ch = InputChoice();

                    if (ch == 'y')
                    {
                        Console.WriteLine("Start entering values again - ");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (!dsHelper.Add(input))
                    {
                        Console.Write("Buffer is full!!\nDo you want to overwrite the oldest data? (y/n) : ");
                        char chO = InputChoice();

                        if (chO == 'y')
                        {
                            string oldestVal = dsHelper.OverWriteOldestValue(input);
                            Console.WriteLine($"'{oldestVal}' is overwritten by '{input}'");
                            Console.WriteLine();
                        }
                        else if (chO == 'n')
                        {
                            Console.WriteLine("\nYou choose not to overwrite oldest data.. \n Start entering values again (? to print all values)- \n");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to print all values that are present in the buffer
        /// </summary>
        /// <param name="dsHelper">Object of DataStoreHelper</param>
        private static void PrintAllValues(DataStoreHelper dsHelper)
        {
            Console.WriteLine("\n");
            Console.WriteLine("All values : \n");

            foreach (string str in dsHelper.GetEnumerable())
            {
                Console.Write(str + " ");
            }
        }

        /// <summary>
        /// Method to take buffer size input from console
        /// </summary>
        /// <returns>integer value of buffer size</returns>
        internal static int TakeBufferInput()
        {
            int bSize;

            do
            {
                Console.Write("Enter number of data you want to store : ");
                if (int.TryParse(Console.ReadLine(), out bSize))
                {
                    if (bSize < 1)
                    {
                        Console.WriteLine("Input value must be greater than 0\nTry again : ");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input (input must be a natural number )\nTry again : ");
                }
            }
            while (true);

            return bSize;
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