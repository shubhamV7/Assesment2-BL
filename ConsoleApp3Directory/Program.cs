using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3Directory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                List<string> inaccessibleDirs = new List<string>();

                Console.WriteLine("\nEnter Directory Path : ");
                string dirPath = Console.ReadLine();

                if (string.IsNullOrEmpty(dirPath.Trim()))
                {
                    Console.WriteLine("Directory path can not be empty or whitespaces, try again\n");
                }
                else
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dirPath.Trim());

                    //checking the directory at input path

                    if (dirInfo.Exists)
                    {
                        Console.WriteLine("");

                        ShowDirInfo(dirInfo, "", inaccessibleDirs);

                        //printing inaccessible directories path
                        if (inaccessibleDirs.Count > 0)
                        {
                            Console.WriteLine("\n\n---------------------------------------------------------------------------" +
                                              "\n  !!! These Directories are Inaccessible " +
                                              "\n---------------------------------------------------------------------------\n");
                            foreach (string s in inaccessibleDirs)
                            {
                                Console.WriteLine(s);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("!! No Directory Found at path - \n" + dirPath);
                    }

                    Console.WriteLine("\n\nDo you want to use again ? (y/n)");
                    char ch = InputChoice();
                    if (ch == 'n')
                    {
                        Console.WriteLine("\nExiting...");
                        break;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Recursive function to show all the
        /// sub-directories and files in a directory
        /// </summary>
        /// <param name="dirInfo"></param> - object of DirectoryInfo
        /// <param name="dirDepth"></param> - depth (dir then sub dir )
        /// <param name="inaccessibleDirs"> list object to add path of all Inaccessible Directories</param>
        /// <remarks>In Output <br/>
        ///  '-' means it is a file and <br/>
        ///  '--' means it is a directory</remarks>
        private static void ShowDirInfo(DirectoryInfo dirInfo, string dirDepth, List<string> inaccessibleDirs)
        {
            try
            {
                Console.WriteLine($"{dirDepth}--{dirInfo.Name}");

                var filesInDir = dirInfo.GetFiles();
                var subDirInDir = dirInfo.GetDirectories();

                foreach (var fl in filesInDir)
                {
                    Console.WriteLine($"{dirDepth} -{fl.Name}");
                }

                foreach (var subDir in subDirInDir)
                {
                    ShowDirInfo(subDir, dirDepth + "  ", inaccessibleDirs);
                }
            }
            catch (DirectoryNotFoundException dExc) //Could not find a part of the path {dirInfo.FullName}
            {
                Console.WriteLine(dExc.Message);
                inaccessibleDirs.Add(dirInfo.FullName);
            }
            catch (UnauthorizedAccessException uExc)    //Access to path {dirInfo.FullName} is denied
            {
                Console.WriteLine(uExc.Message);
                inaccessibleDirs.Add(dirInfo.FullName);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
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