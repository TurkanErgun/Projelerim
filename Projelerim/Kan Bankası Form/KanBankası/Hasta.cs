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
namespace KanBankası
{
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void Reset()
        {
            HAdSoyadTb.Text = "";
            HTCTb.Text = "";
            HYasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesics donorListesics = new DonorListesics();
            donorListesics.Show();
        }

        //private void label4_Click(object sender, EventArgs e)
        //{
        //    Hasta hasta = new Hasta();
        //    hasta.Show();
        //}

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListe hastaListe = new HastaListe();
            hastaListe.Show();
            this.Hide();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu kanStogu = new KanStogu();
            kanStogu.Show();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferics kanTransferics = new KanTransferics();
            kanTransferics.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli kontrolPaneli = new KontrolPaneli();
            kontrolPaneli.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdSoyadTb.Text == "" || HTCTb.Text == "" || HYasTb.Text == "" || HCinsCb.SelectedIndex == -1 || HTelefonTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "" +"Insert into HastaTbl values('" + HAdSoyadTb.Text + "','" + HTCTb.Text + "'," + HYasTb.Text + ",'" + HTelefonTb.Text + "','" + HCinsCb.SelectedItem.ToString() + "','" + HKGrupCb.SelectedItem.ToString() + "','" + HAdresTb.Text + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }

            }
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            KanBagısı dn = new KanBagısı();
            dn.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            DonorListesics dn = new DonorListesics();
            dn.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta dn = new Hasta();
            dn.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            HastaListe dn = new HastaListe();
            dn.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            KanStogu dn = new KanStogu();
            dn.Show();


        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            KanTransferics dn = new KanTransferics();
            dn.Show();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
            dn.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void DTCTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Hasta_Load(object sender, EventArgs e)
        {

        }
    }
}


