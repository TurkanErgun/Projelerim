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
    public partial class DersKayit : Form
    {
        // static string constring = ("Data Source=TURKAN;Initial Catalog=SinavSistemiDB;Integrated Security=True");
        // SqlConnection baglanti = new SqlConnection(constring);

        public DersKayit()
        {
            InitializeComponent();
        }
        public void kayitları_getir()
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string getir = "Select dersID, ad, kod, ogrenciSayisi, sinif from Ders"; // dersID sütununu seçme

                SqlCommand komut = new SqlCommand(getir, connection);

                SqlDataAdapter icerik = new SqlDataAdapter(komut);

                DataTable dt = new DataTable();
                icerik.Fill(dt);    //fill komutunu sorgu sonucunda gelen satırları datatable nesnesinin içerisini doldur
                dataGridView1.DataSource = dt;  //dt nin içerisinden gelen sonucları dataGridView in içerisie ekler

                // dersID sütununu gizle
                dataGridView1.Columns["dersID"].Visible = false;

                

            }
        }
        public void veriSil(int dersID)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {

                // İlk olarak Kayit tablosundan ilgili kayıtları sil
                string silKayitlar = "DELETE FROM Kayit WHERE dersID = @dersID";
                SqlCommand komutSilKayitlar = new SqlCommand(silKayitlar, connection);
                komutSilKayitlar.Parameters.AddWithValue("@dersID", dersID);
                komutSilKayitlar.ExecuteNonQuery();

                // Ardından Ders tablosundan ilgili dersi sil
                string silDers = "DELETE FROM Ders WHERE dersID = @dersID";
                SqlCommand komutSilDers = new SqlCommand(silDers, connection);
                komutSilDers.Parameters.AddWithValue("@dersID", dersID);
                komutSilDers.ExecuteNonQuery();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDersAdi.Text) ||
                string.IsNullOrWhiteSpace(txtKod.Text) ||
                string.IsNullOrWhiteSpace(txtOgrSayi.Text) ||
                string.IsNullOrWhiteSpace(txtSinif.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                try
                {
                    // Aynı isimde ders var mı kontrol et
                    string kontrolSorgu = "SELECT COUNT(*) FROM Ders WHERE ad = @ad OR kod = @kod";
                    SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, connection);
                    kontrolKomut.Parameters.AddWithValue("@ad", txtDersAdi.Text);
                    kontrolKomut.Parameters.AddWithValue("@kod", txtKod.Text);

                    int dersSayisi = (int)kontrolKomut.ExecuteScalar();

                    if (dersSayisi > 0)
                    {
                        MessageBox.Show("Bu isimde, kodda veya sınıfta bir ders zaten mevcut.");
                        return;
                    }

                    // Yeni dersi veritabanına ekle
                    string kayit = "INSERT INTO Ders (ad, kod, ogrenciSayisi, sinif) VALUES (@ad, @kod, @ogrenciSayisi, @sinif)";
                    SqlCommand komut = new SqlCommand(kayit, connection);
                    komut.Parameters.AddWithValue("@ad", txtDersAdi.Text);
                    komut.Parameters.AddWithValue("@kod", txtKod.Text);
                    komut.Parameters.AddWithValue("@ogrenciSayisi", txtOgrSayi.Text);
                    komut.Parameters.AddWithValue("@sinif", txtSinif.Text);

                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ekleme işlemi başarılı");
                    ClearControls(); // TextBox'ları temizle

                    // DataGridView'ı güncelle
                    kayitları_getir();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata oluştu: " + hata.Message);
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

                // Ders adını TextBox'dan al
                string dersAdi = txtDersAdi.Text;

                // dersID'yi ders adından bul
                string sorgu = "SELECT dersID FROM Ders WHERE ad = @ad";
                SqlCommand komut = new SqlCommand(sorgu, connection);
                komut.Parameters.AddWithValue("@ad", dersAdi);

                int dersID;
                object result = komut.ExecuteScalar();

                if (result != null)
                {
                    dersID = (int)result;

                    try
                    {
                        // Veri silme metodunu çağır
                        veriSil(dersID);

                        // TextBox'lardaki verileri temizle
                        ClearControls();

                        MessageBox.Show("Kayıt başarıyla silindi.");

                        // DataGridView'ı güncelle
                        kayitları_getir();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ders bulunamadı.");
                }
            }
        }

        private void ClearControls()
        {
            txtDersAdi.Clear();
            txtKod.Clear();
            txtOgrSayi.Clear();
            txtSinif.Clear();
        }


        int i = 0;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string guncelle = ("update Ders set ad = @ad, " +
                "kod= @kod, ogrenciSayisi = @ogrenciSayisi, sinif = @sinif where DersID = @id");

                SqlCommand komut = new SqlCommand(guncelle, connection);

                komut.Parameters.AddWithValue("@ad", txtDersAdi.Text);
                komut.Parameters.AddWithValue("@kod", txtKod.Text);
                komut.Parameters.AddWithValue("@ogrenciSayisi", txtOgrSayi.Text);
                komut.Parameters.AddWithValue("@sinif", txtSinif.Text);
                komut.Parameters.AddWithValue("@id", dataGridView1.Rows[i].Cells[0].Value);

                komut.ExecuteNonQuery();

                MessageBox.Show("Güncelleme işlemi başarılı");

                // güncellendikten sonra TextBox'ları temizle
                txtDersAdi.Text = string.Empty;
                txtKod.Text = string.Empty;
                txtOgrSayi.Text = string.Empty;
                txtSinif.Text = string.Empty;

                // baglanti.Close();
                kayitları_getir();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//veriye çift tıklaınca doldurma işlemi yapıyor güncellemek için
        {
            i = e.RowIndex;
            txtDersAdi.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtKod.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtOgrSayi.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtSinif.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void lblOgretmenKayit_Click(object sender, EventArgs e)
        {
            OgretmenKayit ogretmenKayıt = new OgretmenKayit();
            ogretmenKayıt.Show();
            this.Hide();
        }

        private void lblSinavOlustur_Click(object sender, EventArgs e)
        {
            SinavOlustur sinavOlustur = new SinavOlustur();
            sinavOlustur.Show();
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
