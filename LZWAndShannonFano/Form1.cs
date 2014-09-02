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
