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

namespace DHTS_ANA_GİRİŞ
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-7U014QGU; initial catalog=DiyetisyenOtomasyon; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String k_adi = kullanicitext.Text;
            String sifre = sifretext.Text;
            bool kayitli_mi = false;
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from GirisTbl", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (k_adi == dr["kullanici_adi"].ToString() && sifre == dr["sifre"].ToString())
                {
                    kayitli_mi = true;
                    break;
                }
                else kayitli_mi = false;
            }
            if (kayitli_mi == true) MessageBox.Show("Giriş Başarılı");
            else MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı"); 
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            KayitEkran kayitekran = new KayitEkran();
            kayitekran.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            ŞifremiUnuttum sifremiunuttum = new ŞifremiUnuttum();
            sifremiunuttum.Show();
        }
    }
}
