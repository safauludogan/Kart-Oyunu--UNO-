using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1030510124_SAFAULUDOGAN
{
    public class kartSecimim
    {
        bool uygunKartYazildiMi = false;
        string kullaniciYazilanKart;
        string kartSecimDurum;
        private string _yerdekiKart;
        private int _turDurum;
        private string[] _eldekiKartlar;
        public kartSecimim(kartOzellikler kartOzellikler)
        {
            _yerdekiKart = kartOzellikler.kartYerdeki;
            _eldekiKartlar = kartOzellikler.eldekiKartlar;
            _turDurum = kartOzellikler.turDurum;
        }
        public string secimUygunlukKontrol()
        {
            while (uygunKartYazildiMi == false)
            {
                Console.Write("SEN : ");
                kullaniciYazilanKart = Console.ReadLine().ToLower().Trim();
                if (_yerdekiKart == "00" && (kullaniciYazilanKart == "pas" || kullaniciYazilanKart == "rd"))
                {
                    Console.WriteLine("İlk turdan pas veya rd kartlarını kullanamazsınız");
                }
                else if (_yerdekiKart == "00" && (kullaniciYazilanKart != "pas" && kullaniciYazilanKart != "rd"))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (_eldekiKartlar[i] == kullaniciYazilanKart)
                        {
                            kartSecimDurum = kullaniciYazilanKart;
                            _eldekiKartlar[i] = "..";
                            uygunKartYazildiMi = true;
                            break;
                        }
                    }
                }
                else if (_yerdekiKart != "00")
                {
                    if (kullaniciYazilanKart == "pas")
                    {
                        kartSecimDurum = _yerdekiKart;
                        break;
                    }
                    else if (kullaniciYazilanKart == "rd")
                    {
                        bool rdVarmi = false;
                        int rdIndex;
                        for (rdIndex = 0; rdIndex < 6; rdIndex++)
                        {
                            if (_eldekiKartlar[rdIndex] == "rd")
                            {
                                rdVarmi = true;
                                break;
                            }
                        }
                        if (rdVarmi == true)
                        {
                            while (true)
                            {
                                Console.Write("Renk belirleyiniz : ");
                                string yeniRenk = Console.ReadLine().ToLower().Trim();
                                if (yeniRenk == "m")
                                {
                                    kartSecimDurum = "m" + (_yerdekiKart.Substring(1, 1)).ToString();
                                    _eldekiKartlar[rdIndex] = "..";
                                    uygunKartYazildiMi = true;
                                    break;
                                }
                                else if (yeniRenk == "s")
                                {
                                    kartSecimDurum = "s" + (_yerdekiKart.Substring(1, 1)).ToString();
                                    _eldekiKartlar[rdIndex] = "..";
                                    uygunKartYazildiMi = true;
                                    break;
                                }
                                else if (yeniRenk == "k")
                                {                                 
                                    kartSecimDurum = "k" + (_yerdekiKart.Substring(1, 1)).ToString();
                                    _eldekiKartlar[rdIndex] = "..";
                                    uygunKartYazildiMi = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı renk girişi");
                                }
                            }
                        }
                    }
                    else
                    {
                        int i;
                        for (i = 0; i < 6; i++)
                        {
                            if (kullaniciYazilanKart == _eldekiKartlar[i])
                            {
                                if (kullaniciYazilanKart.Substring(0, 1) == _yerdekiKart.Substring(0, 1) || kullaniciYazilanKart.Substring(1, 1) == _yerdekiKart.Substring(1, 1))
                                {
                                    kartSecimDurum = kullaniciYazilanKart;
                                    _eldekiKartlar[i] = "..";
                                    uygunKartYazildiMi = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return _eldekiKartlar.ToString();
        }
        public string kartSecimSonucum()
        {
            return kartSecimDurum;
        }
    }
}
