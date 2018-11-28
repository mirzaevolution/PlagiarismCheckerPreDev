using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace PDFReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string ExtractTextFromPdf(string path)
        {
            ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();

            using (PdfReader reader = new PdfReader(path))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(reader, i, its);
                    string[] theLines = thePage.Split('\n');
                    foreach (var theLine in theLines)
                    {
                        text.AppendLine(theLine);
                    }
                }
                return text.ToString();
            }
        }
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "",
                Filter = "PDF File (*.pdf)|*.pdf",
                CheckFileExists = true
            };
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxLocation.Text = openFileDialog.FileName;
            }
        }

        private void ButtonRead_Click(object sender, EventArgs e)
        {
            string result = ExtractTextFromPdf(TextBoxLocation.Text);
            RichTextBoxPdfText.Text = result;
        }
    }
}
