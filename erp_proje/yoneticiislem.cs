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
using System.Data.OleDb;

/**
 *** Faruk_Altay 07.07.2018 
 */

namespace erp_proje
{
    public partial class yoneticiislem : Form
    {   
        public string isim="boş";
        public SqlConnection myConn = new SqlConnection("Data Source=.;Integrated Security=TRUE;Initial Catalog=erp");
        public string id;
        SqlCommand komut2;
        public string satis_id;
        public string yol;
        public string yol2;
         SqlDataAdapter da;
            DataTable dt;
        public yoneticiislem()
        {
            InitializeComponent();
            radioButton1.Checked=true;
            radioButton4.Checked = true;
        }

        private void yoneticiislem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'erpDataSet8.urun' table. You can move, or remove it, as needed.
            this.urunTableAdapter4.Fill(this.erpDataSet8.urun);
            // TODO: This line of code loads data into the 'erpDataSet7.urun' table. You can move, or remove it, as needed.
            this.urunTableAdapter3.Fill(this.erpDataSet7.urun);
            // TODO: This line of code loads data into the 'erpDataSet6.urun' table. You can move, or remove it, as needed.
            this.urunTableAdapter2.Fill(this.erpDataSet6.urun);
            // TODO: This line of code loads data into the 'erpDataSet5.urun' table. You can move, or remove it, as needed.
            this.urunTableAdapter1.Fill(this.erpDataSet5.urun);
            // TODO: This line of code loads data into the 'erpDataSet3.satis' table. You can move, or remove it, as needed.
            myConn.Open();
            // TODO: This line of code loads data into the 'erpDataSet2.urun' table. You can move, or remove it, as needed.
            this.urunTableAdapter.Fill(this.erpDataSet2.urun);
            // TODO: This line of code loads data into the 'erpDataSet1.kategori' table. You can move, or remove it, as needed.
            this.kategoriTableAdapter1.Fill(this.erpDataSet1.kategori);
            // TODO: This line of code loads data into the 'erpDataSet.kategori' table. You can move, or remove it, as needed.
            this.kategoriTableAdapter.Fill(this.erpDataSet.kategori);
            da = new SqlDataAdapter("select stok,urunad,urunkategori from urun", myConn);
            DataSet ds = new DataSet();
            da.Fill(ds, "urun");
            dataGridView2.DataSource = ds.Tables["urun"];
            dataGridView1.DataSource = ds.Tables["urun"];
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView1.DataSource = dt;

            da = new SqlDataAdapter("select * from satis", myConn);
            DataSet ds223 = new DataSet();
            da.Fill(ds223, "satis");
            dataGridView5.DataSource = ds223.Tables["satis"];
            dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;

            da = new SqlDataAdapter("select stok,urunad,urunkategori from urun", myConn);
            DataSet ds2223 = new DataSet();
            da.Fill(ds2223, "satis");
            dataGridView4.DataSource = ds2223.Tables["satis"];
            dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            myConn.Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(radioButton1.Checked==true)
            {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            else
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
            
            if (radioButton1.Checked == true)
            {
                
                myConn.Open();
                da = new SqlDataAdapter("select stok,urunad,urunkategori from urun where stok like '" + textBox3.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView2.DataSource = ds.Tables["urun"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                myConn.Close();
            }
            if (radioButton2.Checked == true)
            {
               
                myConn.Open();
                da = new SqlDataAdapter("select stok,urunad,urunkategori from urun where urunad like '" + textBox3.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView2.DataSource = ds.Tables["urun"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                myConn.Close();
            }
            if (radioButton3.Checked == true)
            {
               
                myConn.Open();
                da = new SqlDataAdapter("select stok,urunad,urunkategori from urun where urunkategori like '" + textBox3.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView2.DataSource = ds.Tables["urun"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                myConn.Close();
            }
           
        }

        private void tbtel_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbsifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tbadres_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            myConn.Open();
            if (tbad.Text != string.Empty && tbsifre.Text != string.Empty && listBox1.SelectedItems.Count != 0)
            {
                    SqlCommand komut = new SqlCommand("Select * from urun where urunad=@urunad", myConn);
                    komut.Parameters.AddWithValue("@urunad", tbad.Text);
                  
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Böyle bir Ürün Bulunmaktadır!");
                        myConn.Close();
                        tbad.Text = "";
                        tbsifre.Text="";
                    }

                    else
                    {
                       
                        
                        dr.Close();
                        SqlCommand komut2 = new SqlCommand("insert into urun(stok,urunad,urunkategori) values('" + Convert.ToInt32(tbsifre.Text) + "','" + tbad.Text +"','" +listBox1.SelectedValue.ToString()+ "')", myConn);
                        komut2.ExecuteNonQuery();
                        myConn.Close();
                        MessageBox.Show("Kaydınız Başarı ile gerçekleşti.");
                        da = new SqlDataAdapter("select stok,urunad,urunkategori from urun ", myConn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "urun");
                        dataGridView2.DataSource = ds.Tables["urun"];
                        dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                        myConn.Close();

                    }
                    myConn.Close();
                }
               else MessageBox.Show("Boş Alan Bırakmayınız!");
               myConn.Close();
  
               
        }

        private void tbsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbad_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
            myConn.Open();
            comboBox2.Items.Clear();
            if (comboBox1.SelectedIndex==0)
            {
              komut2 = new SqlCommand("select urunad From urun Where urunkategori='Elektronik'", myConn);

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                 komut2 = new SqlCommand("select urunad From urun Where urunkategori='Giyim'", myConn);

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Gida'", myConn);

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Aksesuar'", myConn);

            }
            SqlDataReader oku;
            oku = komut2.ExecuteReader();

            while (oku.Read())
            {
                comboBox2.Items.Add(oku[0].ToString());
            }
            myConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox4.Text != string.Empty && textBox2.Text != string.Empty && comboBox1.Text != string.Empty && comboBox2.Text != string.Empty)
            {
                myConn.Open();
                SqlDataAdapter da;
                DataTable dt;
                da = new SqlDataAdapter("Select stok from urun where urunad='" + comboBox2.Text + "'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView3.DataSource = ds.Tables["urun"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                string a = dataGridView3.Rows[0].Cells[0].Value.ToString();
                int adet = Convert.ToInt32(textBox1.Text);
                int deger = (Convert.ToInt32(a) - (Convert.ToInt32(textBox1.Text)));
                if (deger >= 0)
                {
                        
                        MessageBox.Show("İşlem Başarılı!");
                        DateTime tarih = DateTime.Now.Date;
                        SqlCommand komut21 = new SqlCommand("insert into satis(kategori,ad,soyad,urunadi,tarih,adet) values('" + (comboBox1.Text) + "','" + textBox2.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + Convert.ToInt32(textBox1.Text)+"')", myConn);
                        komut21.ExecuteNonQuery();
                        SqlCommand cmd = new SqlCommand("UPDATE urun SET stok=@stok WHERE urunad='" + comboBox2.Text+"'", myConn);
                       

                        
                        
                            cmd.Parameters.AddWithValue("@stok", deger);
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da3;
                            DataTable dt3;
                            da3 = new SqlDataAdapter("select * from urun ", myConn);
                            DataSet ds3 = new DataSet();
                            da3.Fill(ds3, "urun");
                            dataGridView1.DataSource = ds3.Tables["urun"];
                            dt3 = new DataTable();
                            da3.Fill(dt3);
                            dataGridView1.DataSource = dt3;
                        }
                        else { MessageBox.Show("Seçilen Ürün Stokta Yeteri Kadar Bulunmamaktadır!"); }

                     
                         myConn.Close();
                   
              }
             else MessageBox.Show("Bütün seçimleri tam yapınız!");

            DataTable dt45 = new DataTable();
            SqlDataAdapter da45 = new SqlDataAdapter("select stok,urunad,urunkategori from urun", myConn);
            DataSet ds45 = new DataSet();
            da45.Fill(ds45, "urun");
            dataGridView1.DataSource = ds45.Tables["urun"];
            dt45 = new DataTable();
            da45.Fill(dt45);
            dataGridView1.DataSource = dt45;

            }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {

                myConn.Open();
                da = new SqlDataAdapter("select * from satis where kategori like '" + textBox5.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "satis");
                dataGridView5.DataSource = ds.Tables["satis"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView5.DataSource = dt;
                myConn.Close();
            }
            if (radioButton5.Checked == true)
            {

                myConn.Open();
                da = new SqlDataAdapter("select * from satis where ad like '" + textBox5.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "satis");
                dataGridView5.DataSource = ds.Tables["satis"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView5.DataSource = dt;
                myConn.Close();
            }
            if (radioButton6.Checked == true)
            {

                myConn.Open();
                da = new SqlDataAdapter("select * from satis where urunadi like '" + textBox5.Text + "%'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "satis");
                dataGridView5.DataSource = ds.Tables["satis"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView5.DataSource = dt;
                myConn.Close();
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         


        }

        private void tbsifre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            myConn.Open();
            comboBox3.Items.Clear();
            if (comboBox4.SelectedIndex == 0)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Elektronik'", myConn);

            }
            else if (comboBox4.SelectedIndex == 1)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Giyim'", myConn);

            }
            else if (comboBox4.SelectedIndex == 2)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Gida'", myConn);

            }
            else if (comboBox4.SelectedIndex == 3)
            {
                komut2 = new SqlCommand("select urunad From urun Where urunkategori='Aksesuar'", myConn);

            }
            SqlDataReader oku;
            oku = komut2.ExecuteReader();

            while (oku.Read())
            {
                comboBox3.Items.Add(oku[0].ToString());
            }
            myConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != string.Empty  && comboBox3.Text != string.Empty && comboBox4.Text != string.Empty)
            {
                myConn.Open();
                SqlDataAdapter da;
                DataTable dt;
                da = new SqlDataAdapter("Select stok from urun where urunad='" + comboBox3.Text + "'", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView6.DataSource = ds.Tables["urun"];
                dt = new DataTable();
                da.Fill(dt);
                dataGridView6.DataSource = dt;
                string a = dataGridView6.Rows[0].Cells[0].Value.ToString();
                int adet = Convert.ToInt32(a) +Convert.ToInt32(textBox6.Text);
           
                    
                    SqlCommand cmd = new SqlCommand("UPDATE urun SET stok=@stok WHERE urunad='" + comboBox3.Text + "'", myConn);


                    cmd.Parameters.AddWithValue("@stok", adet);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter da3;
                    DataTable dt3;
                    da3 = new SqlDataAdapter("select stok,urunad,urunkategori from urun ", myConn);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "urun");
                    dataGridView4.DataSource = ds3.Tables["urun"];
                    dt3 = new DataTable();
                    da3.Fill(dt3);
                    dataGridView4.DataSource = dt3;
            }
            else { MessageBox.Show("Bütün Alanları Doldurunuz!"); }


                myConn.Close();


        
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            myConn.Open();
            if (dataGridView7.SelectedRows.Count != 0)
            {
                id = dataGridView7.SelectedRows[0].Cells[0].Value.ToString();

                SqlCommand komut = new SqlCommand("delete from urun where stokIDD=@stokIDD ", myConn);
                komut.Parameters.AddWithValue("@stokIDD", dataGridView7.CurrentRow.Cells[0].Value);
                komut.ExecuteNonQuery();
                MessageBox.Show("Seçilen veri silindi.");

                SqlDataAdapter da = new SqlDataAdapter("select * from urun  ", myConn);
                DataSet ds = new DataSet();
                da.Fill(ds, "urun");
                dataGridView7.DataSource = ds.Tables["urun"];
                myConn.Close();
            }
            else
            {
                MessageBox.Show("Silme işlemi için satır seçiniz!");
                myConn.Close();

            }
                
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da;
            DataTable dt;
            myConn.Open();
            da = new SqlDataAdapter("select * from urun where urunad like '" + textBox7.Text + "%'", myConn);
            DataSet ds = new DataSet();
            da.Fill(ds, "urun");
            dataGridView7.DataSource = ds.Tables["urun"];
            dt = new DataTable();
            da.Fill(dt);
            dataGridView7.DataSource = dt;
            myConn.Close();
        }  

        }
    }

