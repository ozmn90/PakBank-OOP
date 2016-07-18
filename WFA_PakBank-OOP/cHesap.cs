using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_PakBank_OOP
{
    class cHesap
    {
        private int _iD;
        private string _hesapNo;
        private string _tarih;
        private string _adi;
        private string _soyadi;
        private string _tCKNo;
        private double _bakiye;
        private string _islemTuru;


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

        public string Adi
        {
            get { return _adi; }
            set { _adi = value; }
        }
        public string Soyadi
        {
            get { return _soyadi; }
            set { _soyadi = value; }
        }

        public string TCKNo
        {
            get { return _tCKNo; }
            set { _tCKNo = value; }
        }

        public double Bakiye
        {
            get { return _bakiye; }
            set { _bakiye = value; }
        }

        public string IslemTuru
        {
            get { return _islemTuru; }
            set { _islemTuru = value; }
        }
        #endregion

        public int SonIDBul()
        {
            int ID = 1;
            StreamWriter DosyaAc = new StreamWriter("HesapKartlari.txt", true);
            DosyaAc.Close();

            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine();
            if (okunan == null)
                ID = 1;
            else
            {
                while (okunan != null)
                {
                    string[] Degerler = okunan.Split(';');
                    ID = (Convert.ToInt32(Degerler[0]) + 1);
                    okunan = DosyaOku.ReadLine();
                }
            } DosyaOku.Close();
            return ID;

        }
        Random rnd = new Random();
        public string HesapNumarasiOlustur()
        {
            string HesapNo = "";

            bool Varmi = false;
            do
            {
                HesapNo = "ACC" + rnd.Next(1000, 10000).ToString();
                Varmi = HesapVarmi(HesapNo); //HesapVarmi metodundan true döndüğü sürece tekrar hesapno ouşturulup baştamn kontrol edilmeye devam ediyor.
            } while (Varmi);
            return HesapNo;
        }
        private bool HesapVarmi(string HesapNo)
        {

            StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine();
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (HesapNo == Degerler[1]) //Eğer yeni hesapnoya sahip önceden tanımlı bir kayıt bulursa, dosyayı kapatıp, yeniden hesapolustur metodundaki döngüye true değeriyle dönüyor.
                {
                    DosyaOku.Close();
                    return true;
                    //HesapNumarasiOlustur(); recursive methods(kendini çalıştıran metotlar)
                }
                okunan = DosyaOku.ReadLine();
            }
            DosyaOku.Close();
            return false;



        }

        public bool HesapEkle(cHesap hsp)
        {
            StreamWriter DosyaAc = new StreamWriter("HesapKartlari.txt", true);
            DosyaAc.WriteLine(hsp._iD  + ";" + hsp._hesapNo + ";" + hsp._tarih + ";" + hsp._adi + ";" + hsp._soyadi + ";" + hsp._tCKNo + ";" + hsp._bakiye + ";" + hsp._islemTuru);
            DosyaAc.Close();
            return true;
        
        }

        public cHesap HesapBilgileriGoster(string HesapNo)
        {
            cHesap h = new cHesap();
           StreamReader DosyaOku = new StreamReader("HesapKartlari.txt");
            string okunan = DosyaOku.ReadLine();
            while (okunan != null)
            {
                string[] Degerler = okunan.Split(';');
                if (HesapNo == Degerler[1]) 
                {
                    h._adi = Degerler[3];
                    h._soyadi = Degerler[4];
                    h._tCKNo = Degerler[5];
                    h._islemTuru = Degerler[7];
                    h._tarih = Degerler[2];
                    break;
                }
                okunan = DosyaOku.ReadLine();
            }
            
            DosyaOku.Close();
            return h;
        }


    }
}
