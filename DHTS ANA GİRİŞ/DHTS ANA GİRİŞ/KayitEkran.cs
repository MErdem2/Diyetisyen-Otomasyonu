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
    public partial class KayitEkran : Form
    {
        public KayitEkran()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source = LAPTOP-7U014QGU; initial catalog=DiyetisyenOtomasyon; Integrated Security=TRUE");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void KayitEkran_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(kullanici_adi.Text == "" && sifretxt.Text == "" && sifreonay.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Kısmı Boş Bırakılamaz", "Kayıt Olma Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(sifretxt.Text == sifreonay.Text && kullanici_adi.Text != "")
            {
                conn.Open();
                String register = "INSERT INTO GirisTbl VALUES ('" + kullanici_adi.Text + "','" + sifretxt.Text + "','" + email.Text + "')";
                cmd = new SqlCommand(register, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Hesabınız Başarılı Bir Şekilde Oluşturuldu", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Parola Eşleşmiyor", "Lütfen Yeniden Deneyin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sifretxt.Text = "";
                sifreonay.Text = "";
                sifretxt.Focus();
            }
        }

        private void sifregosbut_CheckedChanged(object sender, EventArgs e)
        {
            if(sifregosbut.Checked)
            {
                sifretxt.PasswordChar = '\0';
                sifreonay.PasswordChar = '\0';               
            }
            else
            {
                sifretxt.PasswordChar = '*';
                sifreonay.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
