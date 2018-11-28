using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;
namespace StopwordsRemoval
{
    class Program
    {
        static void Sample1()
        {
            try
            {
                string[] words = new string[]
                {
                    "i am reading a book",
                    "he uses a bycycle to go to mosque",
                    "they want us to get out of this office",
                    "damn shit you are"
                };
                foreach(var word in words)
                {

                }
            }
            catch(Exception ex)
            {
                WriteLine(ex);
            }
        }
        

        static void Main(string[] args)
        {
            Console.WriteLine(CommonEnglishWords.Words);
            Console.ReadLine();
        }
    }
}
