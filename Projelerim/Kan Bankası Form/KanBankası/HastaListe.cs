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
    public partial class HastaListe : Form
    {
        public HastaListe()
        {
            InitializeComponent();
            uyeler();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source = TURKAN\SQLEXPRESS; Initial Catalog = C:\USERS\MERVE\ONEDRIVE\BELGELER\KANBANKASIDB.MDF;Integrated Security = True");
        private void uyeler()
        {
            baglanti.Open();
            string query = "select *from HastaTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HastaDGV.DataSource = ds.Tables[0];
            baglanti.Close();

        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void HastaListe_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HAdSoyadTb.Text = HastaDGV.SelectedRows[0].Cells[1].Value.ToString();
            HTCTb.Text = HastaDGV.SelectedRows[0].Cells[2].Value.ToString();
            HyasTb.Text = HastaDGV.SelectedRows[0].Cells[3].Value.ToString();
            HTelefonTb.Text = HastaDGV.SelectedRows[0].Cells[4].Value.ToString();
            HCinsCb.Text = HastaDGV.SelectedRows[0].Cells[5].Value.ToString();
            HKGrupCb.Text = HastaDGV.SelectedRows[0].Cells[6].Value.ToString();
            HAdresTb.Text = HastaDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (HAdSoyadTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reset()
        {
            HAdSoyadTb.Text = "";
            HTCTb.Text = "";
            HyasTb.Text = "";
            HCinsCb.SelectedIndex = -1;
            HTelefonTb.Text = "";
            HAdresTb.Text = "";
            HKGrupCb.SelectedIndex = -1;
            key = 0;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    string query = "delete from HastaTbl where HNum= " + key + ";";
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    baglanti.Close();
                    Reset();
                    uyeler();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HastaListe HL = new HastaListe();
            HL.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Hasta ha = new Hasta();
            ha.Show();
            this.Hide();
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (HAdSoyadTb.Text == "" || HTCTb.Text == "" || HyasTb.Text == "" || HTelefonTb.Text == "" || HKGrupCb.SelectedIndex == -1 || HCinsCb.SelectedIndex == -1 || HAdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    string query = "update HastaTbl set HAdSoyad='" + HAdSoyadTb.Text + "',HTC=" + HTCTb.Text +  "',Hyas=" + HyasTb.Text + ",HTelefon='" + HTelefonTb.Text + "',HCinsiyet='" + HCinsCb.SelectedItem.ToString() + "',HKGrup='" + HKGrupCb.SelectedItem.ToString() + "',HAdres='" + HAdresTb.Text + "'where HNum=" + key + ";";

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Hasta Başarıyla Güncellendi");
                    baglanti.Close();
                    Reset();
                    uyeler();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Ex.Message");
                }
            }
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

        private void label17_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }
    }
}
