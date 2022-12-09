using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
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

     

        private void BtnPersonelMaas_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelFinans personelFinans1=new PersonelFinans();
            personelFinans1.ShowDialog();
            this.Close();
        }

        private void BtnPrsnlKyt_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelKayit personelKayit1=new PersonelKayit(); 
            personelKayit1.ShowDialog();
            this.Close();
        }

        private void BtnOgrncıKyt_Click(object sender, EventArgs e)
        {
            this.Hide();
            OgrenciKayit Oogrencikayit1=new OgrenciKayit();
            Oogrencikayit1.ShowDialog();
            this.Close();
        }

        private void BtnOgrncFnns_Click(object sender, EventArgs e)
        {
            this.Hide();
            OgrenciFinans ogrenciFinans1=new OgrenciFinans();
            ogrenciFinans1.ShowDialog();
            this.Close();
        }

        private void BtnKapat_MouseMove(object sender, MouseEventArgs e)
        {
            BtnKapat.BackColor = Color.FromArgb(0xcf0404);
        }

        private void BtnKapat_MouseLeave(object sender, EventArgs e)
        {
            BtnKapat.BackColor = Color.FromArgb(0x023233);
        }
    }
}
