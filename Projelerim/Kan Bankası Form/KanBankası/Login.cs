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

namespace KanBankası
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin adm = new AdminLogin();
            adm.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from CalisanTbl where CalId='"+KullaniciTb.Text+"' and CalSif='" +SifreTb.Text+"'",baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString()=="1")
            {
                AnaSayfa ana = new AnaSayfa();
                ana.Show();
                this.Hide();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Ya da Şifre");
            }
            baglanti.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SifreTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
