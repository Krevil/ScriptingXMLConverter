using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ScriptingXMLConverter
{
    class Program
    {
        static string GetDec(Match match)
        {
            string dec;
            string hex = match.ToString();
            switch (hex.Length)
            {
                case 5:
                    dec = hex.Substring(3, 1);
                    int intdec = int.Parse(dec, NumberStyles.HexNumber);
                    dec = Convert.ToString(intdec);
                    return "\"" + dec + "\"";
                case 6:
                    dec = hex.Substring(3, 2);
                    intdec = int.Parse(dec, NumberStyles.HexNumber);
                    dec = Convert.ToString(intdec);
                    return "\"" + dec + "\"";
                case 7:
                    dec = hex.Substring(3, 3);
                    intdec = int.Parse(dec, NumberStyles.HexNumber);
                    dec = Convert.ToString(intdec);
                    return "\"" + dec + "\"";
                default:
                    return "NaN";
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please type the file name:");
            string str = "";
            try
            {
                str = File.ReadAllText(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Unable to access file - are you sure you typed the name correctly?");
                return;
            }
            Regex pattern = new Regex(@"\x220x(?<opcode>[^\x22]+)\x22");

            /*
            + means matches the previous element one or more times
            () are capture groups
            @ means don't use \ as a regular escape character and such
            \x means hexadecimal unicode with 22 being "
            \w is characters, ie A, a, 10 or 2147 for example
            {2,} is "have at least two of these" so in this it has at least 2 characters before the next part
            It then ends with another " to top things off
            */

            string output = pattern.Replace(str, GetDec);
            Console.WriteLine("Now type a name for the new file:");
            File.WriteAllText(Console.ReadLine(), output);
            Console.WriteLine("Done. Press any key to exit...");
            Console.ReadKey();
        }
    }
}