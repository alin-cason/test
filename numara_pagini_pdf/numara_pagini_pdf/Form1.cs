using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.factories;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace numara_pagini_pdf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string report = "";

            string[] pdfuri = Directory.GetFiles(textBox1.Text, "*.pdf");
            foreach (string pdf in pdfuri)
            {
                PdfReader reader = new PdfReader(pdf);

                int total = reader.NumberOfPages;

                reader.Close();

                report = report + Path.GetFileName(pdf) + "\t" + total.ToString() + "\n";
            }

            File.WriteAllText(textBox1.Text + "\\__report.txt", report);
            MessageBox.Show("Done!");
        }
    }
}
