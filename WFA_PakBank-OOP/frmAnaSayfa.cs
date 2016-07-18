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
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {
           

        }

        private void mitmYeniHesapAc_Click(object sender, EventArgs e)
        {
            frmHesapAcilisi frm = new frmHesapAcilisi();
            FormAcikMi(frm);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void mitmHesapDokumu_Click(object sender, EventArgs e)
        {
            frmHesapDokumu frm = new frmHesapDokumu();
            FormAcikMi(frm);
            //frm.MdiParent = this;
            //frm.Show();
        }

        private void FormAcikMi(Form AcilacakForm)
        {
            bool AcikMi = false;
            
            for (int i = 0; i < this.MdiChildren.Count() ; i++)
            {
                if (AcilacakForm.Name == this.MdiChildren[i].Name)
                {
                    this.MdiChildren[i].Focus();
                    AcikMi = true;
                }
               
            }
            if (AcikMi == false )
            {
                AcilacakForm.MdiParent = this;
                AcilacakForm.Show();
            }
            else   {AcilacakForm.Dispose();}


        }


        private void mitmCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

      




    }
}
