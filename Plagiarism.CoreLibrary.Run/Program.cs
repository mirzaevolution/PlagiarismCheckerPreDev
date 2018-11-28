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
    class Program
    {
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
        static void Main(string[] args)
        {
            //Phase1();
            Phase2();
            Console.ReadLine();
        }
    }
}
