using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510124_SAFAULUDOGAN
{
    class Program
    {
        static string yerinKartiBeraberlik = "BB";
        static int tur = 0;
        static bool kazananOlduMu = false;
        static string yerdekiKart = "00";
        static string[] oyuncu1 = new string[6];
        static string[] oyuncu2 = new string[6];
        static string[] oyuncu3 = new string[6];
        static void Main(string[] args)
        {

            KartDagit kartDagit = new KartDagit();
            kartDagit.dagit(oyuncu1);
            kartDagit.dagit(oyuncu2);
            kartDagit.dagit(oyuncu3);
            Random oyuncuSiralamasi = new Random();
            int oyuncuSiralama;
            oyuncuSiralama = oyuncuSiralamasi.Next(1, 4);
            if (oyuncuSiralama == 1)
            {
                Console.WriteLine("OYUNA SEN BAŞLIYORSUN.");
                Console.WriteLine();
                Console.WriteLine("1.Tur");
                Console.WriteLine("--------------------------------------");
            }
            else if (oyuncuSiralama == 2)
            {
                Console.WriteLine("2.OYUNCU OYUNA BAŞLIYOR.");
                Console.WriteLine();
                Console.WriteLine("1.Tur");
                Console.WriteLine("--------------------------------------");
            }
            else
            {
                Console.WriteLine("3.OYUNCU OYUNA BAŞLIYOR");
                Console.WriteLine();
                Console.WriteLine("1.Tur");
                Console.WriteLine("--------------------------------------");
            }
            while (kazananOlduMu == false)
            {
                tur++;
                if (oyuncuSiralama == 1)
                {
                    kullaniciKartSecim(tur);
                    kazananKontrol(oyuncu1, "SEN");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    oyuncu2Oyna();
                    kazananKontrol(oyuncu2, "2.OYUNCU");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    oyuncu3Oyna();
                    kazananKontrol(oyuncu3, "3.OYUNCU");
                    Console.WriteLine("--------------------------------------");
                }
                else if (oyuncuSiralama == 2)
                {
                    oyuncu2Oyna();
                    kazananKontrol(oyuncu2, "2.OYUNCU");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    oyuncu3Oyna();
                    kazananKontrol(oyuncu3, "3.OYUNCU");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    kullaniciKartSecim(tur);
                    kazananKontrol(oyuncu1, "SEN");
                    Console.WriteLine("--------------------------------------");
                }
                else if (oyuncuSiralama == 3)
                {
                    oyuncu3Oyna();
                    kazananKontrol(oyuncu3, "3.OYUNCU");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    kullaniciKartSecim(tur);
                    kazananKontrol(oyuncu1, "SEN");
                    if (kazananOlduMu == true)
                    {
                        break;
                    }
                    oyuncu2Oyna();
                    kazananKontrol(oyuncu2, "2.OYUNCU");
                    Console.WriteLine("--------------------------------------");
                }
                if (kazananOlduMu == false)
                {
                    Console.WriteLine();
                    Console.WriteLine((tur + 2) + ".Tur");
                    Console.WriteLine("--------------------------------------");
                }

            }
            Console.WriteLine("Oyuncuların Kalan Kartları");
            Console.WriteLine();
            Console.Write("Oyuncu 1 --> ");
            foreach (var item in oyuncu1)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.Write("Oyuncu 2 --> ");
            foreach (var item in oyuncu2)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.Write("Oyuncu 3 --> ");
            foreach (var item in oyuncu3)
            {
                Console.Write(item);
            }

            Console.ReadLine();
        }

        public static void beraberKontrol()
        {
            int beraberlikIcinTurSayisi = 0;
            if (yerinKartiBeraberlik == yerdekiKart)
            {
                beraberlikIcinTurSayisi++;
                if (beraberlikIcinTurSayisi >= 3)
                {
                    kazananOlduMu = true;
                    Console.WriteLine("Kazanan olmadı oyun berabere 3 tur boyunca aynı kart yerde durdu");
                }
            }
            else
            {
                yerinKartiBeraberlik = yerdekiKart;
            }
        }

        public static void kazananKontrol(string[] kartlar, string oyuncu)
        {
            KazananOyuncuBelirle kazananOyuncuBelirle = new KazananOyuncuBelirle(new kartOzellikler { eldekiKartlar = kartlar, oyuncu = oyuncu });
            kazananOlduMu = kazananOyuncuBelirle.eliKontrolEt();
        }
        public static void kullaniciKartSecim(int turDurum)
        {
            foreach (var kartlar in oyuncu1)
            {
                Console.Write(kartlar + " ");
            }
            Console.Write("--> ");
            kartSecimim kartSecimim = new kartSecimim(new kartOzellikler
            {
                kartYerdeki = yerdekiKart,
                eldekiKartlar = oyuncu1,
                turDurum = turDurum
            });
            kartSecimim.secimUygunlukKontrol();
            yerdekiKart = kartSecimim.kartSecimSonucum();
            beraberKontrol();
        }
        public static void oyuncu2Oyna()
        {
            IKart kart = new BilgisayarKartAt(
                       new kartOzellikler
                       {
                           kartYerdeki = yerdekiKart,
                           oyuncu = "2.OYUNCU",
                           eldekiKartlar = oyuncu2
                       });
            kart.at();
            yerdekiKart = kart.bilgisayarinSectigiKart();
            beraberKontrol();
        }
        public static void oyuncu3Oyna()
        {
            IKart kart = new BilgisayarKartAt(
                        new kartOzellikler
                        {
                            kartYerdeki = yerdekiKart,
                            oyuncu = "3.OYUNCU",
                            eldekiKartlar = oyuncu3
                        });
            kart.at();
            yerdekiKart = kart.bilgisayarinSectigiKart();
            beraberKontrol();
        }
    }
}
