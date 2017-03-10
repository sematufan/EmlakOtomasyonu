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
    public partial class carileriGoruntule : Form
    {
        ContainerForm mdiIcın;
        public carileriGoruntule(ContainerForm deneme)
        {
            InitializeComponent();
            mdiIcın = deneme;
        }
        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();
        List<cariler> cariKayitlar = new List<cariler>();

        private void carileriGoruntule_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(5, 110);
            listeRefresh();
        }

        private void carileriGoruntule_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y < 110)
                this.Location = new System.Drawing.Point(Location.X, 110);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                cariEkleDüzenle cariform = new cariEkleDüzenle(mdiIcın, this);
                cariform.MdiParent = mdiIcın;
                cariform.Show();
                cariform.cariBilgileriniDoldur(Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
            }
        }
        public void listeRefresh()
        {
            listView1.Items.Clear();
            List<cariler> cariKayitlar = ctx.cariler.ToList();
            for (int i = 0; i < cariKayitlar.Count; i++)
            {
                string[] dizi = { cariKayitlar[i].id.ToString(), cariKayitlar[i].ad, cariKayitlar[i].yas.ToString(), cariKayitlar[i].tel1, cariKayitlar[i].tel2, cariKayitlar[i].cariNotu };
                ListViewItem eklencekSatir = new ListViewItem(dizi);
                listView1.Items.Add(eklencekSatir);
            }
        }
    }
}
