using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProje
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-P9D39CIC;Initial Catalog=DbOkul;Integrated Security=True");


        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblkulupler",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
           
            ds.OgrenciEkle(txtAd.Text, txtSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci Ekleme Yapıldı");
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = comboBox1.SelectedValue.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtId.Text)); 

        }
        string cinsiyet;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (cinsiyet == "Kız")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if(cinsiyet == "Erkek")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtAd.Text, txtSoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()), c,int.Parse(txtId.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          dataGridView1.DataSource= ds.OgrenciGetir(txtAra.Text);
        }
    }
}
