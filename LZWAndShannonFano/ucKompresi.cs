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

using FileTypeDetective;

namespace LZWAndShannonFano
{
    public partial class ucKompresi : UserControl
    {
        public bool LZW = true;

        int maxByte = 0;
        int byteProcessed = 0;
        bool procesedFinished = false;
        string compressFile;
        int fileSizeConvert;

        delegate void SetTextCallback(string text, int type);

        public const int LBL_INFO = 1;
        public const int TXT_KOMPRES = 2;
        public const int TXT_KOMPRES_SIZE = 3;
        public const int TXT_KOMPRES_TIME = 4;

        public ucKompresi(bool lzw)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            openFileDialog1.FileName = "";
            this.LZW = lzw;
            if (LZW)
            {
                lblTitleUC.Text = "Kompresi LZW Algorithim";
            }
            else {
                lblTitleUC.Text = "Kompresi Shannon-Fano Algorithim";
            }
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
            FileType type = fileinfo.GetFileType();
            txtFilename.Text = fileinfo.Name;
            txtFiletype.Text = fileinfo.Extension;
            txtFilesize.Text = fileinfo.Length.ToString() + " Bytes";

            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
            txtFileSizeKompresi.Text = "";
            txtKompresiFile.Text = "";
            txtWktKompresi.Text = "";
            lblInfo.Text = "";
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

        private void SetText(string text, int type)
        {
            if (type == LBL_INFO)
            {
                lblInfo.Text = text;
            }
            else if (type == TXT_KOMPRES)
            {
                txtKompresiFile.Text = text;
            }
            else if (type == TXT_KOMPRES_SIZE)
            {
                txtFileSizeKompresi.Text = text;
            }
            else if (type == TXT_KOMPRES_TIME)
            {
                txtWktKompresi.Text = text;
            }
        }

        private void btnKompres_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Silahkan pilih file yang akan dikompresi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSimpan.Text == "")
            {
                MessageBox.Show("Silahkan pilih folder pemnyimpanan file kompresi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (new DirectoryInfo(txtSimpan.Text).Exists == false)
            {
                MessageBox.Show("Folder penyimpanan salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetTextCallback de = new SetTextCallback(SetText);
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
            if (LZW)
            {
                progressBar1.Visible = true;
                string text = File.ReadAllText(txtFile.Text, System.Text.ASCIIEncoding.Default);
                maxByte = text.Length;
                procesedFinished = false;
                backgroundWorker1.RunWorkerAsync();
                Thread LZWThread = new Thread(
                    new ThreadStart(() =>
                    {
                        //this.Invoke(de, new object[] { "Generate ASCI table", LBL_INFO });
                        sWatch.Start();
                        LZWAndShannonFano.LZW.ANSI ascii = new LZWAndShannonFano.LZW.ANSI();
                        ascii.WriteToFile();
                        this.Invoke(de, new object[] { "ASCI table generated", LBL_INFO });

                        LZWAndShannonFano.LZW.Encoder encoder = new LZWAndShannonFano.LZW.Encoder();
                        this.Invoke(de, new object[] { "Start encoding " + txtFilename.Text, LBL_INFO });
                        byte[] b = encoder.Apply(ref byteProcessed, text);
                        compressFile = txtFilename.Text.Substring(0, txtFilename.Text.Length - 4) + ".lzw";
                        procesedFinished = true;
                        fileSizeConvert = b.Length;
                        File.WriteAllBytes(txtSimpan.Text + "//" + compressFile, b);

                        sWatch.Stop();
                        this.Invoke(de, new object[] { fileSizeConvert.ToString() + " Bytes", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { compressFile, TXT_KOMPRES });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                    })
                    );
                LZWThread.Start();
            }
            else {

                Thread SFThread = new Thread(
                    new ThreadStart(() =>
                    {
                        sWatch.Start();

                        ShannonFano.Encoder encoder = new ShannonFano.Encoder();
                        Bitmap image = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                        FileInfo info = new FileInfo(openFileDialog1.FileName);
                        string imageType = checkImageType(info);

                        String encodingCode = encoder.Encoding(image);
                        encodingCode = "1\n" + image.Width + "\n" + image.Height + "\n" + encodingCode;

                        compressFile = info.Name.Substring(0, info.Name.Length - 4);
                        File.WriteAllText(compressFile + ".sf", encodingCode);
                        File.WriteAllText(compressFile + ".sfc", encoder.GetSFCode());

                        sWatch.Stop();

                        this.Invoke(de, new object[] { info.Length + " Bytes", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { compressFile + ".sf", TXT_KOMPRES });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                    }));
                SFThread.Start();
            }
        }

        private string checkImageType(FileInfo info)
        {
            FileType fileType = info.GetFileType();
            if (fileType.extension == "jpg")
            {
                return ShannonFano.SFCode.JPG.ToString();
            }
            else if (fileType.extension == "bmp")
            {
                return ShannonFano.SFCode.BMP.ToString();
            }
            else if (fileType.extension == "png")
            {
                return ShannonFano.SFCode.PNG.ToString();
            }
            else if (fileType.extension == "gif")
            {
                return ShannonFano.SFCode.GIF.ToString();
            }
            else {
                return ShannonFano.SFCode.TIFF.ToString();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            DialogResult path = folderBrowserDialog1.ShowDialog();
            if (path == DialogResult.OK)
            {
                txtSimpan.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
