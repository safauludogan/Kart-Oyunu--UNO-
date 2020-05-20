using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1030510124_SAFAULUDOGAN
{
    public class BilgisayarKartAt : IKart
    {
        private string _yerdekiKart, _oyuncu;
        private string[] _eldekiKartlar;
        string bilgisayarHangiKartiSecti;
        public BilgisayarKartAt(kartOzellikler yerdekiKart)
        {
            _yerdekiKart = yerdekiKart.kartYerdeki;
            _oyuncu = yerdekiKart.oyuncu;
            _eldekiKartlar = yerdekiKart.eldekiKartlar;
        }
        public string at()
        {
            if (_yerdekiKart == "00")
            {
                for (int i = 0; i < 5; i++)
                {
                    if (_eldekiKartlar[i] != "rd")
                    {
                        Console.Write(_oyuncu + " ");
                        Console.WriteLine(_eldekiKartlar[i]);
                        bilgisayarHangiKartiSecti = _eldekiKartlar[i];
                        _eldekiKartlar[i] = "..";
                        break;
                    }
                }
            }
            else if (_yerdekiKart.Substring(0, 1) == "s")
            {
                kartTara("s");
            }
            else if (_yerdekiKart.Substring(0, 1) == "k")
            {
                kartTara("k");
            }
            else if (_yerdekiKart.Substring(0, 1) == "m")
            {
                kartTara("m");
            }
            return _eldekiKartlar.ToString();
        }

        int rdKontrol = 0, rdIndex = 0,uygunKartVarmi=0;
        string kartTara(string kartRengi)
        {
           
            for (int i = 0; i < 6; i++)
            {
                if (_eldekiKartlar[i] == "rd")
                {
                    rdKontrol = 1;
                    rdIndex = i;
                }
                if (_eldekiKartlar[i].Substring(0, 1) == kartRengi || _eldekiKartlar[i].Substring(1, 1) == _yerdekiKart.Substring(1, 1))
                {
                    Console.Write(_oyuncu + " ");
                    Console.WriteLine(_eldekiKartlar[i]);
                    bilgisayarHangiKartiSecti = _eldekiKartlar[i];
                    _eldekiKartlar[i] = "..";
                    rdKontrol = 0;
                    uygunKartVarmi = 1;
                    break;
                }               
            }
            if (uygunKartVarmi == 0 && rdKontrol == 0)
            {
                bilgisayarHangiKartiSecti = _yerdekiKart;
                Console.WriteLine(_oyuncu + " PAS verdi kart - " + _yerdekiKart);
            }
            if (rdKontrol == 1 && uygunKartVarmi == 0)
            {
                _eldekiKartlar[rdIndex] = "..";
                for (int i = 0; i < 5; i++)
                {
                    if (_eldekiKartlar[i].Substring(0, 1) == "s")
                    {                        
                        bilgisayarHangiKartiSecti = "s" + (_yerdekiKart.Substring(1, 1)).ToString();
                        Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı "+bilgisayarHangiKartiSecti+" yaptı");
                        break;
                    }
                    else if (_eldekiKartlar[i].Substring(0, 1) == "k")
                    {                        
                        bilgisayarHangiKartiSecti = "k" + (_yerdekiKart.Substring(1, 1)).ToString();
                        Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı " + bilgisayarHangiKartiSecti + " yaptı");
                        break;
                    }
                    else if (_eldekiKartlar[i].Substring(0, 1) == "m")
                    {                        
                        bilgisayarHangiKartiSecti = "m" + (_yerdekiKart.Substring(1, 1)).ToString();
                        Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı " + bilgisayarHangiKartiSecti + " yaptı");
                        break;
                    }
                    else
                    {
                        Random rdIcinKartUret = new Random();
                        int rdIcinUretilenKart = rdIcinKartUret.Next(1,4);
                        if (rdIcinUretilenKart == 1)
                        {
                            bilgisayarHangiKartiSecti = "s" + (_yerdekiKart.Substring(1, 1)).ToString();
                            Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı " + bilgisayarHangiKartiSecti + " yaptı");
                        }
                        else if (rdIcinUretilenKart == 2)
                        {
                            bilgisayarHangiKartiSecti = "k" + (_yerdekiKart.Substring(1, 1)).ToString();
                            Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı " + bilgisayarHangiKartiSecti + " yaptı");
                        }
                        else
                        {
                            bilgisayarHangiKartiSecti = "m" + (_yerdekiKart.Substring(1, 1)).ToString();
                            Console.WriteLine(_oyuncu + " RD kartını kullanarak yeni kartı " + bilgisayarHangiKartiSecti + " yaptı");
                        }
                        break;
                    }
                }
            }            
            return _eldekiKartlar.ToString();
        }
        public string bilgisayarinSectigiKart()
        {
            return bilgisayarHangiKartiSecti;
        }
    }
}
