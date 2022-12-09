using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    internal class GenelYardim
    {
        public static SqlConnection BAGLA()
        {
            
            SqlConnection Baglanti = new SqlConnection();
            string BaglantiAdresi = "";
            BaglantiAdresi = "Server=DESKTOP-0PJTRUB;";
            BaglantiAdresi += "Database=Dershane;";
            BaglantiAdresi += "User Id=mithat;";
            BaglantiAdresi += "Password=1234;";
            

            Baglanti.ConnectionString = BaglantiAdresi;
            return Baglanti;
        }

        public static DataTable DataDoldur(string Sorgu)
        {
            DataTable Tablo1 = new DataTable();
            SqlConnection conn = BAGLA();
            SqlCommand Komut = new SqlCommand(Sorgu, conn);
            SqlDataAdapter adap = new SqlDataAdapter(Komut);
            try
            {
                conn.Open();
                adap.Fill(Tablo1);
                conn.Close();
            }
            catch (Exception)
            {
                Tablo1 = null;

            }
            return Tablo1;
        }

        public static void Kaydet_Guncelle(string islev, string sorgu)
        {
            SqlConnection conn = BAGLA();
            SqlCommand Komut = new SqlCommand();
            Komut.Connection = conn;
            Komut.CommandType = CommandType.Text;
            Komut.CommandText = sorgu;
            try
            {
                conn.Open();
                Komut.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("İşlem Başarılı Bir Şekilde Tamamlandı");
            }
            catch (Exception)
            {

                MessageBox.Show("Servere bağlanılamadı");
            }
           
        }
    }
}
