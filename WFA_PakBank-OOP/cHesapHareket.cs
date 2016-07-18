using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_PakBank_OOP
{
    class cHesapHareket
    {
        private int _iD;
        private string _hesapNo;
        private string _tarih;
        private double _tutar;
        private string _islemTipi;

        #region Properties

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public string HesapNo
        {
            get { return _hesapNo; }
            set { _hesapNo = value; }
        }

        public string Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }


        public double Tutar
        {
            get { return _tutar; }
            set { _tutar = value; }
        }

        public string IslemTipi
        {
            get { return _islemTipi; }
            set { _islemTipi = value; }
        }



        #endregion



        public bool HesapHareketEkle(cHesapHareket hh)
        {
            StreamWriter DosyaAc = new StreamWriter("HesapHareketleri.txt", true);
            DosyaAc.WriteLine(hh._iD + ";" + hh._hesapNo + ";" + hh._tarih + ";" + hh._tutar + ";" + hh._islemTipi);
            DosyaAc.Close();
            return true;

        }

        public void HesapHareketleriGoster(string HesapNo, ListView liste)
        {
            liste.Items.Clear();
            StreamReader DosyaOku = new StreamReader("HesapHareketleri.txt");
            string okunan = DosyaOku.ReadLine();
            int i = 0;
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (HesapNo == Degerler[1])
                {
                    liste.Items.Add(Degerler[0]);
                    liste.Items[i].SubItems.Add(Degerler[1]);
                    liste.Items[i].SubItems.Add(Degerler[2]);
                    liste.Items[i].SubItems.Add(Degerler[3]);
                    liste.Items[i].SubItems.Add(Degerler[4]);
                    i++;
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();


        }

    }
}
