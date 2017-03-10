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
    public partial class EvleriGoruntule : Form
    {
        ContainerForm mdiIcın;
        string emlakTuru;
        public EvleriGoruntule(ContainerForm mdiIcın, string emlakTuru)
        {
            InitializeComponent();
            this.mdiIcın = mdiIcın;
            this.emlakTuru = emlakTuru;
        }
        private void satilikEvleriGoruntule_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y < 110)
                this.Location = new System.Drawing.Point(Location.X, 110);
        }

        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();

        private void satilikEvleriGoruntule_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(5, 110);
            listeRefresh(emlakTuru);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                evEkleDuzenle evDuzenle = new evEkleDuzenle(mdiIcın, this);
                evDuzenle.MdiParent = mdiIcın;
                evDuzenle.Show();
                evDuzenle.evBilgileriniDoldur(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
            }
        }

        public void listeRefresh(string emlakTipi)
        {
            this.Text = emlakTipi + " Evler";
            listView1.Items.Clear();
            ctx = new EntityEmlakOtomasyonManisa();
            List<evler> satilikEvler = ctx.evler.Where(x => x.emlakTipi == emlakTipi).ToList();
            for (int i = 0; i < satilikEvler.Count; i++)
            {
                string[] dizi = { satilikEvler[i].id.ToString(), satilikEvler[i].cariler.ad, satilikEvler[i].odaSayisi, satilikEvler[i].alan.ToString(), satilikEvler[i].isitma, satilikEvler[i].fiyat.ToString(), satilikEvler[i].aidat.ToString(), satilikEvler[i].daireNotu, satilikEvler[i].adres };
                ListViewItem eklencekSatir = new ListViewItem(dizi);
                listView1.Items.Add(eklencekSatir);
            }
        }

        void detayliAramaAc()
        {
            btn_detayliAramaAcKapa.Text = "^^^   DETAYLI ARAMAYI KAPAT   ^^^";
            groupBox1.Visible = true;
        }
        void detayliAramaKapa()
        {
            btn_detayliAramaAcKapa.Text = "vvv   DETAYLI ARAMAYI AÇ   vvv";
            groupBox1.Visible = false;
        }
    }
}
