using System.Collections.Generic;
using System.Text;

namespace Assesment2_BL_StringHelper
{
    public class StringHelper
    {
        /// <summary>
        /// This Method accept a sentence as an argument 'input' and then captialize first character of each word
        /// leaving the words present in 'ignore' HashSet<string>
        /// </summary>
        /// <param name="input"> input string</param>
        /// <param name="ignore"> HashSet<string> of words that one wants to ignore during capitalisation</param>
        /// <returns>sentence after processing as a string</returns>
        public static string CapitaliseFirstLetter(string input, HashSet<string> ignore)
        {
            string[] inputArray = input.Split(' ');
            StringBuilder output = new StringBuilder();

            foreach (string s in inputArray)
            {
                //checking if the word is present in ignore array of string
                if (ignore.Contains(s.ToLower()))
                {
                    output.Append(s.ToLower());
                }
                else if (s.Length > 0)
                {
                    //uppercasting the first letter of the word and adding it to the string
                    output.Append(char.ToUpper(s[0]));

                    //checking if a word is more than 1 char long
                    //and adding the remainig part
                    if (s.Length > 1)
                    {
                        output.Append(s.Substring(1).ToLower());
                    }
                }
                output.Append(" ");
            }

            return output.ToString();
        }
    }
}