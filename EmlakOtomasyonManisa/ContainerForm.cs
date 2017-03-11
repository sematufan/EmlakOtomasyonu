using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmlakOtomasyonManisa
{
    public partial class ContainerForm : Form
    {
        public ContainerForm()
        {
            InitializeComponent();
        }
        ///yuşaaaaaaaaa
        ///öjhvljhvlhjv
        /////jkblkj bkjçl
        //jnlkjnblkj

        private void ContainerForm_Load(object sender, EventArgs e)
        {
            List<users> ilkFormAcilisYavasOlmasınDiye = ctx.users.ToList();
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            groupBox1.Width = Width;
        }

        private void ContainerForm_SizeChanged(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            groupBox1.Width = Width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            evlerMenuStrip.Show(Location.X + 80, Location.Y + 130);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carilerMenuStrip.Show(Location.X + 227, Location.Y + 130);
        }

        private void yeniCariEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cariEkleDüzenle yenicari = new cariEkleDüzenle(this);
            yenicari.MdiParent = this;
            yenicari.Show();
        }

        private void ContainerForm_LocationChanged(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.Location = new System.Drawing.Point(-5, -5);
        }
        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();
        private void carileriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carileriGoruntule cg = new carileriGoruntule(this);
            cg.MdiParent = this;
            cg.Show();
        }

        private void yeniEvEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evEkleDuzenle cg = new evEkleDuzenle(this);
            cg.MdiParent = this;
            cg.Show();
        }

        private void satılıkEvlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvleriGoruntule cg = new EvleriGoruntule(this, "Satılık");
            cg.MdiParent = this;
            cg.Text = "Satılık Evler";
            cg.Show();
        }

        private void kiralıkEvlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvleriGoruntule cg = new EvleriGoruntule(this, "Kiralık");
            cg.MdiParent = this;
            cg.Text = "Kiralık Evler";
            cg.Show();
        }

        void rastageleDoldur()
        {
            Random rnd = new Random();

            evler yeniEv = new evler();
            yeniEv.emlakTipi = "Kiralık";
            yeniEv.alan = rnd.Next(40, 240);
            yeniEv.odaSayisi = rnd.Next(1, 6) + "+" + rnd.Next(1, 3);
            yeniEv.binaYasi = rnd.Next(1, 25);
            yeniEv.binaKatSayisi = rnd.Next(5, 16);
            yeniEv.bulunduguKat = rnd.Next(1, 6);
            yeniEv.daireKacKatli = rnd.Next(1, 4);
            yeniEv.isitma = "Doğalgaz";
            yeniEv.banyoSayisi = rnd.Next(1, 3);
            yeniEv.esyalı = "Hayır";
            yeniEv.siteIcerisinde = "Evet";
            yeniEv.aidat = rnd.Next(0, 151);
            yeniEv.fiyat = rnd.Next(400, 999);
            yeniEv.ilanLinki = "";
            yeniEv.adres = "";
            yeniEv.daireNotu = "";
            yeniEv.evSahibiCariID = rnd.Next(1, 21);

            ctx.evler.Add(yeniEv);
            ctx.SaveChanges();
        }
    }
}
