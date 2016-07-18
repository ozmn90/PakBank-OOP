using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_PakBank_OOP
{
    public partial class frmHesapDokumu : Form
    {
        public frmHesapDokumu()
        {
            InitializeComponent();
        }

        public static string HesapID; //static olarak tanımlanan değişkenler, class'ın new ile örneği (instance) oluşturulmadan çağrılabilir.
        public static string HesapNo;

        private void frmHesapDokumu_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

        }

        public void btnBul_Click(object sender, EventArgs e)
        {
            if (txtHesapNo.Text.Trim() != "")
            {
                cHesap hsp = new cHesap();
                hsp = hsp.HesapBilgileriGoster(txtHesapNo.Text);
                txtAdi.Text = hsp.Adi;
                txtSoyadi.Text = hsp.Soyadi;
                txtTCKNo.Text = hsp.TCKNo;
                txtHesapTuru.Text = hsp.IslemTuru;
                txtTarih.Text = hsp.Tarih;
                cHesapHareket hh = new cHesapHareket();
                hh.HesapHareketleriGoster(txtHesapNo.Text, lvHareketler);
                ToplamlariGoster();


            }
        }

        private void ToplamlariGoster()
        {
            double TopYatan = 0;
            double TopCekilen = 0;
            for (int i = 0; i < lvHareketler.Items.Count; i++)
            {
                if (lvHareketler.Items[i].SubItems[4].Text == "yatan")
                    TopYatan += Convert.ToDouble(lvHareketler.Items[i].SubItems[3].Text);
                else
                    TopCekilen += Convert.ToDouble(lvHareketler.Items[i].SubItems[3].Text);
            }
            txtToplamYatan.Text = TopYatan.ToString();
            txtToplamCekilen.Text = TopCekilen.ToString();
            txtBakiye.Text = (TopYatan - TopCekilen).ToString();
        }

        private void btnParaIslemleri_Click(object sender, EventArgs e)
        {
            HesapID = lvHareketler.Items[0].SubItems[0].Text;
            HesapNo = txtHesapNo.Text;
            frmParaIslemleri frm = new frmParaIslemleri();
            
            frm.ShowDialog();

            cHesapHareket hh = new cHesapHareket();
            hh.HesapHareketleriGoster(txtHesapNo.Text, lvHareketler);
            ToplamlariGoster();
        }


    }
}
