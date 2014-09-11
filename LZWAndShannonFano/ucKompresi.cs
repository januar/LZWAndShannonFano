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
using LZWAndShannonFano.LZW;

namespace LZWAndShannonFano
{
    public partial class ucKompresi : UserControl
    {
        public bool LZW = true;

        int byteProcessed = 0;
        bool procesedFinished = false;
        string compressFile;
        int fileSizeConvert;

        delegate void SetTextCallback(string text, int type);

        public const int LBL_INFO = 1;
        public const int TXT_KOMPRES = 2;
        public const int TXT_KOMPRES_SIZE = 3;
        public const int TXT_KOMPRES_TIME = 4;
        public const int TXT_RASIO = 5;

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
            txtFileSizeKompresi.Text = "";
            txtKompresiFile.Text = "";
            txtWktKompresi.Text = "";
            lblInfo.Text = "";
            txtRasio.Text = "";
            progressBar1.Value = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (procesedFinished == false)
            {
                backgroundWorker1.ReportProgress(byteProcessed);
            }
            backgroundWorker1.ReportProgress(100);
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
            else if (type == TXT_RASIO)
            {
                txtRasio.Text = text;
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

            byteProcessed = 0;
            progressBar1.Value = 0;
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
            progressBar1.Visible = true;
            procesedFinished = false;
            backgroundWorker1.RunWorkerAsync();
            if (LZW)
            {
                SetTextCallback de = new SetTextCallback(SetText);
                string text = File.ReadAllText(txtFile.Text, System.Text.ASCIIEncoding.Default);
                Thread LZWThread = new Thread(
                    new ThreadStart(() =>
                    {
                        sWatch.Start();
                        LZWAndShannonFano.LZW.ANSI ascii = new LZWAndShannonFano.LZW.ANSI();
                        ascii.WriteToFile();

                        LZWAndShannonFano.LZW.Encoder encoder = new LZWAndShannonFano.LZW.Encoder();
                        byte[] b = encoder.Apply(ref byteProcessed, text);
                        compressFile = txtFilename.Text.Substring(0, txtFilename.Text.Length - 4) + ".lzw";
                        procesedFinished = true;
                        fileSizeConvert = b.Length;
                        File.WriteAllBytes(txtSimpan.Text + "\\" + compressFile, b);

                        sWatch.Stop();
                        FileInfo fileinfo = new FileInfo(openFileDialog1.FileName);
                        int rasio = (int)((double)fileSizeConvert / fileinfo.Length * 100);
                        if (IsHandleCreated)
                            this.BeginInvoke(de, new object[] { "", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { fileSizeConvert.ToString() + " Bytes", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { compressFile, TXT_KOMPRES });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { rasio.ToString() + " %", TXT_RASIO});
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
                        SetTextCallback de = new SetTextCallback(SetText);
                        ShannonFano.Encoder encoder = new ShannonFano.Encoder();
                        byte[] image = File.ReadAllBytes(openFileDialog1.FileName);
                        FileInfo info = new FileInfo(openFileDialog1.FileName);
                        string resultPath = txtSimpan.Text;

                        String encodingString = encoder.Encoding(image, ref byteProcessed);
                        byte[] encodingCode = encodingString.ToByteArray();
                
                        compressFile = info.Name.Substring(0, info.Name.Length - 4);
                        File.WriteAllBytes(resultPath + "\\" + compressFile + ".sf", encodingCode);
                        File.WriteAllText(resultPath + "\\" + compressFile + ".sfc", encoder.GetSFCode());

                        sWatch.Stop();
                        int rasio = (int)((double)encodingCode.Length / info.Length * 100);
                        procesedFinished = true;
                        Console.WriteLine(IsHandleCreated + "-" + InvokeRequired);
                        if(IsHandleCreated)
                            this.BeginInvoke(de, new object[] { encodingCode.Length.ToString() + " Bytes", TXT_KOMPRES_SIZE });

                        this.Invoke(de, new object[] { encodingCode.Length.ToString() + " Bytes", TXT_KOMPRES_SIZE });
                        this.Invoke(de, new object[] { compressFile + ".sf", TXT_KOMPRES });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { rasio.ToString() + " %", TXT_RASIO });
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                    }));
                SFThread.Start();
            }
        }

        private int checkImageType(FileInfo info)
        {
            FileType fileType = info.GetFileType();
            if (fileType.extension == "jpg")
            {
                return ShannonFano.SFCode.JPG;
            }
            else if (fileType.extension == "bmp")
            {
                return ShannonFano.SFCode.BMP;
            }
            else if (fileType.extension == "png")
            {
                return ShannonFano.SFCode.PNG;
            }
            else if (fileType.extension == "gif")
            {
                return ShannonFano.SFCode.GIF;
            }
            else {
                return ShannonFano.SFCode.TIFF;
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
