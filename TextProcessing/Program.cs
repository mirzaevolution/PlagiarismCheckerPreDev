using Annytab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextProcessing
{
    public class Plagiarism
    {
        public float Percentage { get; set; }
        public int PercentageInteger { get; set; }
        public string Description { get; set; }
        public int Distance { get; set; }
        public int Max { get; set; }
        public string[] TargetArray { get; set; }
        public string Target { get; set; }
        public string[] SourceArray { get; set; }
        public string Source { get; set; }
        public TimeSpan CalculationTime { get; set; }
    }
    public class TextProcessing
    {
        private string _tokenizingPattern;
        private string _purifyingWordsPattern;
        private string _commonEnglishWords;
        private string[] ExtractCommonEnglishWords(string commonEnglishWords)
        {

            string[] result = null;
            try
            {

                result = Regex.Split(commonEnglishWords, @"\s*?\,\s*?");
            }
            catch { result = null; }
            return result;
        }

        public TextProcessing(string commonEnglishWords)
        {
            this._tokenizingPattern = @"[\s\n\r\f]";
            this._purifyingWordsPattern = @"[\.\!\@\#\,\?]+$";
            this._commonEnglishWords = commonEnglishWords;
        }

        public TextProcessing(string tokenizingPattern, string purifyingWordsPattern, string commonEnglishWords)
        {
            this._tokenizingPattern = tokenizingPattern;
            this._purifyingWordsPattern = purifyingWordsPattern;
            this._commonEnglishWords = commonEnglishWords;
        }

        public string TokenizingPattern
        {
            get
            {
                return _tokenizingPattern;
            }
            set
            {
                if (value != _tokenizingPattern)
                    _tokenizingPattern = value;
            }
        }

        public string PurifyingWordsPattern
        {
            get
            {
                return _purifyingWordsPattern;
            }
            set
            {
                if (value != _purifyingWordsPattern)
                    _purifyingWordsPattern = value;
            }
        }

        public string CommonEnglishWords
        {
            get
            {
                return _commonEnglishWords;
            }
            set
            {
                if (value != _commonEnglishWords)
                    _commonEnglishWords = value;
            }
        }
        public string[] Process(string text)
        {
            //Check if string is empty/null.
            //If empty/null, just throw it.

            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException(nameof(text), "Parameter 'text' cannot be null");

            //1. Extract common words

            string[] commonWords = ExtractCommonEnglishWords(_commonEnglishWords);

            //2. Tokenizing process
            string[] tokenizedString = Regex.Split(text, _tokenizingPattern);

            //3. Purifying left over words from other common unexpected symbols
            tokenizedString = tokenizedString.Select(x => Regex.Replace(x, _purifyingWordsPattern, "")).ToArray();

            //4. Stopwords Removal process
            string[] stopwordsRemoval = tokenizedString.Select(x => x.ToLower()).Except(commonWords).ToArray();

            //5. Stemming process
            EnglishStemmer stemmer = new EnglishStemmer();
            string[] stemmedWords = stemmer.GetSteamWords(stopwordsRemoval);

            
            //6. Sorting process
            string[] sortedString = stemmedWords.OrderBy(x => x).ToArray();

            return sortedString;

        }
    }

    public class EditDistance
    {
        public static int CalculateLevenshtein(string original, string modified)
        {
            int originalLength = original.Length;
            int modifiedLength = modified.Length;
            int result = 0;
            try
            {
                int[,] matrix = new int[originalLength + 1, modifiedLength + 1];
                for (int i = 0; i <= originalLength; i++)
                    matrix[i, 0] = i;
                for (int j = 0; j <= modifiedLength; j++)
                    matrix[0, j] = j;

                for (int i = 1; i <= originalLength; i++)
                {
                    for (int j = 1; j <= modifiedLength; j++)
                    {
                        int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                        var vals = new int[] 
                        {
                            matrix[i - 1, j] + 1,
                            matrix[i, j - 1] + 1,
                            matrix[i - 1, j - 1] + cost
                        };
                        matrix[i, j] = vals.Min();
                        if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                        }
                            
                    }
                }
                result = matrix[originalLength, modifiedLength];
            }
            catch (IndexOutOfRangeException ex)
            {
                result = 0;
                Trace.WriteLine(ex);
            }
            catch (Exception ex)
            {
                result = 0;
                Trace.WriteLine(ex);
            }

            return result;
        }
    }

    public class PlagiriasmChecker
    {
        public string Language { get; set; } = "English";
        private string TransformString(string[] array)
        {
            if(array != null && array.Length>0)
            {
                string result = string.Empty;
                result = array.Aggregate((current, next) => current + "\n" + next);
                return result;
            }
            return string.Empty;
        }
        public Plagiarism Check(string[] target, string[] source)
        {
            Plagiarism result = new Plagiarism();
            try
            {
                result.TargetArray = target;
                result.SourceArray = source;

                string targetStr = TransformString(target);
                string sourceStr = TransformString(source);

                int targetLength = targetStr.Length;
                int sourceLength = sourceStr.Length;

                result.Target = targetStr;
                result.Source = sourceStr;
                
                Stopwatch stopwatch = Stopwatch.StartNew();

                result.Distance = EditDistance.CalculateLevenshtein(sourceStr, targetStr);

                result.Max = Math.Max(targetLength, sourceLength);

                result.Percentage = ((1 - ((float)result.Distance / (float)result.Max)) * 100);

                int percentageInt = Convert.ToInt32(result.Percentage);
                result.PercentageInteger = percentageInt;

                if (percentageInt < 30)
                {
                    switch(Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme rendah";
                            break;
                        default:
                            result.Description = "Plagiarism level is low";
                            break;

                    }
                }
                else if(percentageInt <= 70)
                {

                    switch (Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme sedang";
                            break;
                        default:
                            result.Description = "Plagiarism level is intermediate";
                            break;
                    }
                }
                else if(percentageInt>70)
                {
                    switch (Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme tinggi";
                            break;
                        default:
                            result.Description = "Plagiarism level is high";
                            break;
                    }
                }

                stopwatch.Stop();
                result.CalculationTime = stopwatch.Elapsed;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return result;
        }
        public Plagiarism Check(string[] target, string sourceFromDb)
        {
            Plagiarism result = new Plagiarism();
            try
            {
                result.TargetArray = target;
                result.SourceArray = null;

                string targetStr = TransformString(target);
                string sourceStr = sourceFromDb;

                int targetLength = targetStr.Length;
                int sourceLength = sourceStr.Length;

                result.Target = targetStr;
                result.Source = sourceStr;

                Stopwatch stopwatch = Stopwatch.StartNew();

                result.Distance = EditDistance.CalculateLevenshtein(sourceStr, targetStr);

                result.Max = Math.Max(targetLength, sourceLength);

                result.Percentage = ((1 - ((float)result.Distance / (float)result.Max)) * 100);

                int percentageInt = Convert.ToInt32(result.Percentage);
                result.PercentageInteger = percentageInt;

                if (percentageInt < 30)
                {
                    switch (Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme rendah";
                            break;
                        default:
                            result.Description = "Plagiarism level is low";
                            break;

                    }
                }
                else if (percentageInt <= 70)
                {

                    switch (Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme sedang";
                            break;
                        default:
                            result.Description = "Plagiarism level is intermediate";
                            break;
                    }
                }
                else if (percentageInt > 70)
                {
                    switch (Language.ToLower().Trim())
                    {
                        case "Indonesia":
                            result.Description = "Level plagiarisme tinggi";
                            break;
                        default:
                            result.Description = "Plagiarism level is high";
                            break;
                    }
                }

                stopwatch.Stop();
                result.CalculationTime = stopwatch.Elapsed;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            return result;
        }
    }

    class Program
    {

        static void Sample1()
        {
            string textMe = "I am reading books with my friends. She is so sexy and beautiful. I really love her so much. Loving her is my dream";
            string[] result = new TextProcessing(BaseWords.Words).Process(textMe);
            Console.WriteLine(result.Aggregate((curr,next) => curr + " " + next));
        }
        static void Sample2()
        {
            string target = "Hahaha He is Mirza Ghulam Rasyid. Hello. Bangke Banget.";
            string source = "I am reading books with my friends. She is so sexy and beautiful. I really love her so much. Loving her is my dream";

            TextProcessing textProcessing = new TextProcessing(BaseWords.Words);

            string[] targetArray = textProcessing.Process(target);
            string[] sourceArray = textProcessing.Process(source);

            Plagiarism plagiarism = new PlagiriasmChecker().Check(targetArray, sourceArray);
            Console.WriteLine($"Percentage: {plagiarism.PercentageInteger}%");
            Console.WriteLine($"Result: {plagiarism.Description}");
            Console.WriteLine($"Elapsed: {plagiarism.CalculationTime}");
        }
        static void Sample3()
        {
            string sourceFromDb = "beauti\nbook\ndream\nfriend\nlove\nlove\nread\nsexi";
            string target = "Hahaha He is Mirza Ghulam Rasyid. Hello. Bangke Banget.";
            
            TextProcessing textProcessing = new TextProcessing(BaseWords.Words);

            string[] targetArray = textProcessing.Process(target);
            
            Plagiarism plagiarism = new PlagiriasmChecker().Check(targetArray, sourceFromDb);
            Console.WriteLine($"Percentage: {plagiarism.PercentageInteger}%");
            Console.WriteLine($"Result: {plagiarism.Description}");
            Console.WriteLine($"Elapsed: {plagiarism.CalculationTime}");
        }
        static void Main(string[] args)
        {
            //Sample1();
            //Sample2();
            Sample3();
            Console.ReadLine();
        }
    }
}
