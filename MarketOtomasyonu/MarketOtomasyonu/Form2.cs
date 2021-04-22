using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
namespace MarketOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\MarketTakip.accdb");
        Market seciliMarket = new Market();

        private void Form2_Load(object sender, EventArgs e)
        {

            PersonelleriGoster();
            MarketSubeleriniCek();

        }

        public void MarketSubeleriniCek()
        {
            VeritabaniIslemleri marketSubesiIslemi = new VeritabaniIslemleri();
            DataSet marketler = marketSubesiIslemi.VeritabaniSelectIslemi("Select * from marketler");
            cmBoxMarket.DataSource = marketler.Tables[0];
            cmBoxMarket.DisplayMember = "Market_Adi";
            comboBox2.DataSource = marketler.Tables[0];
            comboBox2.DisplayMember = "Market_Adi";


        }

        public void PersonelleriGoster()
        {
            VeritabaniIslemleri veritabaniIslem = new VeritabaniIslemleri();

            dataGridView1.DataSource = veritabaniIslem.VeritabaniSelectIslemi("Select * from calisanlar").Tables[0];
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (cmBoxPozisyon.SelectedIndex == 0) //müdür ise
                {
                    Mudur mudur = new Mudur();
                    mudur.adSoyad = txtAdSoyad.Text;
                    mudur.adres = txtAdres.Text;
                    mudur.tcNo = decimal.Parse(txtTc.Text);
                    mudur.telefonNo = decimal.Parse(txtTel.Text);
                    mudur.maas = int.Parse(txtMaas.Text);
                    mudur.marketSubesi = cmBoxMarket.Text;
                    mudur.neKadarSuredirCalisiyor = dtTarih.Value;
                    seciliMarket.CalisanEkle(mudur);
                    PersonelleriGoster();

                }
                else if (cmBoxPozisyon.SelectedIndex == 1) //mudur yard. ise
                {
                    MudurYardimcisi mudurYar = new MudurYardimcisi();
                    mudurYar.adSoyad = txtAdSoyad.Text;
                    mudurYar.adres = txtAdres.Text;
                    mudurYar.tcNo = decimal.Parse(txtTc.Text);
                    mudurYar.telefonNo = decimal.Parse(txtTel.Text);
                    mudurYar.maas = int.Parse(txtMaas.Text);
                    mudurYar.marketSubesi = cmBoxMarket.Text;
                    mudurYar.neKadarSuredirCalisiyor = dtTarih.Value;
                    seciliMarket.CalisanEkle(mudurYar);
                    PersonelleriGoster();

                }

                else
                {
                    Kasiyer kasiyer = new Kasiyer();
                    kasiyer.adSoyad = txtAdSoyad.Text;
                    kasiyer.adres = txtAdres.Text;
                    kasiyer.tcNo = decimal.Parse(txtTc.Text);
                    kasiyer.telefonNo = decimal.Parse(txtTel.Text);
                    kasiyer.maas = int.Parse(txtMaas.Text);
                    kasiyer.marketSubesi = cmBoxMarket.Text;
                    kasiyer.neKadarSuredirCalisiyor = dtTarih.Value;
                    seciliMarket.CalisanEkle(kasiyer);
                    PersonelleriGoster();
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata: "+hata.Message);
            }
           
  


          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelleriGoster();
            MarketSubeleriniCek();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int eskiMaas;
            decimal yeniMaas;
            yeniMaas = decimal.Parse(textBox2.Text);
            DataSet gelenCalisan;
            VeritabaniIslemleri islem = new VeritabaniIslemleri();
            Calisanlar ornekCalisan = new Calisanlar();
            ornekCalisan.tcNo = decimal.Parse(textBox1.Text);
            gelenCalisan = islem.VeritabaniSelectIslemi("Select * FROM calisanlar where tc_no='" + textBox1.Text + "' ");
            try
            {

                string title = gelenCalisan.Tables[0].Rows[0]["maas"].ToString();
                if (title == null)
                {
                    MessageBox.Show("Böyle bir çalışan yok!");
                }
                else
                {
                    eskiMaas = int.Parse(title);

                    if (yeniMaas > eskiMaas)
                    {
                        ornekCalisan.MaasiArttir(yeniMaas);
                        PersonelleriGoster();
                    }

                    else
                    {
                        MessageBox.Show("Maaş düşürülemez!, eski maaş daha fazla!");
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Mesajınız: " + hata.Message);
            }

          
        }

      
 


        
        private void btnPozisyonDegistir_Click(object sender, EventArgs e)
        {
            string yeniMevki = comboBox1.Text;
            Calisanlar calisanNesnesi = new Calisanlar();
            calisanNesnesi.tcNo = decimal.Parse(textBox1.Text);

            if (yeniMevki!=null)
            {
                try
                { 
                     calisanNesnesi.MevkiDegistir(yeniMevki);

                    PersonelleriGoster();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata mesajı: "+hata.Message);
                }
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string tc_no = Convert.ToString(selectedRow.Cells["tc_no"].Value);
            string maas = Convert.ToString(selectedRow.Cells["maas"].Value);
            textBox1.Text = tc_no;
            textBox2.Text = maas;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string yeniSube = comboBox2.Text;
            Calisanlar calisanNesnesi = new Calisanlar();
            calisanNesnesi.tcNo = decimal.Parse(textBox1.Text);
            try
            { 
                 calisanNesnesi.SubeDegistir(yeniSube);
                PersonelleriGoster();


            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata mesajınız" + hata);;
            }
        }

        private void btHaftalikIzin_Click(object sender, EventArgs e)
        {
            int kalanIzin = Convert.ToInt32(textBox3.Text);
            
            Calisanlar calisan = new Calisanlar();
            calisan.tcNo = decimal.Parse(textBox1.Text);
                try
                {
                calisan.CalisanIzinKullan(kalanIzin, 1);
                PersonelleriGoster();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("Hata mesajınız: " + hata.Message);
                }
           
          
        }

        private void btSenelikIzin_Click(object sender, EventArgs e)
        {
            int kalanIzin = Convert.ToInt32(textBox4.Text);
            Calisanlar calisan = new Calisanlar();
            calisan.tcNo = decimal.Parse(textBox1.Text);

            try
            { 
    
                calisan.CalisanIzinKullan(kalanIzin, 2);
                PersonelleriGoster();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata mesajınız: " + hata.Message);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.Hide();
        }

        
    }
}
