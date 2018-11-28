using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Annytab;
using Annytab.Stemmer;
//using Iveonik.Stemmers;

namespace WordStemmer
{
    class Program
    {
        static void Sample1()
        {
            string[] words = new string[]
            {
                "going",
                "loving",
                "reading",
                "read",
                "i",
                "am",
                "kissing",
                "sexy",
                "beautiful",
                "riding"
            };
            EnglishStemmer stemmer = new EnglishStemmer();
            var result = stemmer.GetSteamWords(words);
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(stemmer.GetSteamWord(words[0]));
            //string word = words.Aggregate((curr, next) => curr + " " + next);
            //Console.WriteLine(stemmer.Stem(word));
        }
        static void Main(string[] args)
        {
            Sample1();
            Console.ReadLine();
        }
    }
}
