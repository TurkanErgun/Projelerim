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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesics dn= new DonorListesics();
            dn.Show();
          
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta dn = new Hasta();
            dn.Show();
          
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListe dn = new HastaListe();
            dn.Show();
           
        }
        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu dn = new KanStogu();
            dn.Show();
           
        }
        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferics dn = new KanTransferics();
            dn.Show();
           
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
            dn.Show();
           
        }

        private void label10_Click(object sender, EventArgs e)
        {
            KanBagısı dn = new KanBagısı();
            dn.Show();
            
        }
    }
}
