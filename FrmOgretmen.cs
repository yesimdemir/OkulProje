using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OkulProje
{
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void btnKulupİslemler_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void btnDersİslemler_Click(object sender, EventArgs e)
        {
            FrmDersler frm = new FrmDersler();
            frm.Show();
        }

        private void btnOgrenciİslemler_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void btnSinavNotlar_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fr = new FrmSinavNotlar();
            fr.Show();
        }
    }
}
