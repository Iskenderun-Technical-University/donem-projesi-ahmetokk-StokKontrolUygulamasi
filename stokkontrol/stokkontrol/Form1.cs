using System.Data;
using System.Data.SqlClient;

namespace stokkontrol
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StokUygVT;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT UrunId, UrunAd, KategoriAd, UrunStok FROM UrunBilg INNER JOIN Kategori " +
                    "ON UrunBilg.UrunKategori = Kategori.KategoriId Where UrunId like '%"+ textBox1.Text+"%'", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Aratýlamadý!!!");
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            
            form2.ShowDialog();
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT UrunId, UrunAd, KategoriAd, UrunStok FROM UrunBilg INNER JOIN Kategori " +
                    "ON UrunBilg.UrunKategori = Kategori.KategoriId ", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;
                
                
            }
            catch (Exception)
            {
                MessageBox.Show("Baðlantý kurulurken hata oluþtu!!!");
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT UrunId, UrunAd, KategoriAd, UrunStok FROM UrunBilg INNER JOIN Kategori " +
                    "ON UrunBilg.UrunKategori = Kategori.KategoriId ", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource =dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Baðlantý kurulurken hata oluþtu!!!");
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}