using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotDefteri
{
    public partial class Form1 : Form
    {
        private string acilanDosya;
        private bool degisti;

        public Form1()
        {
            InitializeComponent();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtEditor.Text = "";
            acilanDosya = null;
            degisti = false;

        }

        private void koyuTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            koyuTemaToolStripMenuItem.Checked = true;
            açıkTemaToolStripMenuItem.Checked = false;
        }

        private void açıkTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            açıkTemaToolStripMenuItem.Checked = true;
            koyuTemaToolStripMenuItem.Checked = false;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Metin Dosyalar|*.txt|Tüm Dosyalar|*.*";

            DialogResult cevap = ofd.ShowDialog();

            if (cevap == DialogResult.OK)
            {
                txtEditor.LoadFile(ofd.FileName);
                acilanDosya = ofd.FileName;
                degisti = false;
            }
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fntDialog = new FontDialog();

            DialogResult cevap = fntDialog.ShowDialog();

            if (cevap == DialogResult.OK)
            {
                Font = fntDialog.Font;
            }
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            DialogResult cevap = dlg.ShowDialog();

            if (cevap == DialogResult.OK)
            {
                BackColor = dlg.Color;
            }
        }

        void Kaydet()
        {
            if (acilanDosya != null)
            {
                txtEditor.SaveFile(acilanDosya);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "Metin Dosyalarç|*.txt|Tüm Dosyalar|*.*";
                DialogResult cevap = sfd.ShowDialog();

                if (cevap == DialogResult.OK)
                {
                    txtEditor.SaveFile(sfd.FileName);
                }
            }

            degisti = false;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kaydet();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (degisti)
            {
                DialogResult cevap = MessageBox.Show("Yapılan değişiklikleri kayıt etmek ister misiniz?", "Uyarı",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    Kaydet();
                }
                else if (cevap == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            degisti = true;
        }

    }
}
