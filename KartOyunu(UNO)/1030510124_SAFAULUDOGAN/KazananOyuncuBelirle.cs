using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510124_SAFAULUDOGAN
{
    public class KazananOyuncuBelirle
    {
        private string[] _oyuncuKartlari;
        private string _oyuncuAdi;
        public KazananOyuncuBelirle(kartOzellikler kartOzellikler)
        {
            _oyuncuKartlari = kartOzellikler.eldekiKartlar;
            _oyuncuAdi = kartOzellikler.oyuncu;
        }
         public bool eliKontrolEt()
         {
            bool kazandiMi = false;
            int kartKontrolSayac = 0;
            for (int i = 0; i < 6; i++)
            {
                if (_oyuncuKartlari[i] == "..")
                {
                    kartKontrolSayac++;
                }
            }
            if (kartKontrolSayac >= 6)
            {
                Console.WriteLine();
                Console.WriteLine("OYUN BİTTİ! Kazanan oyuncu : " + _oyuncuAdi);
                kazandiMi = true;
            }
            return kazandiMi;
         }
    }
}
