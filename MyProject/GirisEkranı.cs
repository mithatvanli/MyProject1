using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class GirisEkranı : Form
    {
        public GirisEkranı()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        private void PnlKapat1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKucult_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnGrs_Click(object sender, EventArgs e)
        {
            string BaglantiAdresi = "";
           
            SqlConnection Adres = new SqlConnection();
    
           
            try
            {
                BaglantiAdresi = "Server = DESKTOP-0PJTRUB;";
                BaglantiAdresi += "Database = Dershane;";
                BaglantiAdresi += "User ID = mithat;";
                BaglantiAdresi += "Password =1234;";
                BaglantiAdresi += "Trusted_Connection = False; Packet Size = 4096;";
                Adres.ConnectionString = BaglantiAdresi;

                if (TxtKullanici.Text == "" || TxtParola.Text == "")
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Boş Bırakılamaz");
                }
                else 
                {
                    string sorgu = " SELECT[Kullanici_Adi],[Sifre] FROM[dbo].[Kullanicilar] where  (Kullanici_Adi ='" + TxtKullanici.Text + "' AND  Sifre = '" + TxtParola.Text + "')";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable myDataTable = new DataTable();
                    using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                    {
                        adapter.SelectCommand = new SqlCommand(sorgu, conn);
                        adapter.Fill(myDataTable);
                    }

                   
                    if (myDataTable.Rows.Count > 0)
                    {
                        this.Hide();
                        AnaSayfa anaSayfa1 = new AnaSayfa();
                        anaSayfa1.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Parolayı Yanlış Girdiniz");
                        TxtKullanici.Text = "Kullanıcı Adı";
                        TxtParola.Text = "Şifre";
                        TxtParola.UseSystemPasswordChar = false;

                        TxtKullanici.Focus();

                    }



                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("Sunucuya Bağlanılamadı" + Hata.Message.ToString());
            }


        }

        private void BtnKapat_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKapat.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKapat_MouseLeave(object sender, EventArgs e)
        {
            BtnKapat.BackColor = Color.FromArgb(0xC1117);
        }

        private void TxtKullanici_Enter(object sender, EventArgs e)
        {
            if (TxtKullanici.Text=="Kullanıcı Adı")
            {
                TxtKullanici.Text = "";

            }
        }

        private void TxtKullanici_Leave(object sender, EventArgs e)
        {
            if (TxtKullanici.Text=="")
            {
                TxtKullanici.Text = "Kullanıcı Adı";
            }
        }

        private void TxtParola_Enter(object sender, EventArgs e)
        {
            if (TxtParola.Text=="Şifre")
            {
                TxtParola.Text = "";
                TxtParola.UseSystemPasswordChar = true;
            }
        }

        private void TxtParola_Leave(object sender, EventArgs e)
        {
            if (TxtParola.Text=="")
            {
                TxtParola.Text = "Şifre";
                TxtParola.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            TxtParola.UseSystemPasswordChar = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TxtParola.UseSystemPasswordChar = true;
        }

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState==FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState=FormWindowState.Normal;    
            }
        }

        private void BtnSifreDegistir_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            FormSifre formSifre2 = new FormSifre();
            formSifre2.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
    }
}
