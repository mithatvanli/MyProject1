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
    public partial class OgrenciFinans : Form
    {
        public OgrenciFinans()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        private void Panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnKpt6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKclt6_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;    
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa anasayfa1=new AnaSayfa();  
            anasayfa1.ShowDialog();
            this.Close();
        }

        private void BtnKpt6_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKpt6.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKpt6_MouseLeave(object sender, EventArgs e)
        {
            BtnKpt6.BackColor = Color.FromArgb(0x0096FF);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackColor = Color.FromArgb(0x7F7F7F);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
           // pictureBox2.BackColor = Color.FromArgb(0x1C4F71);
        }

       
       

        private void TxtKayitUcreti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtOdenenTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TxtKalanBorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void TxtToplamBorc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void TxtOgrenciId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void OgrenciFinans_Load(object sender, EventArgs e)
        {
            DataDoldurr();
            TxtKalanBorc.Enabled = false;
            DateTimePickerOdeme.Enabled= false; 
            checkBox1.Checked = false;
          
        }
        private void DataDoldurr() 
        {
            string Sorgu = "SELECT Id, Kayit_Tutari, Kalan_Toplam_Borc, Odenen_Tutar, Kalan_Borc, Odeme_Yapilan_Tarih, Son_Odeme_Tarihi, Ogrenci_Id FROM Ogrenci_Finans";
            DataTable PersonelTablosu = GenelYardim.DataDoldur(Sorgu);
            dataGridView4.DataSource = PersonelTablosu;
            //string BaglantiAdresi = "";
            //SqlConnection adres = new SqlConnection();
            //try
            //{
            //    BaglantiAdresi = "Data Source = DESKTOP-0PJTRUB;" + "Initial Catalog = Dershane;" + "User Id= mithat;" + "Password = 1234 ;";
            //    adres.ConnectionString = BaglantiAdresi;
            //    SqlDataAdapter cevirici = new SqlDataAdapter("SELECT Id, Toplam_Borc, Kayit_Tutari, Odenen_Tutar, Kalan_Borc, Odeme_Yapilan_Tarih, Son_Odeme_Tarihi, Ogrenci_Id FROM Ogrenci_Finans", adres);
            //    DataSet dss= new DataSet();
            //    cevirici.Fill(dss, "Ogrenci_Finans");
            //    dataGridView4.DataSource = dss.Tables["Ogrenci_Finans"].DefaultView;

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Sunucuya bağlanılamadı");
            //}
        }
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DateTimePickerOdeme.Enabled = true;
            }
            else
            {
                DateTimePickerOdeme.Enabled = false;
            }
        }


        // toplamalar yapılacak
        private void TxtToplamBorc_TextChanged(object sender, EventArgs e)
        {
            if (TxtOdenenTutar.Text != "" && TxtKalanToplamBorc.Text != "")
            {
                double sayi1 = double.Parse(TxtKalanToplamBorc.Text);
                double sayi2 = double.Parse(TxtOdenenTutar.Text);
                double kalan = sayi1 - sayi2;
                TxtKalanBorc.Text = kalan.ToString();
            }
        }


        private void TxtKayitUcreti_TextChanged(object sender, EventArgs e)
        {
            if (TxtOdenenTutar.Text != "" && TxtKalanToplamBorc.Text != "" )
            {
                double sayi1 = double.Parse(TxtKalanToplamBorc.Text);
                double sayi2 = double.Parse(TxtOdenenTutar.Text);
                double kalan = sayi1 - sayi2;
                TxtKalanBorc.Text = kalan.ToString();
            }
        }

       
        private void TxtOdenenTutar_TextChanged(object sender, EventArgs e)
        {
            if (TxtOdenenTutar.Text != "")
            {
                double sayi1 = double.Parse(TxtKalanToplamBorc.Text);
                double sayi2 = double.Parse(TxtOdenenTutar.Text);
                double kalan = sayi1 - sayi2;
                TxtKalanBorc.Text = kalan.ToString();
            }
        }

        private void BtnKydt1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==false)
            {
                if (TxtOgrenciId.Text !="" && TxtKayitUcreti.Text !="" && TxtKalanToplamBorc.Text !="" && TxtOdenenTutar.Text =="0" && TxtKalanBorc.Text!="" && DateTimePickerSonOdeme.Value.Date>=DateTime.Today)
                {
                    double sayi2 = double.Parse(TxtKalanBorc.Text);
                    double sayi1 = double.Parse(TxtKayitUcreti.Text);
                    double sayi3 = double.Parse(TxtKalanToplamBorc.Text);
                    if ((sayi2>=0) && (sayi3<=sayi1))
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
                            string sorgu = " SELECT [Id] FROM [dbo].[Ogrenci_Finans] where  (Id ='" + TxtOgrenciId.Text + "')";
                            SqlDataAdapter Ceviri = new SqlDataAdapter();
                            DataTable Tablo = new DataTable();
                            using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                            {
                                Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                                Ceviri.Fill(Tablo);
                            }
                            if (Tablo.Rows.Count > 0 )
                            {
                                Kaydet1();
                                Temizle();
                                DataDoldurr();
                            }
                            else
                            {
                                MessageBox.Show("Geçerli Öğrenci Id bulunamadı");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sunucuya Bağlanılamadı");
                        }
                    }
                    else if(sayi3>sayi1)
                    {
                        MessageBox.Show("Toplam borç değeri kayıt ücretinden büyük olamaz");
                    }
                    else if (sayi3<0)
                    {
                        MessageBox.Show("Toplam borç değeri '0' değerinden küçük olamaz");
                    }
                    else
                    {
                        MessageBox.Show("Kalan borç değeri '0' değerinden küçük olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukları doldurduğunuzdan ve son ödeme tarihinin bugünün tarihinden büyük olduğuna emin olunuz. Ödeme yapılmadı ise '0' değeri giriniz ve ödeme tarihi seçiniz.");
                }


            }
            else 
            {
                if (TxtOgrenciId.Text != "" && TxtKayitUcreti.Text != "" && TxtKalanToplamBorc.Text != "" && TxtOdenenTutar.Text != "" && TxtOdenenTutar.Text!="0" && TxtKalanBorc.Text != "" &&  DateTimePickerSonOdeme.Value.Date > DateTime.Today && DateTimePickerOdeme.Value.Date==DateTime.Today)
                {
                    double sayi2 = double.Parse(TxtKalanBorc.Text);
                    double sayi1 = double.Parse(TxtKayitUcreti.Text);
                    double sayi3 = double.Parse(TxtKalanToplamBorc.Text);
                    if ((sayi2 >= 0) && (sayi3<=sayi1) && (sayi3>=0) )
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
                            string sorgu = " SELECT [Id] FROM [dbo].[Ogrenci_Finans] where  (Id =" + int.Parse(TxtOgrenciId.Text) + ")";
                            SqlDataAdapter Ceviri = new SqlDataAdapter();
                            DataTable Tablo = new DataTable();
                            using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                            {
                                Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                                Ceviri.Fill(Tablo);
                            }
                            if (Tablo.Rows.Count > 0 && Tablo.Rows.Count < 2)
                            {
                                Kaydet1();
                                Temizle();
                                DataDoldurr();
                            }
                            else
                            {
                                MessageBox.Show("Geçerli Öğrenci Id bulunamadı, Öğrencinin kaydı yapılmamış ise lütfen önce kayıt yapınız");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sunucuya Bağlanılamadı");
                        }
                    }
                    else if (sayi3 > sayi1)
                    {
                        MessageBox.Show("Toplam borç değeri kayıt ücretinden büyük olamaz");
                    }
                    else if (sayi3<0)
                    {
                        MessageBox.Show("Toplam Borç Değeri '0' Değerinden küçük olamaz");
                    }
                    else
                    {
                        MessageBox.Show("Kalan borç değeri '0' değerinden küçük olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukların doğru şekilde doldurumuş olduğundan , son ödeme tarihinin bugünün tarihinden büyük olduğundan ve ödeme tarihinin bugün olduğundan emin olunuz ");
                }
            }
            
        }

        private void BtnGuncelle1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (TxtOgrenciId.Text != "" && TxtKayitUcreti.Text != "" && TxtKalanToplamBorc.Text != "" && TxtOdenenTutar.Text != "" && DateTimePickerSonOdeme.Value.Date > DateTime.Today && TxtKalanBorc.Text != "")
                {
                    double sayi2 = double.Parse(TxtKalanBorc.Text);
                    double sayi1 = double.Parse(TxtKayitUcreti.Text);
                    double sayi3 = double.Parse(TxtKalanToplamBorc.Text);
                    if ((sayi2 > 0) && (sayi1 == sayi3))
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
                            string sorgu = " SELECT [Id] FROM [dbo].[Ogrenci_Kayit] where  (Id =" +int.Parse(TxtOgrenciId.Text) + ")";
                            SqlDataAdapter Ceviri = new SqlDataAdapter();
                            DataTable Tablo = new DataTable();
                            using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                            {
                                Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                                Ceviri.Fill(Tablo);
                            }
                            if (Tablo.Rows.Count > 0)
                            {
                                Guncelle1();
                                DataDoldurr();
                                Temizle();                                
                            }
                            else
                            {
                                MessageBox.Show("Gçerli bir Ogrenci Id numarası bulunamadı");   
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sunucuya Bağlanılamadı");
                        }

                    }
                    else if (sayi3 > sayi1)
                    {
                        MessageBox.Show("Toplam borç değeri kayıt ücretinden büyük olamaz");
                    }
                    else
                    {
                        MessageBox.Show("Kalan borç değeri '0' değerinden küçük olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukları doldurduğunuzdan ve son ödeme tarihinin bugünün tarihinden büyük olduğuna emin olunuz. Unutmayınız ödeme tarihi güncellenemez. Eğer yeni bir ödeme yapıldı ise kayıt butonu ile işlem yapınız.");
                }


            }
            else
            {
                if (TxtOgrenciId.Text != "" && TxtKayitUcreti.Text != "" && TxtKalanToplamBorc.Text != "" && TxtOdenenTutar.Text != "" && TxtKalanBorc.Text != "" && DateTimePickerSonOdeme.Value.Date >= DateTime.Today && DateTimePickerOdeme.Value.Date <= DateTime.Today)
                {
                    double sayi2 = double.Parse(TxtKalanBorc.Text);
                    double sayi1 = double.Parse(TxtKayitUcreti.Text);
                    double sayi3 = double.Parse(TxtKalanToplamBorc.Text);
                    if ((sayi2 > 0) && (sayi1 == sayi3))
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
                            string sorgu = " SELECT [Id] FROM [dbo].[Ogrenci_Kayit] where  (Id =" + int.Parse(TxtOgrenciId.Text) + ")";
                            SqlDataAdapter Ceviri = new SqlDataAdapter();
                            DataTable Tablo = new DataTable();
                            using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                            {
                                Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                                Ceviri.Fill(Tablo);
                            }
                            if (Tablo.Rows.Count > 0)
                            {
                                Guncelle1();
                                DataDoldurr();
                                Temizle();
                            }
                            else
                            {
                                MessageBox.Show("Gçerli bir Ogrenci Id numarası bulunamadı");
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Sunucuya Bağlanılamadı");
                        }
                    }
                    else if (sayi3 > sayi1)
                    {
                        MessageBox.Show("Toplam borç değeri kayıt ücretinden büyük olamaz");
                    }
                    else
                    {
                        MessageBox.Show("Kalan borç değeri '0' değerinden küçük olamaz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukların doğru şekilde doldurumuş olduğundan , son ödeme tarihinin bugünün tarihine eşit veya ileri bir tarih olduğundan ve ödeme tarihinin bugün veya bugünün tarihinden erken bir tarih olduğundan emin olun ");
                }
            }

        }
        public  void Kaydet1() 
        {
            string islev = "C";
            string Sorgu = "INSERT INTO[dbo].[Ogrenci_Finans]([Ogrenci_Id] ,[Kayit_Tutari]  ,[Kalan_Toplam_Borc] ,[Odenen_Tutar],[Kalan_Borc] ,[Odeme_Yapilan_Tarih],[Son_Odeme_Tarihi])";
            Sorgu += "VALUES (" + TxtOgrenciId.Text + "";
            Sorgu += "," + double.Parse(TxtKayitUcreti.Text) + "";
            Sorgu += "," + double.Parse(TxtKalanToplamBorc.Text) + "";
            Sorgu += "," + double.Parse(TxtOdenenTutar.Text) + "";
            Sorgu += "," + double.Parse(TxtKalanBorc.Text) + "";
            Sorgu += ",'" + DateTimePickerOdeme.Value.Date.ToString("yyyy-MM-dd")+ "'";
            Sorgu += ",'" + DateTimePickerSonOdeme.Value.Date.ToString("yyyy-MM-dd") + "')";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);


        }
        private void Temizle() 
        {
            TxtOgrenciId.Text = "";
            TxtKayitUcreti.Text = "";
            TxtKalanToplamBorc.Text = "";
            TxtOdenenTutar.Text = "";
            TxtKalanBorc.Text = "";
            TxtOgrenciId.Focus();
        }
        public void Guncelle0()
        {
            string islev = "U";
            string Sorgu = "UPDATE [dbo].[Ogrenci_Finans]";
            Sorgu += "SET[Kayit_Tutari] =" + double.Parse(TxtKayitUcreti.Text) + ",";
            Sorgu += "[Kalan_Toplam_Borc] =" +double.Parse(TxtKalanToplamBorc.Text) + ",";           
            Sorgu += "[Kalan_Borc] ='" + double.Parse(TxtKalanBorc.Text) + ",";
            Sorgu += "[Son_Odeme_Tarihi] ='" + DateTimePickerSonOdeme.Value.ToString("yyyy-MM-dd") + "',";            
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);
        }
        public void Guncelle1() 
        {
            string islev = "U";
            string Sorgu = "UPDATE [dbo].[Ogrenci_Finans]";
            Sorgu += "SET[Kayit_Tutari] =" + double.Parse(TxtKayitUcreti.Text) + ",";
            Sorgu += "[Kalan_Toplam_Borc] =" + double.Parse(TxtKalanToplamBorc.Text) + ",";
            Sorgu += "[Odenen_Tutar] =" + double.Parse(TxtOdenenTutar.Text) + ",";
            Sorgu += "[Kalan_Borc] ='" + double.Parse(TxtKalanBorc.Text) + ",";
            Sorgu += "[Son_Odeme_Tarihi] ='" + DateTimePickerSonOdeme.Value.ToString("yyyy-MM-dd") + "',";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);
        }



        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            int SecilenSatir = dataGridView4.CurrentRow.Index;
            TxtOgrenciId.Text = (dataGridView4.Rows[SecilenSatir].Cells[0].Value.ToString());
            TxtKayitUcreti.Text = (dataGridView4.Rows[SecilenSatir].Cells[1].Value.ToString());
            TxtKalanToplamBorc.Text = (dataGridView4.Rows[SecilenSatir].Cells[2].Value.ToString());
            TxtOdenenTutar.Text = (dataGridView4.Rows[SecilenSatir].Cells[3].Value.ToString());
            TxtKalanBorc.Text = (dataGridView4.Rows[SecilenSatir].Cells[4].Value.ToString());
            DateTimePickerOdeme.Value = Convert.ToDateTime(dataGridView4.Rows[SecilenSatir].Cells[5].Value.ToString()); 
            DateTimePickerSonOdeme.Value = Convert.ToDateTime(dataGridView4.Rows[SecilenSatir].Cells[6].Value.ToString());
            TxtOgrenciId.Text = (dataGridView4.Rows[SecilenSatir].Cells[7].Value.ToString());

        }


    }
}
