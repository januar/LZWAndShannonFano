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
        public const int TXT_FILE_NAME = 5;
        public const int TXT_FILE_TYPE = 6;
        public const int TXT_FILE_SIZE = 7;

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
                openFileDialog1.Filter = "LZW Files (*.lzw) |*.lzw";
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
            if (LZW)
            {
                while (procesedFinished == false)
                {
                    double persen = (double)byteProcessed / maxByte * 100;
                    backgroundWorker1.ReportProgress((int)Math.Ceiling(persen));
                }
                backgroundWorker1.ReportProgress(100);
            }
            else 
            {
                while (procesedFinished == false)
                {
                    backgroundWorker1.ReportProgress(byteProcessed);
                }
            }
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
            else if (type == TXT_FILE_NAME)
            {
                txtFilename.Text = text;
            }
            else if (type == TXT_FILE_SIZE)
            {
                txtFilesize.Text = text;
            }
            else if (type == TXT_FILE_TYPE)
            {
                txtFiletype.Text = text;
            }
        }

        private void btnDelompres_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Silahkan pilih file yang akan didekompresi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtSimpan.Text == "")
            {
                MessageBox.Show("Silahkan pilih folder pemnyimpanan file dekompresi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (new DirectoryInfo(txtSimpan.Text).Exists == false)
            {
                MessageBox.Show("Folder penyimpanan salah", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetTextCallback de = new SetTextCallback(SetText);
            System.Diagnostics.Stopwatch sWatch = new System.Diagnostics.Stopwatch();
            progressBar1.Visible = true;
            procesedFinished = false;
            maxByte = 0;
            byteProcessed = 0;
            progressBar1.Value = 0;
            if (LZW)
            {
                
                string text = File.ReadAllText(txtFile.Text, System.Text.ASCIIEncoding.Default);
                maxByte = text.Length;
                backgroundWorker1.RunWorkerAsync();
                Thread LZWThread = new Thread(
                    new ThreadStart(() =>
                    {
                        //this.Invoke(de, new object[] { "Generate ASCI table", LBL_INFO });
                        sWatch.Start();
                        FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                        this.Invoke(de, new object[] { "Start dencoding " + fileInfo.Name, LBL_INFO });

                        compressFile = txtSimpan.Text + "\\" + fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
                        LZWAndShannonFano.LZW.Decoder decoder = new LZW.Decoder();
                        byte[] bo = File.ReadAllBytes(txtFile.Text);
                        string decodedOutput = decoder.Apply(bo, ref maxByte, ref byteProcessed);
                        File.WriteAllText(compressFile, decodedOutput, System.Text.Encoding.Default);
                        String resultFile = changeExtension(compressFile);
                        pctImage.Image = (Bitmap) Bitmap.FromFile(resultFile);
                        procesedFinished = true;
                        
                        sWatch.Stop();
                        fileInfo = new FileInfo(resultFile);
                        this.Invoke(de, new object[] { fileInfo.Length + " Bytes", TXT_FILE_SIZE });
                        this.Invoke(de, new object[] { fileInfo.Name, TXT_FILE_NAME });
                        this.Invoke(de, new object[] { fileInfo.Extension, TXT_FILE_TYPE });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                    })
                    );
                LZWThread.Start();
            }
            else
            {
                string resultPath = txtSimpan.Text;
                string sfcFile = openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - 3);
                if (!File.Exists(sfcFile + ".sfc"))
                {
                    MessageBox.Show("File SF Code tidak ditemukan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                backgroundWorker1.RunWorkerAsync();
                Thread SFThread = new Thread(
                    new ThreadStart(() =>
                    {
                        sWatch.Start();

                        FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                        this.Invoke(de, new object[] { "Start dencoding " + fileInfo.Name, LBL_INFO });

                        compressFile = fileInfo.Name.Substring(0, fileInfo.Name.Length - 4);
                        ShannonFano.Decoder decoder = new ShannonFano.Decoder();
                        String sfc = File.ReadAllText(sfcFile + ".sfc");
                        decoder.SetSFCode(sfc);

                        StreamReader sr = new StreamReader(openFileDialog1.FileName);
                        int fileType = Int32.Parse(sr.ReadLine());
                        int width = Int32.Parse(sr.ReadLine());
                        int height = Int32.Parse(sr.ReadLine());

                        Bitmap decImage = decoder.Decoding(sr.ReadLine(), width, height, ref byteProcessed);
                        String type = "";
                        if (fileType == ShannonFano.SFCode.BMP)
                        {
                            decImage.Save(resultPath + "\\" + compressFile + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                            type = resultPath + "\\" + compressFile + ".bmp";
                        }
                        else if (fileType == ShannonFano.SFCode.JPG)
                        {
                            decImage.Save(resultPath + "\\" + compressFile + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            type = resultPath + "\\" + compressFile + ".jpg";
                        }
                        else if (fileType == ShannonFano.SFCode.GIF)
                        {
                            decImage.Save(resultPath + "\\" + compressFile + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                            type = resultPath + "\\" + compressFile + ".gif";
                        }
                        else if (fileType == ShannonFano.SFCode.PNG)
                        {
                            decImage.Save(resultPath + "\\" + compressFile + ".png", System.Drawing.Imaging.ImageFormat.Png);
                            type = resultPath + "\\" + compressFile + ".png";
                        }

                        pctImage.Image = decImage;
                        sWatch.Stop();
                        procesedFinished = true;
                        fileInfo = new FileInfo(type);
                        this.Invoke(de, new object[] { fileInfo.Length + " Bytes", TXT_FILE_SIZE });
                        this.Invoke(de, new object[] { fileInfo.Name, TXT_FILE_NAME });
                        this.Invoke(de, new object[] { fileInfo.Extension, TXT_FILE_TYPE });
                        this.Invoke(de, new object[] { Math.Round(sWatch.Elapsed.TotalSeconds, 2).ToString() + " second", TXT_KOMPRES_TIME });
                        this.Invoke(de, new object[] { "", LBL_INFO });
                        MessageBox.Show("Success", "Information", MessageBoxButtons.OK);
                    }));
                SFThread.Start();
            }
        }

        private String changeExtension(string sourceFile)
        {
            FileInfo infoFile = new FileInfo(sourceFile);
            FileType fileType = infoFile.GetFileType();
            String fileName = "";
            if (fileType.extension == "jpg")
            {
                fileName = Path.ChangeExtension(sourceFile, "jpg");
                checkFileExist(fileName);
                File.Move(sourceFile, fileName);
            }
            else if (fileType.extension == "bmp")
            {
                fileName = Path.ChangeExtension(sourceFile, "bmp");
                checkFileExist(fileName);
                File.Move(sourceFile, fileName);
            }
            else if (fileType.extension == "png")
            {
                fileName = Path.ChangeExtension(sourceFile, "png");
                checkFileExist(fileName);
                File.Move(sourceFile, fileName);
            }
            else if (fileType.extension == "gif")
            {
                fileName = Path.ChangeExtension(sourceFile, "gif");
                checkFileExist(fileName);
                File.Move(sourceFile, fileName);
            }
            return fileName;
        }

        private void checkFileExist(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
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
