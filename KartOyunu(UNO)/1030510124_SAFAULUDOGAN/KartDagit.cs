using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510124_SAFAULUDOGAN
{
    public class KartDagit
    {
        Random r = new Random();
        int uretilenKartIndex;
        string[] dagitilacakKartlar = { "s1","s2","s3","s4","s5",
                             "k1","k2","k3","k4","k5",
                             "m1","m2","m3","m4","m5",
                             "rd","rd","rd"};
        public string dagit(string[] oyuncu)//oyuncularımızın dizilerini alarak kartlarını random şekilde veriyoruz
        {

            for (int i = 0; i < 6; i++)//her oyuncuya 6 kart
            {
                uretilenKartIndex = r.Next(0, 18);
                if (dagitilacakKartlar[uretilenKartIndex] != ".")
                {
                    oyuncu[i] = dagitilacakKartlar[uretilenKartIndex];
                    dagitilacakKartlar[uretilenKartIndex] = ".";//Oyuncuya uygun kart verildikten sonra o kartın olduğu indise nokta koyarak tekrar verilmesini engelliyoruz
                }
                else
                    i = i - 1;//eğer kart verilmediyse döngümüzü dönmemiş gibi kodluyoruz bu sayede eksiksiz 6 kart verilmesini sağlıyoruz
            }           
            return oyuncu.ToString();
            
        }
    }
}
