using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace DHTS_ANA_GİRİŞ
{
    public partial class ŞifremiUnuttum : Form
    {
        public ŞifremiUnuttum()
        {
            InitializeComponent();
        }

        private void ŞifremiUnuttum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select * From GirisTbl Where kullanici_adi='" + textBox2.Text.ToString() +
                "'and email='" + textBox1.Text.ToString() + "'", bgln.baglanti()); ;

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Open();
                    }
                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();
                    String tarih = DateTime.Now.ToLongDateString();
                    String mailadresin = ("diyetisyenotomasyon@gmail.com");
                    String sifre = ("imoyprojyxkwbhxt");
                    String smtpsrvr = "smtp.gmail.com";
                    String kime = (oku["email"].ToString());
                    String konu = ("Şifre Hatırlatma Maili");
                    String yaz = ("Sayın," + oku["kullanici_adi"].ToString() + "\n" + "Bizden" + tarih + "Tarihinde Şifre Hatırlatma " +
                        "Talebinde Bulundunuz" + "\n" + "Parolanız:" + oku["sifre"].ToString() + "\nİyi Günler");
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smtpsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail);
                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Girmiş Olduğunuz Bilgiler Uyuşuyor, Şifreniz Mail Adresinize Gönderilmiştir");
                    this.Hide();
                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail Gönderme Hatası!", Hata.Message);
                }
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
