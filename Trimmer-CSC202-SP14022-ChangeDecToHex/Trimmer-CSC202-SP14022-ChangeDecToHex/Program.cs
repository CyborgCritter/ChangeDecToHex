using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimmer_CSC202_SP14022_ChangeDecToHex
{
    class Program
    {

        static string[] hexDigit = new string[17]
        {
            // Added a 16th case, for the situation when the final conversion leaves a result of 16.
            // In this one case the result is 10, not 0
            "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "9", "A", "B", "C", "D", "E", "F", "10"
        };


        static void Main(string[] args)
        {
            // Variable declaration area
            uint numToConv = 0;
            string hexNum = "";
            

            do
            {
                // Start with the header.
                ClearAndPrintHeader();

                // Function call area
                numToConv = GetNumToConvert();
                hexNum = GetHexConversion(numToConv);

                // Print results area
                Console.WriteLine("Dec {0} is Hex {1}.", numToConv, hexNum);

                // Pause for the user to review results.
                Console.Write("\n\nPress any key to clear the screen and continue... ");
                Console.ReadKey(true);
                Console.WriteLine("\n");
            } while (GetUserContinue());
        }

        

        static string GetHexConversion(uint decNum)
        {
            // recursive function to convert decimal to hexidecimal.

            string hexNum = "";
            byte hexConvStep = 0;

            if (decNum > 16)
            {
                hexConvStep = (byte)(decNum % 16);
                decNum = decNum / 16;
            }
            else
            {
                hexConvStep = (byte)decNum;
                decNum = 0;
            }

            if (decNum > 0)
            {
                //Using this method the next digit goes to the left of the digit we just collected.
                hexNum = GetHexConversion(decNum) + hexDigit[hexConvStep];
            }
            else
            {
                hexNum = hexDigit[hexConvStep];
            }

            return hexNum;
        }



        static uint GetNumToConvert()
        {
            // Method to get the number the user would like to convert to Hex.

            uint tempNum = 0;

            Console.Write("Enter a positive whole number to convert to Hexidecimal... ");

            // Error check the input, and if input is incorrect have the user re-enter.
            while (!uint.TryParse(Console.ReadLine(), out tempNum))
            {
                ClearAndPrintHeader();
                Console.WriteLine("Please enter only a positive whole number.");
                Console.Write("Enter a positive whole number to convert to Hexidecimal... ");
            }

            ClearAndPrintHeader();
            return tempNum;
        }



        static bool GetUserContinue()
        {
            //Function to let the user choose if they want to continue or quite.

            bool userWantContinue = false;
            char userKeyPress = ' ';

            do
            {
                // continue checking for the user input, until the proper key is pressed.

                ClearAndPrintHeader();
                
                Console.Write("Press y to continue, or n to quit... ");
                
                // Use char.ToLower to only have to check for lowercase values.
                userKeyPress = char.ToLower(Console.ReadKey(true).KeyChar);

            } while (userKeyPress != 'y' && userKeyPress != 'n');

            if (userKeyPress == 'y')
            {
                userWantContinue = true;
            }
            else
            {
                userWantContinue = false;
            }

            return userWantContinue;
        }



        static void ClearAndPrintHeader()
        {
            // Method to clear the console, and print my personal header.  

            Console.Clear();

            // Print my Header.
            Console.WriteLine("\n{0}{0}", new string('#', 14));
            Console.WriteLine("##{0}{0}##", new string(' ', 12));
            Console.WriteLine("##{0}Justin Trimmer{0}##", new string(' ', 5));
            Console.WriteLine("##{0}CSC202{0}##", new String(' ', 9));
            Console.WriteLine("##{0} SP14022{0}##", new String(' ', 8));
            // Assignment specific line.
            Console.WriteLine("##{0}Dec to Hex Converter{0}##", new string(' ', 2));
            Console.WriteLine("##{0}{0}##", new string(' ', 12));
            Console.WriteLine("{0}{0}\n\n", new string('#', 14));
        }
    }
}
