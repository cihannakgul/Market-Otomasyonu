using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketOtomasyonu
{
    public partial class Form1 : Form
    {
        Form2 CalisanYonetimPaneliForm = new Form2();
        Form3 MarketYonetimPaneliForm = new Form3();
        Form4 TedarikciEkleForm = new Form4();
        Form5 StokForm = new Form5();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalisanYonetimPaneliForm.MarketSubeleriniCek();
            CalisanYonetimPaneliForm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MarketYonetimPaneliForm.MarketleriGoruntule();
            MarketYonetimPaneliForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TedarikciEkleForm.TedarikcileriGoruntule();
            TedarikciEkleForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StokForm.PersonelleriCek();
            StokForm.MarketleriCek();
            StokForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
