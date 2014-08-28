namespace LZWAndShannonFano
{
    partial class ucDekompresi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWktKompresi = new System.Windows.Forms.TextBox();
            this.txtFileSizeKompresi = new System.Windows.Forms.TextBox();
            this.txtKompresiFile = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDelompres = new System.Windows.Forms.Button();
            this.txtFilesize = new System.Windows.Forms.TextBox();
            this.txtFiletype = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.pctImage = new System.Windows.Forms.PictureBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblTitleUC = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSimpan = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWktKompresi
            // 
            this.txtWktKompresi.Location = new System.Drawing.Point(323, 305);
            this.txtWktKompresi.Name = "txtWktKompresi";
            this.txtWktKompresi.Size = new System.Drawing.Size(253, 20);
            this.txtWktKompresi.TabIndex = 32;
            // 
            // txtFileSizeKompresi
            // 
            this.txtFileSizeKompresi.Location = new System.Drawing.Point(323, 269);
            this.txtFileSizeKompresi.Name = "txtFileSizeKompresi";
            this.txtFileSizeKompresi.Size = new System.Drawing.Size(253, 20);
            this.txtFileSizeKompresi.TabIndex = 31;
            // 
            // txtKompresiFile
            // 
            this.txtKompresiFile.Location = new System.Drawing.Point(323, 232);
            this.txtKompresiFile.Name = "txtKompresiFile";
            this.txtKompresiFile.Size = new System.Drawing.Size(253, 20);
            this.txtKompresiFile.TabIndex = 30;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 345);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(468, 23);
            this.progressBar1.TabIndex = 29;
            this.progressBar1.Visible = false;
            // 
            // btnDelompres
            // 
            this.btnDelompres.Location = new System.Drawing.Point(502, 345);
            this.btnDelompres.Name = "btnDelompres";
            this.btnDelompres.Size = new System.Drawing.Size(75, 23);
            this.btnDelompres.TabIndex = 28;
            this.btnDelompres.Text = "Dekompres";
            this.btnDelompres.UseVisualStyleBackColor = true;
            this.btnDelompres.Click += new System.EventHandler(this.btnDelompres_Click);
            // 
            // txtFilesize
            // 
            this.txtFilesize.Location = new System.Drawing.Point(323, 193);
            this.txtFilesize.Name = "txtFilesize";
            this.txtFilesize.Size = new System.Drawing.Size(253, 20);
            this.txtFilesize.TabIndex = 27;
            // 
            // txtFiletype
            // 
            this.txtFiletype.Location = new System.Drawing.Point(323, 152);
            this.txtFiletype.Name = "txtFiletype";
            this.txtFiletype.Size = new System.Drawing.Size(253, 20);
            this.txtFiletype.TabIndex = 26;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(323, 111);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(253, 20);
            this.txtFilename.TabIndex = 25;
            // 
            // pctImage
            // 
            this.pctImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctImage.Location = new System.Drawing.Point(13, 97);
            this.pctImage.Name = "pctImage";
            this.pctImage.Size = new System.Drawing.Size(291, 226);
            this.pctImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctImage.TabIndex = 24;
            this.pctImage.TabStop = false;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(94, 31);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(483, 20);
            this.txtFile.TabIndex = 23;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(13, 28);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 22;
            this.btnOpenFile.Text = "Buka File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblTitleUC
            // 
            this.lblTitleUC.AutoSize = true;
            this.lblTitleUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleUC.Location = new System.Drawing.Point(10, 9);
            this.lblTitleUC.Name = "lblTitleUC";
            this.lblTitleUC.Size = new System.Drawing.Size(163, 13);
            this.lblTitleUC.TabIndex = 21;
            this.lblTitleUC.Text = "Dekompresi LZW Algorithim";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(322, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Waktu kompresi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Ukuran file kompresi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "File kompresi";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(10, 329);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 13);
            this.lblInfo.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "File size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "File type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "File name";
            // 
            // txtSimpan
            // 
            this.txtSimpan.Location = new System.Drawing.Point(94, 60);
            this.txtSimpan.Name = "txtSimpan";
            this.txtSimpan.Size = new System.Drawing.Size(483, 20);
            this.txtSimpan.TabIndex = 41;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(13, 57);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 40;
            this.btnSimpan.Text = "Simpan File";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // ucDekompresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSimpan);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWktKompresi);
            this.Controls.Add(this.txtFileSizeKompresi);
            this.Controls.Add(this.txtKompresiFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDelompres);
            this.Controls.Add(this.txtFilesize);
            this.Controls.Add(this.txtFiletype);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.pctImage);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.lblTitleUC);
            this.Name = "ucDekompresi";
            this.Size = new System.Drawing.Size(600, 380);
            ((System.ComponentModel.ISupportInitialize)(this.pctImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWktKompresi;
        private System.Windows.Forms.TextBox txtFileSizeKompresi;
        private System.Windows.Forms.TextBox txtKompresiFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnDelompres;
        private System.Windows.Forms.TextBox txtFilesize;
        private System.Windows.Forms.TextBox txtFiletype;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.PictureBox pctImage;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label lblTitleUC;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSimpan;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
