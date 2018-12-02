namespace PDFReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RichTextBoxPdfText = new System.Windows.Forms.RichTextBox();
            this.ButtonRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonBrowse.Location = new System.Drawing.Point(277, 33);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 31);
            this.ButtonBrowse.TabIndex = 0;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxLocation.Location = new System.Drawing.Point(15, 37);
            this.TextBoxLocation.Name = "TextBoxLocation";
            this.TextBoxLocation.Size = new System.Drawing.Size(254, 22);
            this.TextBoxLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Browse:";
            // 
            // RichTextBoxPdfText
            // 
            this.RichTextBoxPdfText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBoxPdfText.Location = new System.Drawing.Point(18, 79);
            this.RichTextBoxPdfText.Name = "RichTextBoxPdfText";
            this.RichTextBoxPdfText.Size = new System.Drawing.Size(416, 331);
            this.RichTextBoxPdfText.TabIndex = 3;
            this.RichTextBoxPdfText.Text = "";
            // 
            // ButtonRead
            // 
            this.ButtonRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRead.Location = new System.Drawing.Point(359, 33);
            this.ButtonRead.Name = "ButtonRead";
            this.ButtonRead.Size = new System.Drawing.Size(75, 31);
            this.ButtonRead.TabIndex = 4;
            this.ButtonRead.Text = "Read";
            this.ButtonRead.UseVisualStyleBackColor = true;
            this.ButtonRead.Click += new System.EventHandler(this.ButtonRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 422);
            this.Controls.Add(this.ButtonRead);
            this.Controls.Add(this.RichTextBoxPdfText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxLocation);
            this.Controls.Add(this.ButtonBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox TextBoxLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RichTextBoxPdfText;
        private System.Windows.Forms.Button ButtonRead;
    }
}

