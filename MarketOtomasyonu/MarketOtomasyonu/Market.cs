using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyonu
{
    class Market
    {
        public string marketIsmi { get; set; }
        public string marketAdresi { get; set; }
        public int marketNo { get; set; }
        VeritabaniIslemleri MarketIslemleri = new VeritabaniIslemleri();


        public Market()
        {
            marketIsmi = "Atanmadi";
        }
        public Market(string marketIsmi, string marketAdresi, int marketNo)
        {
            this.marketIsmi = marketIsmi;
            this.marketAdresi = marketAdresi;
            this.marketNo = marketNo;
        }

        public void CalisanEkle(Calisanlar calisan)
        {


            MarketIslemleri.VeritabaniCalisanEkle(calisan);
      
        }
         
        public void UrunEkle(Urun urun)
        {
            MarketIslemleri.VeritabaniUrunEkle(urun);
        }

 


    }
}
