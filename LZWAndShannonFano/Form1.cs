using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LZWAndShannonFano
{
    public partial class frmUtama : Form
    {
        public frmUtama()
        {
            InitializeComponent();
        }

        private void readImage()
        {

        }

        private void lZWAlgorithimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucKompresi ucKompresi = new ucKompresi();
            this.Controls.Add(ucKompresi);
            ucKompresi.Location = new Point(0, 24);
        }
    }
}
