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
    public partial class ucDekompresi : UserControl
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

        public ucDekompresi(bool lzw)
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            openFileDialog1.FileName = "";
            this.LZW = lzw;
            if (LZW)
            {
                lblTitleUC.Text = "Dekompresi LZW Algorithim";
            }
            else
            {
                lblTitleUC.Text = "Dekompresi Shannon-Fano Algorithim";
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (LZW)
            {
                //openFileDialog1.Filter = "LZW Files (*.lzw) |*.lzw";
            }
            else
            {
                openFileDialog1.Filter = "Shannon Fano Files (*.sf) |*.sf";
            }
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFile.Text = openFileDialog1.FileName;

            FileInfo fileinfo = new FileInfo(openFileDialog1.FileName);
            txtKompresiFile.Text = fileinfo.Name;
            txtFileSizeKompresi.Text = fileinfo.Length.ToString() + " Bytes";

            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
            txtFilename.Text = "";
            txtFilesize.Text = "";
            txtWktKompresi.Text = "";
            lblInfo.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Your background task goes here
            while (procesedFinished == false)
            {
                // Report progress to 'UI' thread
                double persen = (double)byteProcessed / maxByte * 100;
                Console.WriteLine(persen + "-" + byteProcessed + "-"+ maxByte);
                backgroundWorker1.ReportProgress((int)Math.Ceiling(persen));
            }
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
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

        private void btnDelompres_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Silahkan pilih file yang akan didekompresi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetTextCallback de = new SetTextCallback(SetText);
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
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
                        //this.Invoke(de, new object[] { "Generate ASCI table", LBL_INFO });
                        sWatch.Start();
                        this.Invoke(de, new object[] { "Start encoding " + txtFilename.Text, LBL_INFO });
                        
                        LZWAndShannonFano.LZW.Decoder decoder = new LZW.Decoder();
                        byte[] bo = File.ReadAllBytes(txtFile.Text);
                        string decodedOutput = decoder.Apply(bo, ref maxByte, ref byteProcessed);
                        compressFile = txtFile.Text.Substring(0, txtFile.Text.Length - 4);
                        File.WriteAllText(compressFile, decodedOutput, System.Text.Encoding.Default);
                        changeExtension(compressFile);
                        procesedFinished = true;
                        
                        sWatch.Stop();
                        //this.Invoke(de, new object[] { fileSizeConvert.ToString() + " Bytes", TXT_KOMPRES_SIZE });
                        //this.Invoke(de, new object[] { compressFile, TXT_KOMPRES });
                        //this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                    })
                    );
                LZWThread.Start();
            }
        }

        private void changeExtension(string sourceFile)
        {
            FileInfo infoFile = new FileInfo(sourceFile);
            FileType fileType = infoFile.GetFileType();
            if (fileType.extension == "jpg")
            {
                File.Move(sourceFile, Path.ChangeExtension(sourceFile, "jpg"));
            }
            else if (fileType.extension == "bmp")
            {
                File.Move(sourceFile, Path.ChangeExtension(sourceFile, "bmp"));
            }
            else if (fileType.extension == "png")
            {
                File.Move(sourceFile, Path.ChangeExtension(sourceFile, "png"));
            }
            else if (fileType.extension == "gif")
            {
                File.Move(sourceFile, Path.ChangeExtension(sourceFile, "gif"));
            }
        }
    }
}
