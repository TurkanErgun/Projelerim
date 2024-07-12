using OkulSinavSistemi;
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

namespace OkulSinavSistemi
{
    public partial class OgretmenKayit : Form
    {
        public OgretmenKayit()
        {
            InitializeComponent();

        }
        public void kayitları_getir()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string getir = "Select akademisyenID, adSoyad, email, sifre, ders from Akademisyen"; // Sadece gerekli sütunları seç

                SqlCommand komut = new SqlCommand(getir, connection);

                SqlDataAdapter icerik = new SqlDataAdapter(komut);

                DataTable dt = new DataTable();
                icerik.Fill(dt);    //fill komutunu sorgu sonucunda gelen satırları datatable nesnesinin içerisini doldur
                dataGridView1.DataSource = dt;  //dt nin içerisinden gelen sonucları dataGridView in içerisie ekler

                // AkademisyenID sütununu gizle
                dataGridView1.Columns["akademisyenID"].Visible = false;
            }
        }

        public void veriSil(int id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {

                // İlk olarak Kayit tablosunda bu akademisyene referans veren kayıtları sil
                string deleteKayitQuery = "DELETE FROM Kayit WHERE akademisyen1ID = @id OR akademisyen2ID = @id OR akademisyen3ID = @id";
                SqlCommand deleteKayitCommand = new SqlCommand(deleteKayitQuery, connection);
                deleteKayitCommand.Parameters.AddWithValue("@id", id);
                deleteKayitCommand.ExecuteNonQuery();

                // Daha sonra Akademisyen kaydını sil
                string sil = "DELETE FROM Akademisyen WHERE akademisyenID = @id";
                SqlCommand komut = new SqlCommand(sil, connection);
                komut.Parameters.AddWithValue("@id", id);
                komut.ExecuteNonQuery();

            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSifre.Text) ||
                string.IsNullOrWhiteSpace(comBoxDers.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    // Aynı ders adına sahip akademisyen var mı kontrol et
                    string kontrolSorgu = "SELECT COUNT(*) FROM Akademisyen WHERE adSoyad = @adSoyad AND ders = @ders";
                    SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, connection);
                    kontrolKomut.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
                    kontrolKomut.Parameters.AddWithValue("@ders", comBoxDers.Text);

                    int akademisyenSayisi = (int)kontrolKomut.ExecuteScalar();

                    if (akademisyenSayisi > 0)
                    {
                        MessageBox.Show("Bu ders adıyla bir akademisyen zaten mevcut.");
                        return;
                    }

                    string kayit = "insert into Akademisyen (adSoyad, email, sifre, ders) values(@adSoyad, @email, @sifre, @ders)";

                    SqlCommand komut = new SqlCommand(kayit, connection);
                    komut.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@email", txtEmail.Text);
                    komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                    komut.Parameters.AddWithValue("@ders", comBoxDers.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ekleme işlemi başarılı");

                    // DataGridView'ı güncelle
                    kayitları_getir();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu!!" + hata.Message);
                }
                finally
                {
                    DatabaseConnection.CloseConnection(connection);
                }
            }
        }



        private void btnListele_Click(object sender, EventArgs e)
        {
            kayitları_getir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {

                foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
                {
                    int id = Convert.ToInt32(drow.Cells[0].Value);

                    // Seçilen id'ye göre veri silme
                    veriSil(id);
                }
                
                // TextBox'lardaki verileri temizle
                txtAdSoyad.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtSifre.Text = string.Empty;
                comBoxDers.SelectedIndex = -1; // combobox'ı da temizlemek için

                // DataGridView'ı güncelle
                kayitları_getir();
            }

            MessageBox.Show("Kayıt başarıyla silindi.");
        }

        int i = 0;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string guncelle = ("update Akademisyen set adSoyad = @adSoyad, " +
                    "email = @email, sifre = @sifre, ders = @ders where akademisyenID = @id");

                SqlCommand komut = new SqlCommand(guncelle, connection);

                komut.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                komut.Parameters.AddWithValue("@ders", comBoxDers.Text);
                komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);

                komut.ExecuteNonQuery();

                MessageBox.Show("Güncelleme işlemi başarılı");

                // güncellendikten sonra TextBox'ları temizle
                txtAdSoyad.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtSifre.Text = string.Empty;
                comBoxDers.SelectedIndex = -1;

            }
            kayitları_getir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            txtAdSoyad.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            comBoxDers.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        //comBoxın içine yazı yazılmasın diye
        private void comBoxDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBoxDers.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void OgretmenKayit_Load(object sender, EventArgs e)//veriler sqlden gelsin diye
        {

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    DataTable tablo = new DataTable();
                    string dersSorgu = "SELECT * FROM Ders";
                    SqlCommand komut = new SqlCommand(dersSorgu, connection);
                    SqlDataAdapter da = new SqlDataAdapter(komut); // SqlDataAdapter oluşturulurken SelectCommand.Connection ayarlanır
                    da.Fill(tablo);
                    comBoxDers.ValueMember = "dersID";
                    comBoxDers.DisplayMember = "ad";
                    comBoxDers.DataSource = tablo;
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu: " + hata.Message);
                }
                finally
                {
                    DatabaseConnection.CloseConnection(connection);
                }
            }


        }


        private void lblSinavOlustur_Click_1(object sender, EventArgs e)
        {
            SinavOlustur sinavOlustur = new SinavOlustur();
            sinavOlustur.Show();
            this.Hide();
        }

        private void lblDersKayit_Click(object sender, EventArgs e)
        {
            DersKayit dersKayit = new DersKayit();
            dersKayit.Show();
            this.Hide();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }


    }
}
