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
    public partial class Form5 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StokUygVT;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM UrunBilg", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;



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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("INSERT INTO UrunBilg(UrunAd, UrunKategori, UrunStok) VALUES (@ad, @kat, @stok)", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox3.Text);
                komut.Parameters.AddWithValue("@kat", Convert.ToInt32(textBox2.Text));
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(textBox4.Text));

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
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM UrunBilg", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;



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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM UrunBilg WHERE UrunId=@id", baglanti);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("UPDATE UrunBilg SET UrunAd=@ad, UrunKategori=@kat, UrunStok=@stok WHERE UrunId=@id", baglanti);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox1.Text));
                komut.Parameters.AddWithValue("@kat", Convert.ToInt32(textBox2.Text));
                komut.Parameters.AddWithValue("@ad", textBox3.Text);
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(textBox4.Text));
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
