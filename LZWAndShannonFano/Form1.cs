using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using LZWAndShannonFano.LZW;

namespace LZWAndShannonFano
{
    public partial class frmUtama : Form
    {
        public frmUtama()
        {
            InitializeComponent();

            //StreamReader sr = new StreamReader("F:\\project\\Samuel Tarigan\\App\\200x200.sf");
            //sr.ReadLine(); sr.ReadLine(); sr.ReadLine();
            //String binary = sr.ReadLine();
            //byte[] binaryByte = binary.ToByteArray();
            ////File.WriteAllBytes("test_byte.sf", binaryByte);

            ////byte[] bit = File.ReadAllBytes("test_byte.sf");
            ////String bitBinary = bit.GetBinaryString();
            ////File.WriteAllText("test_string.sf", bitBinary);

            //String test = File.ReadAllText("test_string.sf");
            //byte[] encodingCode = test.ToByteArray();
            //byte[] width = BitConverter.GetBytes(200);
            //byte[] height = BitConverter.GetBytes(200);
            //byte[] resultEncoding = new byte[encodingCode.Length + width.Length + height.Length + 3];
            //resultEncoding[0] = Convert.ToByte(1);
            //resultEncoding[1] = Convert.ToByte(width.Length);
            //resultEncoding[2] = Convert.ToByte(height.Length);
            //width.CopyTo(resultEncoding, 3);
            //height.CopyTo(resultEncoding, 3 + width.Length);
            //encodingCode.CopyTo(resultEncoding, 3 + width.Length + height.Length);
            //File.WriteAllBytes("test_byte2.sf", resultEncoding);
        }

        private void Kompresi(bool LZW)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType().Name == "ucDekompresi")
                {
                    ucDekompresi delete = (ucDekompresi)item;
                    this.Controls.Remove(delete);
                }

                if (item.GetType().Name == "ucKompresi")
                {
                    ucKompresi delete = (ucKompresi)item;
                    this.Controls.Remove(delete);
                }
            }
            ucKompresi ucKompresi = new ucKompresi(LZW);
            this.Controls.Add(ucKompresi);
            ucKompresi.Location = new Point(0, 24);
        }

        private void Dekompresi(bool LZW)
        {
            foreach (var item in this.Controls)
            {
                if (item.GetType().Name == "ucDekompresi")
                {
                    ucDekompresi delete = (ucDekompresi)item;
                    this.Controls.Remove(delete);
                }

                if (item.GetType().Name == "ucKompresi")
                {
                    ucKompresi delete = (ucKompresi)item;
                    this.Controls.Remove(delete);
                }
            }
            ucDekompresi ucDekompresi = new ucDekompresi(LZW);
            this.Controls.Add(ucDekompresi);
            ucDekompresi.Location = new Point(0, 24);
        }

        private void lZWAlgorithimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kompresi(true);
        }

        private void lZWAlgorithimToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dekompresi(true);
        }
        private void shannonFanoAlgorithimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kompresi(false);
        }

        private void shannonFanoAlgorithimToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Dekompresi(false);
        }
    }
}
