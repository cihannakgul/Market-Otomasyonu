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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            MarketleriCek();
            PersonelleriCek();
            UrunleriCek();
        }

        public void PersonelleriCek()
        {


            VeritabaniIslemleri personelCek = new VeritabaniIslemleri();
            DataSet personeller = personelCek.VeritabaniSelectIslemi("Select * from calisanlar");
            
            comboBox5.DataSource = personeller.Tables[0];
            
            comboBox5.DisplayMember = "ad_soyad";
          
        }

        public void MarketleriCek()
        {

            VeritabaniIslemleri marketSubesiIslemi = new VeritabaniIslemleri();
            DataSet marketler = marketSubesiIslemi.VeritabaniSelectIslemi("Select * from marketler");
            comboBox2.DataSource = marketler.Tables[0];
            comboBox2.DisplayMember = "Market_Adi";
            comboBox1.DataSource = marketler.Tables[0];
            comboBox1.DisplayMember = "Market_Adi";
        }

        public void UrunleriCek()
        {
            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            dataGridView2.DataSource =  islem.VeritabaniSelectIslemi("Select * from urunler").Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet market;
            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            try
            {
                market = islem.VeritabaniSelectIslemi("Select * from urunler where Market='" + comboBox1.Text + "'");
                dataGridView1.DataSource = market.Tables[0];
            }
            catch (Exception hata)
            {

                MessageBox.Show("OOPS! Hata: "+hata.Message);
            }
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Market marketeUrunEkle = new Market();
            if (comboBox3.SelectedIndex == 0)
            {
                GidaUrunu gida = new GidaUrunu();
                gida.urunAdi = textBox1.Text;
                gida.urunMarket = comboBox2.Text;
                gida.urunFiyat = Convert.ToDouble(textBox3.Text);
                marketeUrunEkle.UrunEkle(gida);
  
               
            }


            else if (comboBox3.SelectedIndex == 1)
            {
                TemizlikUrunu urun = new TemizlikUrunu();
                urun.urunAdi = textBox1.Text;
                urun.urunMarket = comboBox2.Text;
                urun.urunFiyat = Convert.ToDouble(textBox3.Text);
                marketeUrunEkle.UrunEkle(urun);
            }
            else
            {

                HaftalikKampanyaUrunu hftUrun = new HaftalikKampanyaUrunu();
                hftUrun.urunAdi = textBox1.Text;
                hftUrun.urunMarket = comboBox2.Text;
                hftUrun.urunFiyat = Convert.ToDouble(textBox3.Text);
                marketeUrunEkle.UrunEkle(hftUrun);

            }

            UrunleriCek();
            MessageBox.Show("Test");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            VeritabaniIslemleri indirimGo = new VeritabaniIslemleri();
            DataSet gelenCalisan = indirimGo.VeritabaniSelectIslemi("Select * from calisanlar where ad_soyad='" + comboBox5.Text + "' ");
            string rutbe = gelenCalisan.Tables[0].Rows[0]["mevki"].ToString();
            if (rutbe== "Yönetici")
            {
               
                indirimGo.IndirimTanimla(comboBox4.Text, Convert.ToInt32(textBox2.Text));
                MessageBox.Show("İndirim tanımlandı! Sayın "+rutbe);

            }
            else if (rutbe=="Müdür" && comboBox4.SelectedIndex==2)
            {
                indirimGo.IndirimTanimla(comboBox4.Text, Convert.ToInt32(textBox2.Text));
                MessageBox.Show("İndirim tanımlandı! Sayın " + rutbe);
            }
            else
            {

                MessageBox.Show("Bu indirimi tanımlayamıyorsunuz çünkü yetkiniz:  "+rutbe);
            }


            UrunleriCek();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
