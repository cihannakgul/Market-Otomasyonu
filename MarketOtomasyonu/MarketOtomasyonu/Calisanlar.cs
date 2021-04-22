using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketOtomasyonu
{
    class Calisanlar
    {

        public string adSoyad { get; set; }
        public string adres { get; set; }
        public string marketSubesi { get; set; }
        public decimal tcNo { get; set; }
        public decimal telefonNo { get; set; }
        public int haftalikIzin { get; set; }
        public int senelikIzin { get; set; }
        public decimal maas { get; set; }
        public DateTime neKadarSuredirCalisiyor { get; set; }
        public string calisanRutbesi { get; set; } 
        VeritabaniIslemleri calisanIslemleri = new VeritabaniIslemleri();
 

        public Calisanlar()
        {
            haftalikIzin = 1;
            senelikIzin = 14;

        }
        public Calisanlar(string adSoyad, string adres, decimal tcNo, decimal telefonNo, decimal maas, DateTime neKadarSuredirCalisiyor, string calisanRutbesi)
        {
            this.adSoyad = adSoyad;
            this.adres = adres;
            this.tcNo = tcNo;
            this.telefonNo = telefonNo;
            this.neKadarSuredirCalisiyor = neKadarSuredirCalisiyor;
            this.calisanRutbesi = calisanRutbesi;
            haftalikIzin = 1;
            senelikIzin = 14;
        }

        public void RutbeDegistir(string rutbe)
        {
            calisanRutbesi = rutbe;
        }

        public void MaasiArttir(decimal yeniMaas)
        {
            calisanIslemleri.CalisanMaasArtir(tcNo, yeniMaas);
        }

        public void MevkiDegistir(string rutbe)
        {
            calisanIslemleri.CalisanMevkiDegistir(tcNo, rutbe);
        }

       public void CalisanIzinKullan(int kalanIzin, int izinTuru)
        {
            calisanIslemleri.CalisanIzinKullan(tcNo, kalanIzin, izinTuru);
        }

        public void SubeDegistir(string yeniSube)
        {
            calisanIslemleri.CalisanSubeDegistir(tcNo, yeniSube);
        }

         
    }
}
