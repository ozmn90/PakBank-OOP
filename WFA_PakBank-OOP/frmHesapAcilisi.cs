using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_PakBank_OOP
{
    public partial class frmHesapAcilisi : Form
    {
        public frmHesapAcilisi()
        {
            InitializeComponent();
        }

        private void frmHesapAcilisi_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            cHesap hsp = new cHesap();
            lblHesapID.Text = hsp.SonIDBul().ToString();
            lblHesapNo.Text = hsp.HesapNumarasiOlustur();
            lblTarih.Text = DateTime.Now.ToShortDateString();
            

        }

        private void btnHesapAc_Click(object sender, EventArgs e)
        {

            if (txtAdi.Text.Trim() != "" && txtSoyadi.Text.Trim() != "" && txtTCKNo.Text.Trim() != "" && txtBakiye.Text.Trim() != "")
            {
                cHesap hsp = new cHesap();
                hsp.ID = Convert.ToInt32(lblHesapID.Text);
                hsp.HesapNo = lblHesapNo.Text;
                hsp.Tarih = lblTarih.Text;
                hsp.Adi = txtAdi.Text;
                hsp.Soyadi = txtSoyadi.Text;
                hsp.TCKNo = txtTCKNo.Text;
                hsp.Bakiye = Convert.ToDouble(txtBakiye.Text);
                hsp.IslemTuru = cbHesapTurleri.SelectedItem.ToString();
                cbHesapTurleri.SelectedIndex = 0;

                //bool sonuc = hsp.HesapEkle(Convert.ToInt32(lblHesapID.Text), lblHesapNo.Text, lblTarih.Text, txtAdi, txtSoyadi, txtTCKNo, txtBakiye, cbHesapTurleri.SelectedItem.ToString());
                bool sonuc = hsp.HesapEkle(hsp);

                if (sonuc == true)
                {
                    cHesapHareket hh = new cHesapHareket();
                    hh.ID = hsp.ID;
                    hh.HesapNo = hsp.HesapNo;
                    hh.Tarih = hsp.Tarih;
                    hh.Tutar = hsp.Bakiye;
                    hh.IslemTipi = "yatan";
                    //sonuc = hh.HesapHareketEkle(Convert.ToInt32(lblHesapID.Text), lblHesapNo.Text, lblTarih.Text, txtBakiye, "yatan");
                    sonuc = hh.HesapHareketEkle(hh);
                    if (sonuc)
                    {
                        MessageBox.Show("Yeni Hesap bilgileri olusturuldu . ");
                        temizle();
                        lblHesapID.Text = hsp.SonIDBul().ToString();
                        lblHesapNo.Text = hsp.HesapNumarasiOlustur();
                    }
                    else
                    {
                        MessageBox.Show("Hesap Hareketleri Kayıt Edilemedi");
                    }

                }
                else
                {
                    MessageBox.Show("Hesap Bilgileri Kayıt Edilemedi !! ");
                }

            }
            
        }

        private void temizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtTCKNo.Clear();
            txtBakiye.Clear();
        }


    }
}
