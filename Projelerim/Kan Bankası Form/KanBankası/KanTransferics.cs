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
using System.Windows.Input;

namespace KanBankası
{
    public partial class KanTransferics : Form
    {
        public KanTransferics()
        {
            InitializeComponent();
            fillHastaCb();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void fillHastaCb()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select HNum from HastaTbl", baglanti);
            SqlDataReader rdr;
            rdr=komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("HNum", typeof(int));
            dt.Load(rdr);
            HastaIdCb.ValueMember = "HNum";
            HastaIdCb.DataSource = dt;
            baglanti.Close();
        }
        private void VeriAl()
        {
            baglanti.Open();
            string query = "select * from HastaTbl where HNum=" + HastaIdCb.SelectedValue.ToString() + "";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                HasAdTb.Text = dr["HAdSoyad"].ToString();
                KanGrupTb.Text = dr["HKGrup"].ToString();
            }
            baglanti.Close();
        }
        int stokk = 0;
        private void Stok(String Kgrup)
        {
            baglanti.Open();
            string query = "select * from KanTbl where KGrup='" + Kgrup + "'";
            SqlCommand komut = new SqlCommand(query, baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stokk = Convert.ToInt32(dr["KStok"].ToString());
            }
            baglanti.Close();
        }
        private void KanTransferics_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void HastaIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            VeriAl();
            Stok(KanGrupTb.Text);
            if(stokk>0)
            {
                TransferBtn.Visible = true;
                UygunLbl.Text = "Stok Uygun";
                UygunLbl.Visible = true;
            }else
            {
                UygunLbl.Text = "Stok uygun değil";
                UygunLbl.Visible = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
        }
        private void Reset()
        {
            HasAdTb.Text = "";
            KanGrupTb.Text = "";
            UygunLbl.Visible= false;
            TransferBtn.Visible= false;
        }
        private void kanGüncelle()
        {
            int yenistok = stokk - 1;
            try
            {
                string query = "update KanTbl set KStok=" + yenistok+ " where KGrup='"+KanGrupTb.Text + "';";
                baglanti.Open();
                SqlCommand komut = new SqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                //MessageBox.Show("Hasta Başarıyla Güncellendi");
                baglanti.Close();
                             

            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ex.Message");
            }
        }


        private void TransferBtn_Click(object sender, EventArgs e)
        {
            if (HasAdTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "" + "Insert into TransferTbl values('"+HasAdTb.Text+"', '"+ KanGrupTb.Text+"')";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Transfer Başarılı");
                    baglanti.Close();
                    Stok(KanGrupTb.Text);
                    kanGüncelle();
                    Reset();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            KanStogu ks = new KanStogu();
            ks.Show();
            this.Hide();
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

        private void label14_Click_1(object sender, EventArgs e)
        {
            DonorListesics dn = new DonorListesics();
            dn.Show();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            Hasta dn = new Hasta();
            dn.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListe dn = new HastaListe();
            dn.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }
    }
}
