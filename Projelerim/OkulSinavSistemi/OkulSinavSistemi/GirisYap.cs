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


namespace OkulSinavSistemi
{
    public partial class GirisYap : Form
    {
        
        public GirisYap()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string email = txtEposta.Text;
                string sifre = txtSifre.Text;
                string query = "SELECT COUNT(*) FROM Akademisyen WHERE email = @email AND sifre = @sifre";
                SqlCommand command = new SqlCommand(query, connection);
               // SqlDataAdapter da = new SqlDataAdapter(command); // SqlDataAdapter oluşturulurken SelectCommand.Connection ayarlanır
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@sifre", sifre);

                try
                {
                   // connectionOpen();
                    int result = (int)command.ExecuteScalar();

                    if (result > 0)
                    {
                        MessageBox.Show("Giriş başarılı.");
                        AnaSayfa anaSayfa = new AnaSayfa();
                        anaSayfa.Show();
                        this.Hide();
                        // Giriş başarılıysa ana uygulama formunu açabilirsiniz
                        // Ana formunuzu burada açabilirsiniz: new AnaForm().Show();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
        private void GirisYap_Load(object sender, EventArgs e)
        {

        }
    }
}
