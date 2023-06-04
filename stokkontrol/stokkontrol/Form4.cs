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

namespace stokkontrol
{
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StokUygVT;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM CalisanBilg", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;
                this.dataGridView1.Columns["CalisanSifre"].Visible = false;


            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("INSERT INTO CalisanBilg(CalisanAd, CalisanSoyad, CalisanSifre) VALUES (@ad, @soyad, @sifre)", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
                komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Bir hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM CalisanBilg", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;
                this.dataGridView1.Columns["CalisanSifre"].Visible = false;
            }


            catch (Exception)
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand komut = new SqlCommand("DELETE FROM CalisanBilg WHERE CalisanID=@id", baglanti);
            komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
            baglanti.Open();
            komut.ExecuteNonQuery();
               }
            catch
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("UPDATE CalisanBilg SET CalisanAd=@ad, CalisanSoyad=@soyad, CalisanSifre=@sifre WHERE CalisanID=@id", baglanti);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
                komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Bağlantı kurulurken hata oluştu!!!");
            }
            finally
            {
                baglanti.Close();

            }
        }
    }
}
