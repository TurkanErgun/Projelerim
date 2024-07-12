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
    public partial class KontrolPaneli : Form
    {
        public KontrolPaneli()
        {
            InitializeComponent();
            VeriCek();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void VeriCek()
        {
            baglanti.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl",baglanti);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", baglanti);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from CalisanTbl", baglanti);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            KullanıcıLbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from KanTbl", baglanti);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int Kstok = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalLbl.Text = "" + Kstok;
            SqlDataAdapter sda4 = new SqlDataAdapter("Select KStok from KanTbl where KGrup='"+"0+"+"'", baglanti);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            OpLbl.Text = dt4.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / Kstok) * 100;
            OplusBar.Value=Convert.ToInt32(OplusPercentage);
            SqlDataAdapter sda5 = new SqlDataAdapter("Select KStok from KanTbl where KGrup='" + "AB+" + "'", baglanti);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            ABplusLbl.Text = dt5.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / Kstok) * 100;
            ABplusBar.Value = Convert.ToInt32(ABplusPercentage);
            SqlDataAdapter sda6 = new SqlDataAdapter("Select KStok from KanTbl where KGrup='" + "0-" + "'", baglanti);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            OnegativeLbl.Text = dt6.Rows[0][0].ToString();
            double OminutesPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / Kstok) * 100;
            OminBar.Value = Convert.ToInt32(OminutesPercentage);
            SqlDataAdapter sda7 = new SqlDataAdapter("Select KStok from KanTbl where KGrup='" + "AB-" + "'", baglanti);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            ABnegativeLbl.Text = dt7.Rows[0][0].ToString();
            double ABminutesPercentage = (Convert.ToDouble(dt7.Rows[0][0].ToString()) / Kstok) * 100;
            ABminBar.Value = Convert.ToInt32(ABminutesPercentage);
            baglanti.Close();
        }
        private void KontrolPaneli_Load(object sender, EventArgs e)
        {

        }

        private void TotalLbl_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            KontrolPaneli dn = new KontrolPaneli();
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void OplusBar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
