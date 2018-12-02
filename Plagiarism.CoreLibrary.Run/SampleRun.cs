using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plagiarism.CoreLibrary.Libraries;
using Plagiarism.CoreLibrary.Models;
using System.IO;

namespace Plagiarism.CoreLibrary.Run
{
    public class SampleRun
    {
        #region Phase 1-2
        static void Phase1()
        {
            string location = @"C:\Users\Ip310-User\Documents\Plagiarism Checker Proposal C#.pdf";
            string pdfText = PDFReader.ExtractTextFromPdf(location);
            string[] textProcessingResult = new TextProcessing(BaseWords.Words).Process(pdfText);
            foreach (var text in textProcessingResult)
                Console.WriteLine(text);

        }
        static void Phase2()
        {
            string location = @"C:\Users\Ip310-User\Documents\Plagiarism Checker Proposal C#.pdf";
            Stream stream = new FileStream(location, FileMode.OpenOrCreate, FileAccess.Read);
            string pdfText = PDFReader.ExtractTextFromPdf(stream);
            string[] textProcessingResult = new TextProcessing(BaseWords.Words).Process(pdfText);
            foreach (var text in textProcessingResult)
                Console.WriteLine(text);

        }
        #endregion

        #region Plagiarism Checker Run 1-3
        public static void Document1VsDocument2()
        {
            string document1Path = @"C:\Users\skyline\Documents\Plagiarism\document1.pdf";
            string document2Path = @"C:\Users\skyline\Documents\Plagiarism\document2.pdf";

            Stream stream1 = new FileStream(document1Path, FileMode.OpenOrCreate, FileAccess.Read);
            Stream stream2 = new FileStream(document2Path, FileMode.OpenOrCreate, FileAccess.Read);

            string document1Text = PDFReader.ExtractTextFromPdf(stream1);
            string document2Text = PDFReader.ExtractTextFromPdf(stream2);

            TextProcessing textProcessing = new TextProcessing(BaseWords.Words);

            string[] document1Array = textProcessing.Process(document1Text);
            string[] document2Array = textProcessing.Process(document2Text);

            PlagiarismChecker plagiarismChecker = new PlagiarismChecker();
            PlagiarismModel result = plagiarismChecker.Check(target: document2Array, source: document1Array);

            Console.WriteLine("\nDocument #1 vs Document #2");
            Console.WriteLine($"Result          : {result.Description}");
            Console.WriteLine($"Percentage      : {result.PercentageInteger}%");
            Console.WriteLine($"Elapsed Time    : {result.CalculationTime}");

        }
        public static void Document1VsDocument3()
        {
            string document1Path = @"C:\Users\skyline\Documents\Plagiarism\document1.pdf";
            string document3Path = @"C:\Users\skyline\Documents\Plagiarism\document3.pdf";
            Stream stream1 = new FileStream(document1Path, FileMode.OpenOrCreate, FileAccess.Read);
            Stream stream3 = new FileStream(document3Path, FileMode.OpenOrCreate, FileAccess.Read);
            string document1Text = PDFReader.ExtractTextFromPdf(stream1);
            string document3Text = PDFReader.ExtractTextFromPdf(stream3);

            TextProcessing textProcessing = new TextProcessing(BaseWords.Words);

            string[] document1Array = textProcessing.Process(document1Text);
            string[] document3Array = textProcessing.Process(document3Text);

            PlagiarismChecker plagiarismChecker = new PlagiarismChecker();
            PlagiarismModel result = plagiarismChecker.Check(target: document3Array, source: document1Array);

            Console.WriteLine("\nDocument #1 vs Document #3");
            Console.WriteLine($"Result          : {result.Description}");
            Console.WriteLine($"Percentage      : {result.PercentageInteger}%");
            Console.WriteLine($"Elapsed Time    : {result.CalculationTime}");

        }
        public static void Document2VsDocument3()
        {
            string document2Path = @"C:\Users\skyline\Documents\Plagiarism\document2.pdf";
            string document3Path = @"C:\Users\skyline\Documents\Plagiarism\document3.pdf";
            Stream stream2 = new FileStream(document2Path, FileMode.OpenOrCreate, FileAccess.Read);
            Stream stream3 = new FileStream(document3Path, FileMode.OpenOrCreate, FileAccess.Read);
            string document2Text = PDFReader.ExtractTextFromPdf(stream2);
            string document3Text = PDFReader.ExtractTextFromPdf(stream3);

            TextProcessing textProcessing = new TextProcessing(BaseWords.Words);

            string[] document2Array = textProcessing.Process(document2Text);
            string[] document3Array = textProcessing.Process(document3Text);

            PlagiarismChecker plagiarismChecker = new PlagiarismChecker();
            PlagiarismModel result = plagiarismChecker.Check(target: document3Array, source: document2Array);

            Console.WriteLine("\nDocument #2 vs Document #3");
            Console.WriteLine($"Result          : {result.Description}");
            Console.WriteLine($"Percentage      : {result.PercentageInteger}%");
            Console.WriteLine($"Elapsed Time    : {result.CalculationTime}");



        }
        #endregion
    }
}
