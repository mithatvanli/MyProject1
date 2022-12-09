using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace MyProject
{
    public partial class FormSifre : Form
    {
        public FormSifre()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);


        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void BtnKpt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKclt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Geri1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisEkranı girisEkranı1 = new GirisEkranı();
            girisEkranı1.ShowDialog();
            this.Close();
        }

        private void BtnKpt_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKpt.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKpt_MouseLeave(object sender, EventArgs e)
        {
            BtnKpt.BackColor = Color.FromArgb(0x525252) ;
        }

        private void Geri1_MouseMove(object sender, MouseEventArgs e)
        {
            Geri1.BackColor = Color.FromArgb(0x7F7F7F);
        }

        private void Geri1_MouseLeave(object sender, EventArgs e)
        {
            Geri1.BackColor = Color.FromArgb(0x000000);
        }

        private void TxtParola1_Enter(object sender, EventArgs e)
        {
            TxtParola1.UseSystemPasswordChar = true;    
        }

        private void TxtParola1_Leave(object sender, EventArgs e)
        {
            TxtParola1.UseSystemPasswordChar = true;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            TxtParola2.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            TxtParola2.UseSystemPasswordChar = true;
        }

       

        private void TxtParola2_Enter(object sender, EventArgs e)
        {
            if (TxtParola2.Text=="")
            {
                TxtParola2.UseSystemPasswordChar = true;
            }
           
        }

        private void BtnDgstr_Click(object sender, EventArgs e)
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

                if (TxtKullaniciAdi1.Text == "" || TxtParola1.Text == ""||TxtParola2.Text=="")
                {
                    MessageBox.Show("Bütün Alanlar Doldurulmalıdır");
                }
                else if (TxtParola1.Text==TxtParola2.Text)
                {
                    MessageBox.Show("Lütfen Paroları Farklı Giriniz!");
                }
                else if (TxtParola2.Text.Length<10)
                {
                    MessageBox.Show("Lütfen Yeni Şifrenizi En Az 10 Haneli Yapınız");
                }
                else
                {
                    string sorgu = " SELECT[Kullanici_Adi],[Sifre] FROM[dbo].[Kullanicilar] where  (Kullanici_Adi ='" + TxtKullaniciAdi1.Text + "' AND  Sifre = '" + TxtParola1.Text + "')";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable myDataTable = new DataTable();
                    using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                    {
                        adapter.SelectCommand = new SqlCommand(sorgu, conn);
                        adapter.Fill(myDataTable);
                    }


                    if ( myDataTable.Rows.Count  > 0)
                    {
                                                                            
                            string sor = " UPDATE [dbo].[Kullanicilar] ";
                            sor += "SET [Sifre]='" + TxtParola2.Text+ "'";
                            sor += " WHERE Kullanici_Adi = '" + TxtKullaniciAdi1.Text + "'";
                            SqlCommand Emir = new SqlCommand();
                            Emir.Connection = Adres;
                            Emir.CommandType = CommandType.Text;
                            Emir.CommandText = sor;
                            try
                            {
                                Adres.Open();
                                Emir.ExecuteNonQuery();
                                Adres.Close();
                                MessageBox.Show("Şifre Değiştirme İşlemi Başarılı Bir Şekilde Gerçekleşti.");
                                TxtKullaniciAdi1.Text = "";
                                TxtParola1.Text = "";
                                TxtParola2.Text="";                           
                            }
                            catch (Exception Hata)
                            {

                                MessageBox.Show("Hata Oluştu : " + Hata.Message.ToString());
                            }
                                                
                                               
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Parolayı Yanlış Girdiniz!");
                                                                    
                        TxtKullaniciAdi1.Focus();

                    }

                }
            }
            catch (Exception Hata)
            {

                MessageBox.Show("Sunucuya Bağlanılamadı" + Hata.Message.ToString());
            }

        }
    }
}
