using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

/**
 *** Faruk_Altay 07.07.2018 
 */

namespace erp_proje
{
    public partial class Form1 : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Integrated Security=TRUE;Initial Catalog=erp");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
  
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from yonetici where yonetici_sifre=@yonetici_sifre and yonetici_kullaniciad=@yonetici_kullaniciad", baglanti);
            komut.Parameters.AddWithValue("@yonetici_kullaniciad", textBox1.Text);
            komut.Parameters.AddWithValue("@yonetici_sifre", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                yoneticiislem ynt =new yoneticiislem();
                MessageBox.Show("Giriş Başarılı!");
                ynt.isim = textBox1.Text;
                baglanti.Close();
                this.Hide();
                ynt.isim = textBox1.Text;
                yoneticiislem frmadminislem = new yoneticiislem();
                ynt.isim = textBox1.Text;
                frmadminislem.ShowDialog();
                ynt.isim = textBox1.Text;
                this.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
                baglanti.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
