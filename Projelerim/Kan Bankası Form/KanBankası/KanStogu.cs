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
    public partial class KanStogu : Form
    {
        public KanStogu()
        {
            InitializeComponent();
            KanStok();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");

        private void KanStok()
        {
            baglanti.Open();
            string query = "select *from KanTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KStoguDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void KanStogu_Load(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            KanTransferics kant = new KanTransferics();
            kant.Show();
            this.Hide();
        }

        private void DKGrupCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu dn = new KanStogu();
            dn.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Donor dn = new Donor();
            dn.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            KanBagısı dn = new KanBagısı();
            dn.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            DonorListesics dn = new DonorListesics();
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

        private void label7_Click_1(object sender, EventArgs e)
        {
            KanTransferics dn = new KanTransferics();
            dn.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
            dn.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void KStoguDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
