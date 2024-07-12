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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void lblOgretmenKayit_Click(object sender, EventArgs e)
        {
              OgretmenKayit ogretmenKayıt = new OgretmenKayit();
              ogretmenKayıt.Show();
              this.Hide();            
        }      
        private void lblSinavOlustur_Click_1(object sender, EventArgs e)
        {
            SinavOlustur sinavOlustur = new SinavOlustur();
            sinavOlustur.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
