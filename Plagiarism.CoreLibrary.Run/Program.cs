using System;

namespace Plagiarism.CoreLibrary.Run
{
    class Program
    {
       
        static void Main(string[] args)
        {
            SampleRun.Document1VsDocument2();
            SampleRun.Document1VsDocument3();
            SampleRun.Document2VsDocument3();
            Console.ReadLine();
        }
    }
}
