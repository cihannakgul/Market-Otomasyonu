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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            if (comboBox1.SelectedIndex == 0)
            {
                GidaUrunuTedarikcisi gidaTedarikcisi = new GidaUrunuTedarikcisi();
                gidaTedarikcisi.tedarikciAdi = textBox1.Text;
                gidaTedarikcisi.TedarikciAdresi = richTextBox1.Text;
                islem.VeriTabaniTedarikciEkle(gidaTedarikcisi);
            }

            else if (comboBox1.SelectedIndex==1)
            {
                TemizlikUrunuTedarikcisi temizlikTedarikcisi = new TemizlikUrunuTedarikcisi();
                temizlikTedarikcisi.tedarikciAdi = textBox1.Text;
                temizlikTedarikcisi.TedarikciAdresi = richTextBox1.Text;
                islem.VeriTabaniTedarikciEkle(temizlikTedarikcisi);
            }
            else  
            {
                HaftalikKampanyaUrunuTedarikcisi hftTedarikci = new HaftalikKampanyaUrunuTedarikcisi();
                hftTedarikci.tedarikciAdi = textBox1.Text;
                hftTedarikci.TedarikciAdresi = richTextBox1.Text;
                islem.VeriTabaniTedarikciEkle(hftTedarikci);

            }


            TedarikcileriGoruntule();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            TedarikcileriGoruntule();
        }

        public void TedarikcileriGoruntule()
        {

            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            dataGridView1.DataSource = islem.VeritabaniSelectIslemi("Select * from tedarikciler").Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
