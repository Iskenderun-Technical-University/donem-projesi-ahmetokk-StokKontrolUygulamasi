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

namespace stokkontrol
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=  new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=StokUygVT;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sql = "Select * From CalisanBilg Where CalisanID=@id AND CalisanSifre=@sifre";
                SqlParameter prm1 = new SqlParameter("id", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifre", textBox2.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);

                int x = 0;
                if (dt.Rows.Count>0)
                {
                    x = 1;
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();


                }
                if (x!=1)
                    MessageBox.Show("ID veya Şifre yanlış!!!");
                
            }


            catch (Exception)
            {  
                MessageBox.Show("ID veya Şifre yanlış!!!");
            }
            baglanti.Close();
        }
    }
}
