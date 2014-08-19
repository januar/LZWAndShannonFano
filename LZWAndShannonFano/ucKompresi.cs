using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace LZWAndShannonFano
{
    public partial class ucKompresi : UserControl
    {
        public bool LZW = true;

        String message = "";
        int maxByte = 0;
        int byteProcessed = 0;
        bool procesedFinished = false;

        delegate void SetTextCallback(string text);

        public ucKompresi()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
            pctImage.Image = image;
            txtFile.Text = openFileDialog1.FileName;

            FileInfo fileinfo = new FileInfo(openFileDialog1.FileName);
            txtFilename.Text = fileinfo.Name;
            txtFiletype.Text = fileinfo.Extension;
            txtFilesize.Text = fileinfo.Length.ToString() + " Bytes";

            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Your background task goes here
            while(procesedFinished == false)
            {
                // Report progress to 'UI' thread
                double persen = (double)byteProcessed / maxByte * 100;
                backgroundWorker1.ReportProgress((int)Math.Ceiling(persen));
                //Console.WriteLine(persen);
                // Simulate long task
                //System.Threading.Thread.Sleep(5);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            //Console.WriteLine("change : " + e.ProgressPercentage);
            progressBar1.Value = e.ProgressPercentage;
        }

        private void SetText(string text)
        {
            if (this.lblInfo.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblInfo.Text = text;
            }
        }

        private void btnKompres_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            string text = File.ReadAllText(txtFile.Text, System.Text.ASCIIEncoding.Default);
            maxByte = text.Length;
            procesedFinished = false;
            backgroundWorker1.RunWorkerAsync();
            if (LZW)
            {
                Thread LZWThread = new Thread(
                    new ThreadStart(() =>
                    {
                        LZWAndShannonFano.LZW.ANSI ascii = new LZWAndShannonFano.LZW.ANSI();
                        ascii.WriteToFile();

                        using (LZWAndShannonFano.LZW.Encode encoder = new LZWAndShannonFano.LZW.Encode())
                        {
                            byte[] b = encoder.Apply(ref byteProcessed, text);
                            string compressFile = txtFilename.Text.Substring(0, txtFilename.Text.Length - 4) + ".lzw";
                            procesedFinished = true;
                            File.WriteAllBytes(compressFile, b);
                        }                  
                    })
                    );
                LZWThread.Start();
            }
        }
    }
}
