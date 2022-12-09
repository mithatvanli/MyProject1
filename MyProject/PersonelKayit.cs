using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MyProject
{
    public partial class PersonelKayit : Form
    {
        public object TxtParola { get; private set; }

        public PersonelKayit()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);



        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnKpt2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnKclt2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnaSayfa anaSayfa1=new AnaSayfa();
            anaSayfa1.ShowDialog();
            this.Show();    
        }

        private void BtnKpt2_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKpt2.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKpt2_MouseLeave(object sender, EventArgs e)
        {
            BtnKpt2.BackColor = Color.FromArgb(0x0096FF);
        }

        private void PersonelKayit_Load(object sender, EventArgs e)
        {
            TxtTc.MaxLength = 11;
            TxtTelefon.MaxLength = 11;            
            Chckbxayrilma.Checked= false;
            DateTimePickerBitis.Enabled = false;            
            DataDoldur();
            
        }
        public void DataDoldur()
        {
            string Sorgu = "SELECT Id, Tc, Ad, Soyad, Brans, Kayıt_Tarihi, Ayrılıs_Tarihi, Telefon_No FROM Personel_Kayit";
            DataTable PersonelTablosu = GenelYardim.DataDoldur(Sorgu);
            dataGridView1.DataSource = PersonelTablosu;



            //string BaglantiAdresi = "";
            //SqlConnection Adres = new SqlConnection();
            //try
            //{
            //    BaglantiAdresi = "Data Source = DESKTOP-0PJTRUB; " + "Initial Catalog = Dershane ; " + "User Id = mithat; " + " Password = 1234 ";
            //    Adres.ConnectionString = BaglantiAdresi;
            //    SqlDataAdapter Cevirici = new SqlDataAdapter("SELECT * " +
            //        "FROM [Dershane].[dbo].[Personel_Kayit]", Adres);
            //    DataSet ds = new DataSet();
            //    Cevirici.Fill(ds, "Personel_Kayit");
            //    dataGridView1.DataSource = ds.Tables["Personel_Kayit"].DefaultView;
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("sunucuya bağlanılamadı");
            //}

        }
        private void Chckbxayrilma_CheckedChanged(object sender, EventArgs e)
        {
            if (Chckbxayrilma.Checked == true)
            {
                DateTimePickerBitis.Enabled = true;
            }
            else
            {
                DateTimePickerBitis.Enabled = false;
            }
        }
        private void TxtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
           
        }
        private void TxtTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
        private void TxtBrans_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
              && !char.IsSeparator(e.KeyChar);

        }

        private void TxtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                   && !char.IsSeparator(e.KeyChar);
        }

        private void BtnKydt_Click(object sender, EventArgs e)
        {
            if (Chckbxayrilma.Checked==false)
            
            
            {
                if (TxtBrans.Text != "" && TxtTc.Text != "" && TxtTc.Text.Length==11 && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtTelefon.Text != "" && DateTimePickerBaslama.Value.Date == DateTime.Today && TxtId.Text=="")
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
                        string sorgu = " SELECT [Tc] FROM [dbo].[Personel_Kayit] where  (Tc ='" + TxtTc.Text + "')";
                        SqlDataAdapter Ceviri = new SqlDataAdapter();
                        DataTable Tablo = new DataTable();
                        using (SqlConnection conn = new SqlConnection(BaglantiAdresi)) 
                        {
                            Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                            Ceviri.Fill(Tablo);
                        }
                        if (Tablo.Rows.Count>0)
                        {
                            string sorgu1 = " SELECT [Tc] , [Ayrılıs_Tarihi] FROM [dbo].[Personel_Kayit]" ;
                            sorgu1 += " where Tc='"+TxtTc.Text+"'";
                            sorgu1 += " and " ;
                            sorgu1 += "Ayrılıs_Tarihi is null ";

                            SqlDataAdapter Cevirici1=new SqlDataAdapter();
                            DataTable Tablo1 = new DataTable();
                            using(SqlConnection conn1 =new SqlConnection(BaglantiAdresi)) 
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
                                    Temizle();
                                    DataDoldur();
                                }
                            }
                        }
                        else
                        {
                            Kaydet11();
                            Temizle();
                            DataDoldur();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sunucuya Bağlanılamadı");
                    }                  
                }
                else
                {
                    MessageBox.Show("Lütfen Id kutucuğu hariç bütün kutucukların dolu olduğundan ve işe başlama tarihinin bugüne ait olan tarih seçildiğinden emin olun ve Id kutucuğunu boşaltın");
                }
            }
            else
            {
                MessageBox.Show("İşten ayrılma kutucuğunu işaretlenmiş ise  işareti kaldırın ve personel işten ayrıldı ise bu işlemi güncelleme butonu ile yapınız");
            }
           

        }
        public void Temizle() 
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtBrans.Text = "";
            TxtSoyad.Text = "";
            TxtTc.Text = "";
            TxtTelefon.Text = "";
               
        }
       
        public void Kaydet11() 
        {
            string islev = "C";
            string Sorgu = "INSERT INTO[dbo].[Personel_Kayit]([Tc] ,[Ad]  ,[Soyad] ,[Brans],[Kayıt_Tarihi] ,[Telefon_No])";
            Sorgu += "VALUES ('" + TxtTc.Text + "'";
            Sorgu += ",'" + TxtAd.Text + "'";
            Sorgu += ",'" + TxtSoyad.Text + "'";
            Sorgu += ",'" + TxtBrans.Text + "'";
            Sorgu += ",'" + DateTimePickerBaslama.Value.Date.ToString("yyyy-MM-dd") + "'";
            //Sorgu += ",'" + DateTimePickerBitis.Value.Date.ToString()+ "'";
            Sorgu += ",'" + TxtTelefon.Text + "')";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            TxtId.Text = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
            TxtTc.Text= (dataGridView1.CurrentRow.Cells[1].Value.ToString());            
            TxtAd.Text= (dataGridView1.CurrentRow.Cells[2].Value.ToString());
            TxtSoyad.Text= (dataGridView1.CurrentRow.Cells[3].Value.ToString());
            TxtBrans.Text = (dataGridView1.CurrentRow.Cells[4].Value.ToString());
            TxtTelefon.Text= (dataGridView1.CurrentRow.Cells[7].Value.ToString());
            //DateTimePickerBaslama.Value=Convert.ToDateTime(dataGridView1.Rows[SecilenSatir].Cells[5].Value.ToString());
        }
        public void Kaydet1() //Alternatif kaydet uzun yol
        {

            //string BaglantiAdresi;
            //SqlConnection Adres1 = new SqlConnection();
            //BaglantiAdresi = "Server =DESKTOP-0PJTRUB;";
            //BaglantiAdresi += "Database = Dershane;";
            //BaglantiAdresi += "User Id = mithat;";
            //BaglantiAdresi += "Password= 1234;";
            //string Kaydet = "INSERT INTO[dbo].[Personel_Kayit]([Tc] ,[Ad]  ,[Soyad] ,[Brans],[Kayıt_Tarihi] ,[Telefon_No])";
            //Kaydet += "VALUES ('" + TxtTc.Text + "'";
            //Kaydet += ",'" + TxtAd.Text + "'";
            //Kaydet += ",'" + TxtSoyad.Text + "'";
            //Kaydet += ",'" + TxtBrans.Text + "'";
            //Kaydet += ",'" + DateTimePickerBaslama.Value.Date.ToString("yyyy-MM-dd") + "'";
            ////Kaydet += ",'" + DateTimePickerBitis.Value.Date.ToString()+ "'";
            //Kaydet += ",'" + TxtTelefon.Text + "')";

            //Adres1.ConnectionString = BaglantiAdresi;
            //SqlCommand Emir = new SqlCommand();
            //Emir.Connection = Adres1;
            //Emir.CommandType = CommandType.Text;
            //Emir.CommandText = Kaydet;
            //try
            //{
            //    Adres1.Open();
            //    Emir.ExecuteNonQuery();
            //    Adres1.Close();
            //    MessageBox.Show("Kayıt Başarılı");
            //    DataDoldur();
            //    Temizle();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Kaydetme esnasında hata oluştu" + ex.Message.ToString());
            //}
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Chckbxayrilma.Checked == false )
            {
                if (TxtBrans.Text != "" && TxtTc.Text != "" && TxtTc.Text.Length == 11 && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtTelefon.Text != "" && TxtId.Text!="" && DateTimePickerBaslama.Value.Date <= DateTime.Today)
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
                        string sorgu = " SELECT [Id] FROM [dbo].[Personel_Kayit] where  (Id =" + int.Parse(TxtId.Text) + ")";
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
                            DataDoldur();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılacak personele ait Id Numarası bulunamadı. Lütfen geçerli bir Id Numarası giriniz.");
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
                    MessageBox.Show("Lütfen bütün kutucukların doldurulduğundan ve işe başlama tarihinin bugüne ait olan tarih seçildiğinden emin olun");
                }
            }
            else
            {
                if (TxtBrans.Text != "" && TxtTc.Text != "" && TxtTc.Text.Length == 11 && TxtAd.Text != "" && TxtSoyad.Text != "" && TxtTelefon.Text != "" && TxtId.Text != "" && DateTimePickerBitis.Value.Date== DateTime.Today && DateTimePickerBaslama.Value.Date<DateTime.Today)
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
                        string sorgu = " SELECT [Id] FROM [dbo].[Personel_Kayit] where  (Id =" + int.Parse(TxtId.Text) + ")";
                        SqlDataAdapter Ceviri = new SqlDataAdapter();
                        DataTable Tablo = new DataTable();
                        using (SqlConnection conn = new SqlConnection(BaglantiAdresi))
                        {
                            Ceviri.SelectCommand = new SqlCommand(sorgu, conn);
                            Ceviri.Fill(Tablo);
                        }
                        if (Tablo.Rows.Count > 0)
                        {
                            Guncelle2();                            
                            DataDoldur();
                            Temizle();
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme yapılacak personele ait Id Numarası bulunamadı. Lütfen geçerli bir Id Numarası giriniz.");

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Sunucuya Bağlanılamadı");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bütün kutucukların doldurulduğundan işe başlama tarihinin bugüne ait tarihten önceki bir tarih seçildiğinden ve işten ayrılış tarihinin bugüne ait tarih seçildiğinden emin olunuz");
                }
            }
        }
        public void Guncelle1() 
        {
            string islev = "U";
            string Sorgu= "UPDATE [dbo].[Personel_Kayit]";
            Sorgu += "SET[Tc] ='" + TxtTc.Text + "',";
            Sorgu += "[Ad] ='" + TxtAd.Text + "',";
            Sorgu += "[Soyad] ='" + TxtSoyad.Text + "',";
            Sorgu += "[Brans] ='" + TxtBrans.Text + "',";
            Sorgu += "[Kayıt_Tarihi] ='" + DateTimePickerBaslama.Value.ToString("yyyy-MM-dd") + "',";
            //sorgu  += "[Ayrılıs_Tarihi] ='" + DateTimePickerBitis.Value.ToString("yyyy-MM-dd") + "',";
            Sorgu += "[Telefon_No] ='" + TxtTelefon.Text + "'";
            Sorgu += "Where Id=" + int.Parse(TxtId.Text) + "";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);  
        }
        public void Guncelle2() 
        {
            string islev = "U";
            string Sorgu = "UPDATE [dbo].[Personel_Kayit]";
            Sorgu += "SET[Tc] ='" + TxtTc.Text + "',";
            Sorgu += "[Ad] ='" + TxtAd.Text + "',";
            Sorgu += "[Soyad] ='" + TxtSoyad.Text + "',";
            Sorgu += "[Brans] ='" + TxtBrans.Text + "',";
            Sorgu += "[Kayıt_Tarihi] ='" + DateTimePickerBaslama.Value.ToString("yyyy-MM-dd") + "',";
            Sorgu  += "[Ayrılıs_Tarihi] ='" + DateTimePickerBitis.Value.ToString("yyyy-MM-dd") + "',";
            Sorgu += "[Telefon_No] ='" + TxtTelefon.Text + "'";
            Sorgu += "Where Id=" + int.Parse(TxtId.Text) + "";
            GenelYardim.Kaydet_Guncelle(islev, Sorgu);
        }
    }
}
