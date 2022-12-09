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
    public static class DataBaseBaglanti
    {
        public static SqlConnection Baglanti()
        {
            SqlConnection Baglan = new SqlConnection();
            string Baglanma = "Data Source = DESKTOP-0PJTRUB; " + "Initial Catalog = Dershane ; " + "User Id = mithat; " + " Password = 1234 ";
            Baglan.ConnectionString = Baglanma;
            return Baglan;

        }
        public static DataTable MusterileriYaz(string sorgu)
        {
            DataTable tablo = new DataTable();
            SqlConnection Baglan =new SqlConnection();
            SqlCommand komut = new SqlCommand(sorgu, Baglan);
            SqlDataAdapter cevir =new SqlDataAdapter(komut);
            

            try
            {
                Baglan.Open();
                cevir.Fill(tablo);

                Baglan.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("sunucuya bağlanılamadı");

            }


            return tablo;
        }


    }
}
