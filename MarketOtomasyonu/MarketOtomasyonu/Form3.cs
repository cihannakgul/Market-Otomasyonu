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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        VeritabaniIslemleri veritabaniIslem = new VeritabaniIslemleri();
        private void Form3_Load(object sender, EventArgs e)
        {
            MarketleriGoruntule();
        }


        public void MarketleriGoruntule()
        {
           

            dataGridView1.DataSource = veritabaniIslem.VeritabaniSelectIslemi("Select * from marketler").Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Market marketNesnesi = new Market();
            marketNesnesi.marketIsmi = txtMarketAdi.Text;
            marketNesnesi.marketAdresi = txtMarketAdresi.Text;
            veritabaniIslem.VeritabaniMarketEkle(marketNesnesi);
            MarketleriGoruntule();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
