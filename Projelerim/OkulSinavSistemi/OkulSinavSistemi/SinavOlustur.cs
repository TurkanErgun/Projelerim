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
    public partial class SinavOlustur : Form
    {
       
        public SinavOlustur()
        {
            InitializeComponent();
        }

        public void kayitları_getir()
        {
            // Merkezi bağlantı sınıfını kullanarak bağlantıyı al
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string getir = @"
            SELECT 
                k.kayitID,
                pt.ad AS Program,
                os.ad AS OgrSinif,
                d.ad AS Ders,
                k.tarih,
                k.saat,
                s.ad AS Sinif,
                a1.adSoyad AS Akademisyen1,
                a2.adSoyad AS Akademisyen2,
                a3.adSoyad AS Akademisyen3,
                st.ad AS SinavTur
            FROM 
                Kayit k
            JOIN 
                ProgramTur pt ON k.programTurID = pt.programTurID
            JOIN 
                OgrenciSinif os ON k.ogrSinifID = os.ogrSinifID
            JOIN 
                Ders d ON k.dersID = d.dersID
            JOIN 
                Sinif s ON k.sinifID = s.sinifID
            JOIN 
                Akademisyen a1 ON k.akademisyen1ID = a1.akademisyenID
            JOIN 
                Akademisyen a2 ON k.akademisyen2ID = a2.akademisyenID
            JOIN 
                Akademisyen a3 ON k.akademisyen3ID = a3.akademisyenID
            JOIN 
                SinavTur st ON k.sinavTurID = st.sinavTurID";

                SqlCommand komut = new SqlCommand(getir, connection);

                SqlDataAdapter icerik = new SqlDataAdapter(komut);

                DataTable dt = new DataTable();
                icerik.Fill(dt);    //fill komutunu sorgu sonucunda gelen satırları datatable nesnesinin içerisini doldur
                dataGridView1.DataSource = dt;  //dt nin içerisinden gelen sonucları dataGridView in içerisie ekler

                // ID sütununu gizle
                dataGridView1.Columns["kayitID"].Visible = false;
            }
        }
        public void veriSil(int id)
        {
            // Merkezi bağlantı sınıfını kullanarak bağlantıyı al
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string sil = "delete from Kayit where kayitID = @id";

                SqlCommand komut = new SqlCommand(sil, connection);

                komut.Parameters.AddWithValue("@id", id);

                komut.ExecuteNonQuery();
            }
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            kayitları_getir();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                veriSil(id);
                kayitları_getir();
            }
        }


        private void lblOgretmenKayit_Click(object sender, EventArgs e)
        {
            OgretmenKayit ogretmenKayıt = new OgretmenKayit();
            ogretmenKayıt.Show();
            this.Hide();
        }

        private void SinavOlustur_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {

                DataTable tbl = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From ProgramTur", connection);
                da.Fill(tbl);
                comBoxProgram.ValueMember = "programTurID";
                comBoxProgram.DisplayMember = "ad";
                comBoxProgram.DataSource = tbl;

                DataTable tbl1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter("Select * From OgrenciSinif", connection);
                da1.Fill(tbl1);
                comBoxSinif.ValueMember = "ogrSinifID";
                comBoxSinif.DisplayMember = "ad";
                comBoxSinif.DataSource = tbl1;

                DataTable tbl2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("SELECT dersID, ad + ' (' + CAST(ogrenciSayisi AS NVARCHAR) + ')' AS DersAdi FROM Ders", connection);
                da2.Fill(tbl2);
                comboBoxDers.ValueMember = "dersID";
                comboBoxDers.DisplayMember = "DersAdi";
                comboBoxDers.DataSource = tbl2;

                DataTable tbl3 = new DataTable();
                SqlDataAdapter da3 = new SqlDataAdapter("SELECT sinifID, ad + ' (' + CAST(kapasite AS NVARCHAR) + ')' AS ad FROM Sinif", connection);
                da3.Fill(tbl3);
                comboBoxDerslik.ValueMember = "sinifID";
                comboBoxDerslik.DisplayMember = "ad";
                comboBoxDerslik.DataSource = tbl3;

                DataTable tbl4 = new DataTable();
                SqlDataAdapter da4 = new SqlDataAdapter("Select * From Akademisyen", connection);
                da4.Fill(tbl4);
                comboxAkademisyen.DataSource = tbl4.Copy();
                comboxAkademisyen.ValueMember = "akademisyenID";
                comboxAkademisyen.DisplayMember = "adSoyad";

                comboxAkademisyen1.DataSource = tbl4.Copy();
                comboxAkademisyen1.ValueMember = "akademisyenID";
                comboxAkademisyen1.DisplayMember = "adSoyad";

                comboxAkademisyen2.DataSource = tbl4.Copy();
                comboxAkademisyen2.ValueMember = "akademisyenID";
                comboxAkademisyen2.DisplayMember = "adSoyad";

                DataTable tbl7 = new DataTable();
                SqlDataAdapter da7 = new SqlDataAdapter("Select * From SinavTur", connection);
                da7.Fill(tbl7);
                comboxSinavTur.ValueMember = "sinavTurID";
                comboxSinavTur.DisplayMember = "ad";
                comboxSinavTur.DataSource = tbl7;
            }
        }

        private void lblOgretmenKayit_Click_1(object sender, EventArgs e)
        {
            OgretmenKayit ogretmenKayıt = new OgretmenKayit();
            ogretmenKayıt.Show();
            this.Hide();
        }
        bool durum;
        void mukerrer()//tekrar eden 
        {

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                SqlCommand komut = new SqlCommand("Select * from Kayit where saat=@saat and tarih=@tarih", connection);
                komut.Parameters.AddWithValue("@saat", maskedTextBox1.Text);
                DateTime tarih = dateTimePicker1.Value.Date;
                komut.Parameters.Add("@tarih", SqlDbType.Date).Value = tarih;
                using (SqlDataReader dr = komut.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        durum = false;
                    }
                    else
                    {
                        durum = true;
                    }
                }
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Giriş kontrollerini kontrol et
            if (comBoxProgram.SelectedIndex == -1 || string.IsNullOrWhiteSpace(comboBoxDers.Text) || string.IsNullOrWhiteSpace(comboBoxDerslik.Text) ||
                string.IsNullOrWhiteSpace(comBoxSinif.Text) || string.IsNullOrWhiteSpace(comboxSinavTur.Text) ||
                comboxAkademisyen.SelectedIndex == -1 || comboxAkademisyen1.SelectedIndex == -1 || comboxAkademisyen2.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            // Seçilen program adını al
            int secilenProgramID = (int)comBoxProgram.SelectedValue;
            int secilenDersID = (int)comboBoxDers.SelectedValue;
            string secilenDerslikAdi = comboBoxDerslik.Text;



            int sinifID = (int)comBoxSinif.SelectedValue;

            string secilenOgrSinif = comBoxSinif.Text;
            string secilenSinavTur = comboxSinavTur.Text;

            int secilenAkademisyen1 = (int)comboxAkademisyen.SelectedValue;
            int secilenAkademisyen2 = (int)comboxAkademisyen1.SelectedValue;
            int secilenAkademisyen3 = (int)comboxAkademisyen2.SelectedValue;

            // Check if the selected akademisyenler are unique
            if (secilenAkademisyen1 == secilenAkademisyen2 || secilenAkademisyen1 == secilenAkademisyen3 || secilenAkademisyen2 == secilenAkademisyen3)
            {
                MessageBox.Show("Lütfen farklı üç akademisyen seçin.");
                return;
            }

            mukerrer(); // Tekrar eden kaydı kontrol et
            if (!durum)
            {
                MessageBox.Show("Bu saat ve tarihte zaten kayıt var");
                return;
            }

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                // ProgramTurID'yi bul
                string sorguProgram = "SELECT programTurID FROM ProgramTur WHERE programTurID  = @programTurID";
                SqlCommand komutProgram = new SqlCommand(sorguProgram, connection);
                komutProgram.Parameters.AddWithValue("@programTurID", secilenProgramID);
                int programTurID = (int)komutProgram.ExecuteScalar();

                // DersID'yi bul
                string sorguDers = "SELECT ad FROM Ders WHERE dersID = @dersID";
                SqlCommand komutDers = new SqlCommand(sorguDers, connection);
                komutDers.Parameters.AddWithValue("@dersID", secilenDersID); // secilenDersID, dersID'nin değerini temsil eder
                string dersAdi = komutDers.ExecuteScalar() as string;
                if (dersAdi != null)
                {
                    // Ders adını başarıyla aldık, burada işlem yapabilirsiniz
                }
                else
                {
                    // Ders adı alınamadı, bir hata mesajı gösterebilir veya uygun bir varsayılan değer kullanabilirsiniz
                }

                // SinifID'yi bul
                string sorguSinif = "SELECT sinifID FROM Sinif WHERE ad = @ad";
                SqlCommand komutSinif = new SqlCommand(sorguSinif, connection);
                komutSinif.Parameters.AddWithValue("@ad", secilenDerslikAdi);
                object result = komutSinif.ExecuteScalar();
                if (result != null)
                {
                    sinifID = Convert.ToInt32(result);
                }
                else
                {
                    // Kayıt bulunamadığı veya hata olduğu durumu işleyin
                }

                // OgrSinifID'yi bul
                string sorguOgrSinif = "SELECT ogrSinifID FROM OgrenciSinif WHERE ad = @ad";
                SqlCommand komutOgrSinif = new SqlCommand(sorguOgrSinif, connection);
                komutOgrSinif.Parameters.AddWithValue("@ad", secilenOgrSinif);
                int ogrSinifID = (int)komutOgrSinif.ExecuteScalar();

                // SinavTurID'yi bul
                string sorguSinavTur = "SELECT sinavTurID FROM SinavTur WHERE ad = @ad";
                SqlCommand komutSinavTur = new SqlCommand(sorguSinavTur, connection);
                komutSinavTur.Parameters.AddWithValue("@ad", secilenSinavTur);
                int sinavTurID = (int)komutSinavTur.ExecuteScalar();

                // tarih ve saat bilgisini al
                DateTime tarih = dateTimePicker1.Value;
                string saat = maskedTextBox1.Text; // maskedTextBox1'ın maskesi 00:00 olmalı

                // Kayıt ekleme sorgusunu oluştur
                string ekleQuery = "INSERT INTO Kayit (programTurID, ogrSinifID, dersID, sinifID, tarih, saat, akademisyen1ID, akademisyen2ID, akademisyen3ID, sinavTurID) " +
                                   "VALUES (@programTurID, @ogrSinifID, @dersID, @sinifID, @tarih, @saat, @akademisyen1ID, @akademisyen2ID, @akademisyen3ID, @sinavTurID)";
                SqlCommand komutKayitEkle = new SqlCommand(ekleQuery, connection);
                komutKayitEkle.Parameters.AddWithValue("@programTurID", programTurID);
                komutKayitEkle.Parameters.AddWithValue("@ogrSinifID", ogrSinifID);
                komutKayitEkle.Parameters.AddWithValue("@dersID", secilenDersID);
                komutKayitEkle.Parameters.AddWithValue("@sinifID", sinifID);
                komutKayitEkle.Parameters.AddWithValue("@akademisyen1ID", secilenAkademisyen1);
                komutKayitEkle.Parameters.AddWithValue("@akademisyen2ID", secilenAkademisyen2);
                komutKayitEkle.Parameters.AddWithValue("@akademisyen3ID", secilenAkademisyen3);
                komutKayitEkle.Parameters.AddWithValue("@sinavTurID", sinavTurID);
                komutKayitEkle.Parameters.AddWithValue("@tarih", tarih);
                komutKayitEkle.Parameters.AddWithValue("@saat", saat);

                // Komutu çalıştır
                komutKayitEkle.ExecuteNonQuery();
            }
            MessageBox.Show("Kayıt başarıyla eklendi.");

            // DataGridView'ı güncelle
            kayitları_getir();

            // Kayıt eklendikten sonra giriş kontrollerini temizle
            comBoxProgram.SelectedIndex = -1;
            comboBoxDers.SelectedIndex = -1;
            comboBoxDerslik.SelectedIndex = -1;
            comBoxSinif.SelectedIndex = -1;
            comboxSinavTur.SelectedIndex = -1;
            comboxAkademisyen.SelectedIndex = -1;
            comboxAkademisyen1.SelectedIndex = -1;
            comboxAkademisyen2.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now.Date;
            maskedTextBox1.Clear();
        }


        private void lblDersKayit_Click(object sender, EventArgs e)
        {
            DersKayit dersKayit = new DersKayit();
            dersKayit.Show();
            this.Hide();
        }

        int i = 0;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string guncelle = ("UPDATE Kayit SET programTurID= @programTurID, ogrSinifID= @ogrSinifID, dersID = @dersID, tarih = @tarih, saat = @saat," +
                    " sinifID = @sinifID, akademisyen1ID = @akademisyen1ID, akademisyen2ID = @akademisyen2ID, akademisyen3ID = @akademisyen3ID, sinavTurID = @sinavTurID WHERE KayitID = @kayitID");

                SqlCommand komut = new SqlCommand(guncelle, connection);

                // ProgramTurID'yi bul
                string sorguPro = "SELECT programTurID FROM ProgramTur WHERE ad = @programTurID";
                SqlCommand komutPro = new SqlCommand(sorguPro, connection);
                komutPro.Parameters.AddWithValue("@programTurID", comBoxProgram.Text);
                string prog = komutPro.ExecuteScalar() as string;
                if (prog != null)
                {
                    // Ders adını başarıyla aldık, burada işlem yapabilirsiniz
                }
                else
                {
                    // Ders adı alınamadı, bir hata mesajı gösterebilir veya uygun bir varsayılan değer kullanabilirsiniz
                }

                // DersID'yi bul
                string sorguDers = "SELECT dersID FROM Ders WHERE ad = @dersAd";
                SqlCommand komutDers = new SqlCommand(sorguDers, connection);
                komutDers.Parameters.AddWithValue("@dersAd", comboBoxDers.Text);
                string dersAdi = komutDers.ExecuteScalar() as string;
                if (dersAdi != null)
                {
                    // Ders adını başarıyla aldık, burada işlem yapabilirsiniz
                }
                else
                {
                    // Ders adı alınamadı, bir hata mesajı gösterebilir veya uygun bir varsayılan değer kullanabilirsiniz
                }

                // SinifID'yi bul
                string sorguSinif = "SELECT sinifID FROM Sinif WHERE ad = @ad";
                SqlCommand komutSinif = new SqlCommand(sorguSinif, connection);
                komutSinif.Parameters.AddWithValue("@ad", comBoxSinif.Text);
                string sinif = komutSinif.ExecuteScalar() as string;
                if (sinif != null)
                {
                    // Ders adını başarıyla aldık, burada işlem yapabilirsiniz
                }
                else
                {
                    // Ders adı alınamadı, bir hata mesajı gösterebilir veya uygun bir varsayılan değer kullanabilirsiniz
                }

                // OgrSinifID'yi bul
                string sorguOgrSinif = "SELECT ogrSinifID FROM OgrenciSinif WHERE ad = @ad";
                SqlCommand komutOgrSinif = new SqlCommand(sorguOgrSinif, connection);
                komutOgrSinif.Parameters.AddWithValue("@ad", comBoxSinif.Text);
                int ogrSinifID = (int)komutOgrSinif.ExecuteScalar();

                // SinavTurID'yi bul
                string sorguSinavTur = "SELECT sinavTurID FROM SinavTur WHERE ad = @ad";
                SqlCommand komutSinavTur = new SqlCommand(sorguSinavTur, connection);
                komutSinavTur.Parameters.AddWithValue("@ad", comboxSinavTur.Text);
                int sinavTurID = (int)komutSinavTur.ExecuteScalar();

                // AkademisyenID'leri bul
                int secilenAkademisyen1 = (int)comboxAkademisyen.SelectedValue;
                int secilenAkademisyen2 = (int)comboxAkademisyen1.SelectedValue;
                int secilenAkademisyen3 = (int)comboxAkademisyen2.SelectedValue;

                // Parametreleri ayarla
                komut.Parameters.AddWithValue("@programTurID", Convert.ToInt32(comBoxProgram.SelectedValue));
                komut.Parameters.AddWithValue("@ogrSinifID", ogrSinifID);
                komut.Parameters.AddWithValue("@dersID", Convert.ToInt32(comboBoxDers.SelectedValue));
                komut.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@saat", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@sinifID", Convert.ToInt32(comBoxSinif.SelectedValue));
                komut.Parameters.AddWithValue("@akademisyen1ID", secilenAkademisyen1);
                komut.Parameters.AddWithValue("@akademisyen2ID", secilenAkademisyen2);
                komut.Parameters.AddWithValue("@akademisyen3ID", secilenAkademisyen3);
                komut.Parameters.AddWithValue("@sinavTurID", sinavTurID);
                komut.Parameters.AddWithValue("@kayitID", dataGridView1.Rows[i].Cells[0].Value);

                // Komutu çalıştır
                komut.ExecuteNonQuery();

                MessageBox.Show("Güncelleme işlemi başarılı");

                // Güncellemeden sonra TextBox'ları temizle
                comBoxProgram.SelectedIndex = -1;
                comBoxSinif.SelectedIndex = -1;
                comboBoxDers.SelectedIndex = -1;
                comboBoxDerslik.SelectedIndex = -1;
                comboxAkademisyen.SelectedIndex = -1;
                comboxAkademisyen1.SelectedIndex = -1;
                comboxAkademisyen2.SelectedIndex = -1;
                comboxSinavTur.SelectedIndex = -1;

                // DateTimePicker'ı temizle
                dateTimePicker1.Value = DateTime.Now.Date;
                maskedTextBox1.Clear();
            }
            kayitları_getir();
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            comBoxProgram.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comBoxSinif.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBoxDers.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            comboBoxDerslik.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            comboxAkademisyen.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            comboxAkademisyen1.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            comboxAkademisyen2.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            comboxSinavTur.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        //comBoxların içine yazı yazılmadın diye
        private void comBoxProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBoxProgram.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comBoxSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            comBoxSinif.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxDers_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDers.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboBoxDerslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxDerslik.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboxAkademisyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxAkademisyen.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboxAkademisyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxAkademisyen1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboxAkademisyen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxAkademisyen2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void comboxSinavTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboxSinavTur.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
