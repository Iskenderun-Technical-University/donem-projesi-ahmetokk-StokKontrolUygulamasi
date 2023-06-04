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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace stokkontrol
{
    public partial class Form6 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StokUygVT;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Kategori", baglanti);
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

        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT *FROM Kategori", baglanti);
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox2.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("INSERT INTO Kategori(KategoriAd) VALUES (@ad)", baglanti);
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
               
              
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Kategori WHERE KategoriId=@id", baglanti);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox3.Text));
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
                SqlCommand komut = new SqlCommand("UPDATE Kategori SET KategoriAd=@ad WHERE KategoriId=@id", baglanti);
                komut.Parameters.AddWithValue("@id", Convert.ToInt32(textBox3.Text));
                komut.Parameters.AddWithValue("@ad", textBox2.Text);
         
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
