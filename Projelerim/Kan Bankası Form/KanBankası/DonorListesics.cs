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
using System.Windows.Input;

namespace KanBankası
{
    public partial class DonorListesics : Form
    {
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
        public DonorListesics()
        {
            InitializeComponent();
            uyeler();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from DonorTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void DonorListesics_Load(object sender, EventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {
            DonorListesics dn = new DonorListesics();
            dn.Show();
        }

        private void label4_Click_1(object sender, EventArgs e)
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }
        int key = 0;
        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DAdSoyadTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            DTCTb.Text = DonorDGV.SelectedRows[0].Cells[2].Value.ToString();
            DYasTb.Text = DonorDGV.SelectedRows[0].Cells[3].Value.ToString();
            DTelefonTb.Text = DonorDGV.SelectedRows[0].Cells[4].Value.ToString();
            DCinsCb.Text = DonorDGV.SelectedRows[0].Cells[5].Value.ToString();
            DKGrupCb.Text = DonorDGV.SelectedRows[0].Cells[6].Value.ToString();
            DAdresTb.Text = DonorDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (DAdSoyadTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(DonorDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            DAdSoyadTb.Text = "";
            DTCTb.Text = "";
            DYasTb.Text = "";
            DTelefonTb.Text = "";
            DCinsCb.SelectedIndex = -1;
            DKGrupCb.SelectedIndex = -1;
            DAdresTb.Text = "";
           
            key = 0;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            
        }
    }
    
}
