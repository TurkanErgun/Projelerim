using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KanBankası
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Login log =new Login();
            log.Show();
            this.Hide();
        }

        private void girisbtn_Click(object sender, EventArgs e)
        {
            if(AdminSifreTb.Text=="")
            {
                MessageBox.Show("Admin Şifrenizi Giriniz");
            }
            else if(AdminSifreTb.Text=="1234")
            {
                Calisan cal = new Calisan();
                cal.Show(); 
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Şifre");
                AdminSifreTb.Text = "";
            }
        }
    }
}
