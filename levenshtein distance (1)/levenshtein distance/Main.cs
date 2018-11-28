using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
namespace levenshtein_distance
{
    public partial class Main : Form
    {
        public static String Hypotheses, Reference;
        public static double[,] distance_table;
         public void table_show()
        {
            /*
           int len_orig = original.Length;
           int len_diff = modified.Length;

           var matrix = new int[len_orig + 1, len_diff + 1];
           for (int i = 0; i <= len_orig; i++)
               matrix[i, 0] = i;
           for (int j = 0; j <= len_diff; j++)
               matrix[0, j] = j;

           for (int i = 1; i <= len_orig; i++)
           {
               for (int j = 1; j <= len_diff; j++)
               {
                   int cost = modified[j - 1] == original[i - 1] ? 0 : 1; 
                   var vals = new int[] {
                   matrix[i - 1, j] + 1,
                   matrix[i, j - 1] + 1,
                   matrix[i - 1, j - 1] + cost
               };
                   matrix[i, j] = vals.Min();
                   if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                       matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
               }
           }
           return matrix[len_orig, len_diff];
             */
            this.dataGridView2.Columns.Add(" ", " ");
            this.dataGridView2.Rows.Add(" ", " ");
            this.dataGridView2.Columns.Add(" ", " ");
            for (int j = 1; j <= Hypotheses.Length; j++)
                this.dataGridView2.Columns.Add(j.ToString(), Hypotheses[j - 1].ToString());

            for (int i = 1; i <= Reference.Length; i++)
                this.dataGridView2.Rows.Add(Reference[i - 1].ToString());

            for (int i = 1; i <= Reference.Length + 1; i++)
            {
                for (int j = 1; j <= Hypotheses.Length + 1; j++)
                {
                    this.dataGridView2.Rows[i - 1].Cells[j].Value = distance_table[i - 1 ,j -1].ToString();

                }

            }
        }


        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            textBox4.Text = richTextBox1.TextLength.ToString();
            textBox5.Text = richTextBox2.TextLength.ToString();
        }









        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string pilih_file;
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files|*.pdf";
            openFileDialog1.Title = "Select a PDF File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pilih_file = openFileDialog1.FileName.ToString();
                textBox1.Text = pilih_file;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                PDDocument doc = PDDocument.load(textBox1.Text);
                PDFTextStripper stripper = new PDFTextStripper();
                richTextBox1.Text = (stripper.getText(doc));

            }
            else
            {
                PDDocument doc = PDDocument.load(textBox1.Text);
                PDFTextStripper stripper = new PDFTextStripper();
                richTextBox1.Text = (stripper.getText(doc));
                PDDocument doc2 = PDDocument.load(textBox2.Text);
                PDFTextStripper stripper2 = new PDFTextStripper();
                richTextBox2.Text = (stripper2.getText(doc2));
            }
        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox5.Text = richTextBox2.TextLength.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = richTextBox1.TextLength.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Stopwatch timerr = new Stopwatch();
            timerr.Start();
            int diff, max;
            float temp, temp2;
            diff = Editdistance.levenshtein(richTextBox1.Text, richTextBox2.Text);
            textBox3.Text = diff.ToString();

            if (Convert.ToInt32(textBox4.Text) < Convert.ToInt32(textBox5.Text))
            {
                max = Int32.Parse(textBox5.Text);
                /*
                 * Rumus
                 * 1 - DIFF/MAX *100
                 * 1 - (float) d / len) * 100;
                */
                //try
                textBox7.Text = max.ToString();
                temp = Convert.ToInt32(textBox7.Text);
                temp2 = ((1 - (diff / temp)) * 100);
                textBox6.Text = Convert.ToInt32(temp2).ToString() + " %";

            }
            else
            {

                max = Int32.Parse(textBox4.Text);
                /*
                 * Rumus
                 * 1 - DIFF/MAX *100
                 * 1 - (float) d / len) * 100;
                 */
                textBox7.Text = max.ToString();
                temp = Convert.ToInt32(textBox7.Text);
                temp2 = ((1 - (diff / temp)) * 100);
                textBox6.Text = Convert.ToInt32(temp2).ToString() + " %";

            }


            if (temp2 < 30)
            {
                textBox8.Text = "Plagiarisme ringan";
            }
            else
                if (temp2 <= 70)
                {
                    textBox8.Text = "Plagiarisme Sedang";
                }
                else
                    if (temp2 > 70)
                    {
                        textBox8.Text = "Plagiarisme Berat";
                    }

            timerr.Stop();

            //textBox9.Text = timerr.Elapsed.TotalMilliseconds.ToString() + " m/s";
            textBox9.Text = timerr.Elapsed.TotalSeconds.ToString() + " s";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Yakin ingin keluar?", "Keluar Aplikasi", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pilih_file;
            // Displays an OpenFileDialog so the user can select a Cursor.  

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "PDF Files|*.pdf";
            openFileDialog2.Title = "Select a PDF File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pilih_file = openFileDialog2.FileName.ToString();
                textBox2.Text = pilih_file;
            }

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            string phrase = richTextBox1.Text;
            string[] words = phrase.Split(' ');
            richTextBox1.Text = " ";
            foreach (string word in words)
            {

                richTextBox1.Text += word + "\r\n";
            }

            string phrase2 = richTextBox2.Text;
            string[] words2 = phrase2.Split(' ');
            richTextBox2.Text = " ";
            foreach (string word1 in words2)
            {

                richTextBox2.Text += word1 + "\r\n";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            textBox9.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
                string inputstem = richTextBox1.Text;
                string inputstem2 = richTextBox2.Text;
                stemming stemmer = new stemming();
                //tokenizing
                String[] ipsStrings = inputstem.Split(' ');
                String[] ipsStrings2 = inputstem2.Split(' ');
                richTextBox1.Text = null;
                richTextBox2.Text = null;
                foreach (var ipsString in ipsStrings)
                {
                    //sorting 
                    Array.Sort(ipsStrings);
                    Array.Sort(ipsStrings2);
                    //filtering (removal stop words)
                    string filtering = stopwords.RemoveStopwords(ipsString);
                    richTextBox2.Text += (filtering+" ");
                    //stemming
                    String outputstem = stemmer.stem(filtering);
                    richTextBox1.Text += (outputstem+"\r\n");
                    
                }

                foreach (var ipsStringz in ipsStrings2)
                {
                    //stemming
                    String outputstem2 = stemmer.stem(ipsStringz);
                    richTextBox2.Text += (outputstem2 + "\r\n");
                    // richTextBox1.Text += (outputstem2 + "\r\n");

                    //richTextBox2.Text += 
                }
              
            }
            
         
        

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string phrase = richTextBox1.Text;
            string[] words = phrase.Split(' ');
            richTextBox1.Text = "";
            foreach (string word in words)
            {

                richTextBox1.Text += word + "\r\n";
            }

            string phrase2 = richTextBox2.Text;
            string[] words2 = phrase2.Split(' ');
            richTextBox2.Text = "";
            foreach (string word1 in words2)
            {

                richTextBox2.Text += word1 + "\r\n";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //richTextBox5.Text = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PDF Files|*.pdf";
            openFileDialog1.Title = "Select a PDF File";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                foreach (string item in openFileDialog1.FileNames)
                {
                    //get path name files
                    listBox1.Items.Add(Path.GetFileName(item));
                }
            }

            //dbgrid
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Clear();
            foreach (var item in listBox1.Items)
            {
                int idx = dataGridView1.Rows.Add();
                int hitung = 0;
                for (int i = 0; i <= idx; i++)
                {
                    hitung++;
                    dataGridView1.Rows[idx].Cells["No"].Value = hitung;
                    dataGridView1.Rows[idx].Cells["Uji"].Value = item;
                }
            }
            foreach (var items in listBox2.Items)
            {

                int idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx - Convert.ToInt32(listBox1.Items.Count)].Cells["Pembanding"].Value = items;


            }


        }



        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(listBox1.SelectedItem.ToString());
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            dataGridView1.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Clear();
            foreach (var item in listBox1.Items)
            {
                int idx = dataGridView1.Rows.Add();
                int hitung = 0;
                for (int i = 0; i <= idx; i++)
                {
                    hitung++;
                    dataGridView1.Rows[idx].Cells["No"].Value = hitung;
                    dataGridView1.Rows[idx].Cells["Uji"].Value = item;
                }
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.Filter = "PDF Files|*.pdf";
            openFileDialog2.Title = "Select a PDF File";
            openFileDialog2.Multiselect = true;
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                foreach (string item in openFileDialog2.FileNames)
                {
                    //get path name files
                    listBox2.Items.Add(Path.GetFileName(item));
                }
            }

            //dbgrid

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            //dataGridView1.Rows.Clear();
            foreach (var items in listBox2.Items)
            {

                int idx = dataGridView1.Rows.Add();
                dataGridView1.Rows[idx - Convert.ToInt32(listBox1.Items.Count)].Cells["Pembanding"].Value = items;


            }


        }

        private void button13_Click(object sender, EventArgs e)
        {
            /*
                PDDocument doc = PDDocument.load(textBox1.Text);
                PDFTextStripper stripper = new PDFTextStripper();
                richTextBox1.Text = (stripper.getText(doc));
                PDDocument doc2 = PDDocument.load(textBox2.Text);
                PDFTextStripper stripper2 = new PDFTextStripper();
                richTextBox2.Text = (stripper2.getText(doc2));
             */
            foreach (string item in listBox1.Items)
            {
                // same the item to the database


            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Reference = "joko";
            Hypotheses = "jokos";
            distance_table = new double[Reference.Length + 1, Hypotheses.Length + 1];
            for (int i = 0; i <= Reference.Length; i++)
            distance_table[i, 0] = i;
            //distance_table[i, 0] = i;

            for (int j = 0; j <= Hypotheses.Length; j++)
            distance_table[0, j] = j ;
            //distance_table[0, j] = j;
            for (int i = 1; i <= Reference.Length; i++)
            {
                for (int j = 1; j <= Hypotheses.Length; j++)
                {
                    if (Reference[i - 1] == Hypotheses[j - 1])//if the letters are same 
                        distance_table[i, j] = distance_table[i - 1, j - 1];
                    else //if not add 1 to its neighborhoods and assign minumun of its neighborhoods 
                    {
                        distance_table[i, j] = Math.Min(Math.Min(distance_table[i - 1, j - 1] + 1, distance_table[i - 1, j] + 0.7), distance_table[i, j - 1] + 0.7);
                    }
                }

            }//create table
            table_show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            
            richTextBox2.Text = stopwords.RemoveStopwords(richTextBox1.Text).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //case folding -> merubah semua string ke huruf kecil
            string casefolding = richTextBox1.Text;
            richTextBox1.Text = casefolding.ToLower();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string filtering = stopwords.RemoveStopwords(richTextBox1.Text);
            richTextBox1.Text = null;
            richTextBox1.Text += (filtering +" ");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //tokenizing
            string inputs = richTextBox1.Text;
            String[] ips = inputs.Split(' ');
            richTextBox1.Text = null;
            foreach(var ips2 in ips)
            {
               string s = ips2.Replace("\r\n", "").Replace(" ", "");
               richTextBox1.Text += s+"\r";
                
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
           //richTextBox1.Text = null;
            string[] lines = richTextBox1.Lines;
            var sort = from s in lines
                       orderby s
                       select s;
            richTextBox1.Lines = sort.ToArray();
           

        }

        private void button23_Click(object sender, EventArgs e)
        {
            string[] input = richTextBox1.Lines;
            stemming stemmez = new stemming();
            richTextBox1.Text = null;
            foreach (var outputan in input)
            {
                string s = outputan.Replace("\r\n", "").Replace(" ", "");
                string z = stemmez.stem(s);
                richTextBox1.Text += z+"\r\n";
            }
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            // This regex doesn't support apostrophe so the extension method is better
            string input = richTextBox1.Text;
            var fixedInput = Regex.Replace(input, "[^a-zA-Z0-9% ._]", string.Empty);
            //tokenizing
            var splitted = fixedInput.Split();
            richTextBox1.Text = null;
            foreach (var token in splitted)
            {
                richTextBox1.Text += token+"\r\n";
            }
        }

       
    }
}
