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
    public partial class Donor : Form
    {
        //private void label2_Click(object sender, EventArgs e)
        //{
        //    Donor donor = new Donor();
        //    donor.Show();
        //}

        private void label3_Click(object sender, EventArgs e)
        {
            DonorListesics donorListesics = new DonorListesics();
            donorListesics.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta hasta = new Hasta();
            hasta.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListe hastaListe = new HastaListe();
            hastaListe.Show();
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
        public Donor()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DTCTb.Text = "";
            DYasTb.Text = "";
            DCinsCb.SelectedIndex = -1;
            DTelefonTb.Text = "";
            DAdresTb.Text = "";
            DKGrupCb.SelectedIndex = -1;
        }

       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(DAdSoyadTb.Text=="" || DTCTb.Text == "" ||DYasTb.Text==""||DCinsCb.SelectedIndex==-1||DTelefonTb.Text==""||DKGrupCb.SelectedIndex==-1||DAdresTb.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "" +"Insert into DonorTbl values('" + DAdSoyadTb.Text + "','" + DTCTb.Text + "'," + DYasTb.Text + ",'" + DTelefonTb.Text + "','" + DCinsCb.SelectedItem.ToString() + "','" + DKGrupCb.SelectedItem.ToString() + "','" + DAdresTb.Text  + "')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Donor Başarıyla Kaydedildi");
                    baglanti.Close();
                    Reset();


                }catch(Exception Ex) 
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            KanBagısı dn = new KanBagısı();
            dn.Show();
            this.Hide();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            DonorListesics dn = new DonorListesics();
            dn.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Hasta dn = new Hasta();
            dn.Show();
            this.Hide();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            HastaListe dn = new HastaListe();
            dn.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            KanStogu dn = new KanStogu();
            dn.Show();
            this.Hide();
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            KanTransferics dn = new KanTransferics();
            dn.Show();
            this.Hide();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
            dn.Show();
            this.Hide();
        }

        private void DTelefonTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Donor_Load(object sender, EventArgs e)
        {

        }
    }
}
