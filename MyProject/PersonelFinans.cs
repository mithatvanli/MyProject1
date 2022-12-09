using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class PersonelFinans : Form
    {
        public object Ceviri { get; private set; }

        public PersonelFinans()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);


        private void Panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnKclt_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnKpt3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa anaSayfa1 = new AnaSayfa();
            anaSayfa1.ShowDialog();
            this.Close();
        }

      
        private void BtnKpt3_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKpt3.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKpt3_MouseLeave(object sender, EventArgs e)
        {
            BtnKpt3.BackColor = Color.FromArgb(0x0096ff);


        }

        private void PersonelFinans_Load(object sender, EventArgs e)
        {
          
            DataDoldur();
            DataDoldur1();
           
        }

        private void TxtAylikMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtOdenenAvans_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtMaasOdemesi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void TxtKayitId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtFinansalDurum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void DataDoldur1() 
        {
            string Sorgu = "SELECT Id, Tc, Ad, Soyad FROM Personel_Kayit";
            DataTable PersonelTablosu = GenelYardim.DataDoldur(Sorgu);
            dataGridView1.DataSource = PersonelTablosu;

        }

        public void DataDoldur()
        {
            string Sorgu = "SELECT  Personel_Id, Id, Aylik_Maas, Maas_Odemesi,Mass_Odemesi_Yapilan_Tarih FROM Personel_Maas1";
            DataTable PersonelTablosu = GenelYardim.DataDoldur(Sorgu);
            dataGridView4.DataSource = PersonelTablosu;
            //string BaglantiAdresi = "";
            //SqlConnection Adres = new SqlConnection();
            //try
            //{
            //    BaglantiAdresi = "Data Source = DESKTOP-0PJTRUB; " + "Initial Catalog = Dershane ; " + "User Id = mithat; " + " Password = 1234 ";
            //    Adres.ConnectionString = BaglantiAdresi;
            //    SqlDataAdapter Cevirici = new SqlDataAdapter("SELECT * " +
            //        "FROM [Dershane].[dbo].[Personel_Maas]", Adres);
            //    DataSet ds = new DataSet();
            //    Cevirici.Fill(ds, "Personel_Maas");
            //    dataGridView4.DataSource = ds.Tables["Personel_Maas"].DefaultView;
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("sunucuya bağlanılamadı");
            //}

        }
                
        private void TxtPersonelId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }                               
     
        //Hesaplama alanları      
            
        private void BtnKydt1_Click(object sender, EventArgs e)
        {

            if (LblPersonelId.Text != "" && TxtAylikMaas.Text != "" && TxtAylikMaas.Text != "0" && TxtMaasOdemesi.Text != "" && DateTimePickerMaasOdeme.Value.Date == DateTime.Today)
            {
                string BaglantiAdresi;
                SqlConnection Adres1 = new SqlConnection();
                try
                {
                    BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                    BaglantiAdresi += "Database = Dershane;";
                    BaglantiAdresi += "User Id = mithat;";
                    BaglantiAdresi += "Password= 1234;";
                    Adres1.ConnectionString = BaglantiAdresi;
                    string sorgu = " SELECT [Id] FROM [dbo].[Personel_Kayit] where  (Id =" + int.Parse(TxtPersonelId.Text) + ")";
                    SqlDataAdapter Ceviren = new SqlDataAdapter();
                    DataTable Tablo = new DataTable();
                    using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                    {
                        Ceviren.SelectCommand = new SqlCommand(sorgu, conn);
                        Ceviren.Fill(Tablo);
                    }
                    if (Tablo.Rows.Count > 0)
                    {
                        BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                        BaglantiAdresi += "Database = Dershane;";
                        BaglantiAdresi += "User Id = mithat;";
                        BaglantiAdresi += "Password= 1234;";
                        Adres1.ConnectionString = BaglantiAdresi;
                        string sorgu1 = "select * from Personel_Maas1";
                        SqlDataAdapter Ceviren1 = new SqlDataAdapter();
                        DataTable Tablo1 = new DataTable();
                        using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                        {
                            Ceviren.SelectCommand = new SqlCommand(sorgu1, conn);
                            Ceviren.Fill(Tablo1);
                        }
                        if (Tablo1.Rows.Count>0)
                        {
                            Kaydet1();
                            DataDoldur();
                            TEMIZLE();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Geçerli Personel Id numarası bulunamadı");
                    }


                }
                catch (Exception)
                {

                    MessageBox.Show("Sunucuya bAğlanılamadı");
                }

            }
            else
            {
                MessageBox.Show("Lütfen Bütün Kutucukların Doldurulduğundan Ve Ödeme Tarihi Olarak BUgünün Tarihini Seçtiğinizden Emin Olunuz");
            }
        }
        private void Kaydet1() 
        {
            string islev = "C";
            string Sorgu = "INSERT INTO[dbo].[Personel_Maas1]([Personel_Id] ,[Aylik_Maas] ,[Maas_Odemesi] ,[Mass_Odemesi_Yapilan_Tarih])";
            Sorgu += "VALUES ('" + int.Parse(TxtPersonelId.Text) + "'";
            Sorgu += ",'" + double.Parse(TxtAylikMaas.Text) + "'";
            Sorgu += ",'" + double.Parse(TxtMaasOdemesi.Text) + "'";
            Sorgu += ",'" + DateTimePickerMaasOdeme.Value.Date.ToString("yyyy-MM-dd")+ "')";           
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);

        }

        private void TEMIZLE() 
        {
            TxtPersonelId.Text = "";
            TxtAylikMaas.Text = "";
            TxtMaasOdemesi.Text = "";
            TxtKayitId.Text = "";
            TxtKayitId.Focus();
        }

        private void BtnGuncelle1_Click(object sender, EventArgs e)
        {
            if (DateTimePickerMaasOdeme.Value.Date<=DateTime.Today&& TxtAylikMaas.Text!=""&&TxtMaasOdemesi.Text!="" &&TxtPersonelId.Text!="")
            {
                string BaglantiAdresi;
                SqlConnection Adres1 = new SqlConnection();
                try
                {
                    BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                    BaglantiAdresi += "Database = Dershane;";
                    BaglantiAdresi += "User Id = mithat;";
                    BaglantiAdresi += "Password= 1234;";
                    Adres1.ConnectionString = BaglantiAdresi;
                    string sorgu = " SELECT [Id] FROM [dbo].[Personel_Kayit] where  (Id =" + int.Parse(TxtPersonelId.Text) + ")";
                    SqlDataAdapter Ceviren = new SqlDataAdapter();
                    DataTable Tablo = new DataTable();
                    using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                    {
                        Ceviren.SelectCommand = new SqlCommand(sorgu, conn);
                        Ceviren.Fill(Tablo);
                    }
                    if (Tablo.Rows.Count > 0)
                    {
                        Guncelle();
                        DataDoldur();
                        TEMIZLE();

                    }
                    else
                    {
                        MessageBox.Show("Geçerli Personel Id numarası bulunamadı");
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Sunucuya Bağlanılamadı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bütün Kutucukların Doldurulduğundan Ve Ödeme Tarihi Olarak BUgünün veya Daha Önceki Bir Güne Ait Tarih Seçtiğinizden Emin Olunuz");
            }
        }
        private void Guncelle()
        {
            string islev = "U";
            string Sorgu = "UPDATE [dbo].[Personel_Maas1]";
            Sorgu += "SET[Personel_Id] =" + int.Parse(TxtPersonelId.Text) + ",";
            Sorgu += "[Aylik_Maas] =" + int.Parse(TxtAylikMaas.Text) + ",";
            Sorgu += "[Maas_Odemesi] =" + int.Parse(TxtMaasOdemesi.Text) + ",";            
            Sorgu += "[Mass_Odemesi_Yapilan_Tarih] ='" + DateTimePickerMaasOdeme.Value.ToString("yyyy-MM-dd") + "'";          
            Sorgu += "Where Id=" + int.Parse(TxtKayitId.Text) + "";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);

        }

       
    }      
    
}
