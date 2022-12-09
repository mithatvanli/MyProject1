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
    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void Panel6_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void BtnKpt5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKclt5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa anaSayfa1=new AnaSayfa();
            anaSayfa1.ShowDialog();
            this.Close();
        }

        private void BtnKpt5_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKpt5.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKpt5_MouseLeave(object sender, EventArgs e)
        {
            BtnKpt5.BackColor = Color.FromArgb(0x0096FF);
        }

        private void OgranciKayit_Load(object sender, EventArgs e)
        {
            
            TxtTc1.MaxLength = 11;
            TxtTelefon1.MaxLength = 11;
            DataDoldur();
            checkBoxBitis.Checked = false;  
            DateTimePickerAyrılıs1.Enabled= false;  
        }
        private void checkBoxBitis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBitis.Checked == true)
            {
                DateTimePickerAyrılıs1.Enabled = true;
            }
            else
            {
                DateTimePickerAyrılıs1.Enabled = false;
            }
        }
        private void TxtTc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefon1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtAd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void TxtSoyad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        public void DataDoldur()
        {
            string Sorgu = "SELECT Id, Tc, Ad, Soyad, Sınıf, Kayit_Tarihi, Ayrılıs_Tarihi, Telefon_No FROM Ogrenci_Kayit ";
            DataTable PersonelTablosu = GenelYardim.DataDoldur(Sorgu);
            DataGridView3.DataSource = PersonelTablosu;
            //string BaglantiAdresi = "";
            //SqlConnection Adres = new SqlConnection();
            //try
            //{
            //    BaglantiAdresi = "Data Source = DESKTOP-0PJTRUB; " + "Initial Catalog = Dershane;" + "User Id = mithat;" + "Password = 1234 ;";
            //    Adres.ConnectionString = BaglantiAdresi;
            //    SqlDataAdapter Cevir = new SqlDataAdapter("SELECT Id, Tc, Ad, Soyad, Sınıf, Kayit_Tarihi, Ayrılıs_Tarihi, Telefon_No FROM Ogreci_Kayit", Adres);

            //    DataSet ds = new DataSet();
            //    Cevir.Fill(ds, "Ogrenci_Kayit");
            //    DataGridView3.DataSource = ds.Tables["Ogrenci_Kayit"].DefaultView;
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Kütüphaneye Bağlanırken Hata Oluştu");
            //}
        }


        private void BtnKydt1_Click(object sender, EventArgs e)
        {
            if (checkBoxBitis.Checked==false)
            {
                if (TxtTc1.Text != "" && TxtAd1.Text != "" && TxtSoyad1.Text != "" && TxtSinif.Text != "" && TxtTelefon1.Text != "" && DateTimePickerBaslama1.Value.Date == DateTime.Today &&TxtId1.Text=="")
                {
                    //işten ayrılma tarihi null olacak
                    string BaglantiAdresi;
                    SqlConnection Adres1 = new SqlConnection();
                    try
                    {
                        BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                        BaglantiAdresi += "Database = Dershane;";
                        BaglantiAdresi += "User Id = mithat;";
                        BaglantiAdresi += "Password= 1234;";
                        Adres1.ConnectionString = BaglantiAdresi;
                        string sorgu = " SELECT Tc FROM   Ogreci_Kayit where  Tc ='" + TxtTc1.Text + "'";
                        SqlDataAdapter Ceviri = new SqlDataAdapter();
                        DataTable Tablo = new DataTable();
                        using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                        {
                            Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                            Ceviri.Fill(Tablo);
                        }
                        if (Tablo.Rows.Count > 0)
                        {
                            string sorgu1 = " SELECT Tc, Ayrılıs_Tarihi FROM   Ogreci_Kayit";
                            sorgu1 += " where Tc='" + TxtTc1.Text + "'";
                            sorgu1 += " and ";
                            sorgu1 += "Ayrılıs_Tarihi is null ";

                            SqlDataAdapter Cevirici1 = new SqlDataAdapter();
                            DataTable Tablo1 = new DataTable();
                            using (SqlConnection conn1 = new SqlConnection(BaglantiAdresi)) 
                            {
                                Cevirici1.SelectCommand = new SqlCommand(sorgu1, conn1);
                                Cevirici1.Fill(Tablo1);
                                if (Tablo1.Rows.Count > 0)
                                {
                                    MessageBox.Show("Personel İşten Ayrılmadan Yeni Bir Kayıt Yapılamaz");
                                }
                                else
                                {
                                    Kaydet11();
                                    DataDoldur();
                                    Temizle();
                                    
                                }
                            }
                        }
                        else
                        {
                            Kaydet11();
                            DataDoldur();
                            Temizle();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sunucuya Bağlanılamadı");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bütün kutucukların boş olmadığından, Kayıt tarihinin bugün olduğundan emin olunuz son olarak sitem öğrenci Id numarasını otomatik atayacağından dolayı Id kutucuğunun boş olduğundan emin olunuz");
                }
            }
            else
            {
                MessageBox.Show("İşten ayrılma kutucuğunu işaretlenmiş ise  işareti kaldırın ,öğrenci eğitim dönemini tamamladı ise bu işlemi güncelleme butonu ile yapınız ");
            }
        }
        public void Temizle()
        {
            TxtAd1.Text = "";            
            TxtSoyad1.Text = "";
            TxtTc1.Text = "";
            TxtTelefon1.Text = "";
            TxtSinif.Text = "";

        }
        
        public void Kaydet11() 
        {
            string islev = "C";
            string Kaydet = "INSERT INTO[dbo].[Ogrenci_Kayit]([Tc] ,[Ad]  ,[Soyad] ,[Sınıf],[Kayit_Tarihi] ,[Telefon_No])";
            Kaydet += "VALUES ('" + TxtTc1.Text + "'";
            Kaydet += ",'" + TxtAd1.Text + "'";
            Kaydet += ",'" + TxtSoyad1.Text + "'";
            Kaydet += ",'" + TxtSinif.Text + "'";
            Kaydet += ",'" + DateTimePickerBaslama1.Value.Date.ToString("yyyy-MM-dd") + "'";
            Kaydet+= ",'" + TxtTelefon1.Text + "')";
            GenelYardim.Kaydet_Guncelle(islev, Kaydet);

        }

        private void DataGridView3_SelectionChanged(object sender, EventArgs e)
        {

            
            if (DataGridView3.TabIndex>-1)
            {
                TxtId1.Text = (DataGridView3.CurrentRow.Cells[0].Value.ToString());
                TxtTc1.Text = (DataGridView3.CurrentRow.Cells[1].Value.ToString());
                TxtAd1.Text = (DataGridView3.CurrentRow.Cells[2].Value.ToString());
                TxtSoyad1.Text = (DataGridView3.CurrentRow.Cells[3].Value.ToString());
                TxtSinif.Text = (DataGridView3.CurrentRow.Cells[4].Value.ToString());
                TxtTelefon1.Text = (DataGridView3.CurrentRow.Cells[7].Value.ToString());
                
            }
            
        }

        private void OgrenciKayit_Leave(object sender, EventArgs e)
        {

        }

        private void BtnGuncelle1_Click(object sender, EventArgs e)
        {
            if (checkBoxBitis.Checked==true)
            {
                if (TxtId1.Text!="" && TxtTc1.Text.Length==11 && TxtAd1.Text!="" && TxtSoyad1.Text!="" && TxtSinif.Text!="" && TxtTelefon1.Text!="" && DateTimePickerBaslama1.Value.Date<=DateTime.Today)
                {
                    string BaglantiAdresi;
                    string Sorgu;
                    SqlConnection Adres = new SqlConnection();
                    try
                    {
                        BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                        BaglantiAdresi += "Database =Dershane";
                        BaglantiAdresi += "User Id =mithat";
                        BaglantiAdresi += "Password =1234";
                        Sorgu = "Select [Id] From [dbo].[Ogrenci_Kayit] where (Id=" + int.Parse(TxtId1.Text) + ")";
                        Adres.ConnectionString = BaglantiAdresi;
                        SqlDataAdapter Cevir = new SqlDataAdapter();
                        DataTable Tablo =new DataTable();   
                        using(SqlConnection connection1 = new SqlConnection(BaglantiAdresi)) 
                        {
                            Cevir.SelectCommand = new SqlCommand(Sorgu, connection1);
                            Cevir.Fill(Tablo);
                        }
                        if (Tablo.Rows.Count>0)
                        {
                            Guncelle();
                            DataDoldur();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Geçerli bir Öğrenci Id numarası bulunamadı. Öğrenci kaydı yapılmamış ise lütfen önce kayıt yapınız");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sunucuya bağlanırken hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukların doldurulduğundan ve işe başlama tarihinin bugüne ait veya daha önceki bir güne ait bir tarih seçildiğinden emin olunuz");
                }
            }
            else 
            {
                if (TxtId1.Text != "" && TxtTc1.Text.Length == 11 && TxtAd1.Text != "" && TxtSoyad1.Text != "" && TxtSinif.Text != "" && TxtTelefon1.Text != "" && DateTimePickerBaslama1.Value.Date <= DateTime.Today && DateTimePickerAyrılıs1.Value.Date==DateTime.Today)
                {
                    string BaglantiAdresi;
                    string Sorgu;
                    SqlConnection Adres = new SqlConnection();
                    try
                    {
                        BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
                        BaglantiAdresi += "Database =Dershane";
                        BaglantiAdresi += "User Id =mithat";
                        BaglantiAdresi += "Password =1234";
                        Sorgu = "Select [Id] From [dbo].[Ogrenci_Kayit] where (Id=" + int.Parse(TxtId1.Text) + ")";
                        Adres.ConnectionString = BaglantiAdresi;
                        SqlDataAdapter Cevir = new SqlDataAdapter();
                        DataTable Tablo = new DataTable();
                        using (SqlConnection connection1 = new SqlConnection(BaglantiAdresi))
                        {
                            Cevir.SelectCommand = new SqlCommand(Sorgu, connection1);
                            Cevir.Fill(Tablo);
                        }
                        if (Tablo.Rows.Count > 0)
                        {
                            Guncelle2();
                            DataDoldur();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Geçerli bir Öğrenci Id numarası bulunamadı. Öğrenci kaydı yapılmamış ise lütfen önce kayıt yapınız");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Sunucuya bağlanırken hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukların doldurulduğundan , işe başlama tarihinin bugüne ait veya daha önceki bir güne ait bir tarih seçildiğinden ve işten ayrılış tarihinin bugüne ait tarih seçildiğinden emin olunuz");
                }
            }
        }
        private void Guncelle() 
        {
            string islev = "U";
            string Sorgu ="UPDATE [dbo].[Personel_Kayit]";
            Sorgu += "SET[Tc] ='" + TxtTc1.Text + "',";
            Sorgu += "[Ad] ='" + TxtAd1.Text + "',";
            Sorgu += "[Soyad] ='" + TxtSoyad1.Text + "',";
            Sorgu += "[Sınıf] ='" + TxtSinif.Text + "',";
            Sorgu += "[Kayit_Tarihi] ='" + DateTimePickerBaslama1.Value.ToString("yyyy-MM-dd") + "',";            
            Sorgu += "[Telefon_No] ='" + TxtTelefon1.Text + "'";
            Sorgu += "Where Id=" + int.Parse(TxtId1.Text) + "";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);
        }
        private void Guncelle2() 
        {
            string islev = "U";
            string Sorgu = "UPDATE [dbo].[Personel_Kayit]";
            Sorgu += "SET[Tc] ='" + TxtTc1.Text + "',";
            Sorgu += "[Ad] ='" + TxtAd1.Text + "',";
            Sorgu += "[Soyad] ='" + TxtSoyad1.Text + "',";
            Sorgu += "[Sınıf] ='" + TxtSinif.Text + "',";
            Sorgu += "[Kayit_Tarihi] ='" + DateTimePickerBaslama1.Value.ToString("yyyy-MM-dd") + "',";
            Sorgu += "[Telefon_No] ='" + TxtTelefon1.Text + "'";
            Sorgu += "[Ayrılıs_Tarihi] ='" + DateTimePickerAyrılıs1.Value.ToString("yyyy-MM-dd") + "',";
            Sorgu += "Where Id=" + int.Parse(TxtId1.Text) + "";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);

        }
        //public void Kaydet()  //Alternatif Kaydet uzun yol
        //{
        //string BaglantiAdresi;
        //BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
        //BaglantiAdresi += "Database = Dershane;";
        //BaglantiAdresi += "User Id = mithat;";
        //BaglantiAdresi += "Password= 1234;";

        //string Kaydet = "INSERT INTO[dbo].[Ogrenci_Kayit]([Tc] ,[Ad]  ,[Soyad] ,[Sınıf],[Kayıt_Tarihi] ,[Telefon_No])";
        //Kaydet += "VALUES ('" + TxtTc1.Text + "'";
        //Kaydet += ",'" + TxtAd1.Text + "'";
        //Kaydet += ",'" + TxtSoyad1.Text + "'";
        //Kaydet += ",'" + TxtSinif.Text + "'";
        //Kaydet += ",'" + DateTimePickerBaslama1.Value.Date.ToString() + "'";

        //Kaydet += ",'" + TxtTelefon1.Text + "')";
        //SqlConnection Adres = new SqlConnection();
        //Adres.ConnectionString = BaglantiAdresi;
        //SqlCommand Emir = new SqlCommand();
        //Emir.Connection = Adres;
        //Emir.CommandType = CommandType.Text;
        //Emir.CommandText = Kaydet;
        //try
        //{
        //    Adres.Open();
        //    Emir.ExecuteNonQuery();
        //    Adres.Close();
        //    MessageBox.Show("Kayıt Başarılı");
        //    Temizle();
        //}
        //catch (Exception)
        //{

        //    MessageBox.Show("Kaydetme esnasında hata oluştu");
        //}
        //}
    }

}
