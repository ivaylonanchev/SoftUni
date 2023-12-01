using System.Text;
using System.Text.RegularExpressions;

namespace Problem2.FancyBarcodes
{
    internal class Program
    {
        /*
3
@#FreshFisH@#
@###Brea0D@###
@##Che4s6E@##

6
@###Val1d1teM@###
@#ValidIteM@#
##InvaliDiteM##
@InvalidIteM@
@#Invalid_IteM@#
@#ValiditeM@#
        */
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());
            string pattern = @"@#+(?<name>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})@#+";
            for (int i = 0; i < turns; i++)
            {
                string input = Console.ReadLine();
                string barcode = "";
                foreach (Match matches in Regex.Matches(input, pattern))
                {
                    barcode = matches.Groups["name"].Value;
                }
                if (barcode != "")
                {

                    StringBuilder str = new StringBuilder();
                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (barcode[j].ToString() == "1" ||
                            barcode[j].ToString() == "2" ||
                            barcode[j].ToString() == "3" ||
                            barcode[j].ToString() == "4" ||
                            barcode[j].ToString() == "5" ||
                            barcode[j].ToString() == "6" ||
                            barcode[j].ToString() == "7" ||
                            barcode[j].ToString() == "8" ||
                            barcode[j].ToString() == "9" ||
                            barcode[j].ToString() == "0")
                        {
                            str.Append(barcode[j].ToString());
                        }

                    }

                    string numAsString = str.ToString();
                    if (numAsString.Length > 0)
                    {
                        Console.WriteLine($"Product group: { numAsString.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }

        }
    }
}