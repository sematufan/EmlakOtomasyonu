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
    public partial class cariEkleDüzenle : Form
    {
        carileriGoruntule tabloyuGuncelle;
        ContainerForm mdiIcin;
        evEkleDuzenle evSahibiYap;
        public int guncellenicekID = -1;
        string islemTuru;
        public cariEkleDüzenle(ContainerForm mdiIcin, evEkleDuzenle evSahibiYap, string islemTuru)
        {
            InitializeComponent();
            this.evSahibiYap = evSahibiYap;
            this.mdiIcin = mdiIcin;
            this.islemTuru = islemTuru;
        }
        public cariEkleDüzenle(ContainerForm mdiIcin)
        {
            InitializeComponent();
            this.mdiIcin = mdiIcin;
        }
        public cariEkleDüzenle(ContainerForm mdiIcin, carileriGoruntule tabloyuGuncelle)
        {
            InitializeComponent();
            this.tabloyuGuncelle = tabloyuGuncelle;
            this.mdiIcin = mdiIcin;
        }

        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();
        private void cariEkleDüzenle_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(30, 140);
            combo_cinsiyet.SelectedIndex = 0;
        }

        /// ////////////////////////////////////////////////////////////////////////////////////
        public void cariBilgileriniDoldur(int id)
        {
            guncellenicekID = id;

            lbl_guncellenenID.Visible = true;
            lbl_guncellenenID.Text = "Cari ID : " + guncellenicekID;

            cariler kayıtlıCari = new cariler();
            kayıtlıCari = ctx.cariler.SingleOrDefault(x => x.id == guncellenicekID);
            txt_Ad.Text = kayıtlıCari.ad;
            combo_cinsiyet.Text = kayıtlıCari.cinsiyet;
            numarik_yas.Value = ( int ) kayıtlıCari.yas;
            txt_tel1.Text = kayıtlıCari.tel1;
            txt_tel2.Text = kayıtlıCari.tel2;
            txt_adres.Text = kayıtlıCari.adres;
            txt_not.Text = kayıtlıCari.cariNotu;
            btn_kayit.Text = "Cariyi Güncelle";

            SattigiEvler();
            KiraladigiEvLER();
            KiralananEvler();
        }
        /// ////////////////////////////////////////////////////////////////////////////////////


        void SattigiEvler()
        {
            List<evler> sattigiEvler = ctx.evler.Where(x => x.emlakTipi == "Satılık" && x.evSahibiCariID == guncellenicekID).ToList();
            List<LinkLabel> linkler = new List<LinkLabel>();
            for (int i = 0; i < sattigiEvler.Count; i++)
                if (i == 0)
                {
                    link_satilikEv.Text = sattigiEvler[i].id.ToString();
                    linkler.Add(link_satilikEv);
                    link_satilikEv.Visible = true;
                }
                else
                {
                    LinkLabel yeniSatilicakEvLink = new LinkLabel();
                    yeniSatilicakEvLink.Text = sattigiEvler[i].id.ToString();
                    yeniSatilicakEvLink.AutoSize = true;
                    yeniSatilicakEvLink.Click += new System.EventHandler(this.link_satilikEv_Click);
                    this.Controls.Add(yeniSatilicakEvLink);
                    linkler.Add(yeniSatilicakEvLink);

                    Label virgül = new Label();
                    virgül.AutoSize = true;
                    this.Controls.Add(virgül);
                    virgül.Text = ",";
                    virgül.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width, 428);

                    yeniSatilicakEvLink.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width + 10, 428);
                }
        }
        void KiraladigiEvLER()
        {
            List<evler> sattigiEvler = ctx.evler.Where(x => x.emlakTipi == "Kiralık" && x.evSahibiCariID == guncellenicekID).ToList();
            List<LinkLabel> linkler = new List<LinkLabel>();
            for (int i = 0; i < sattigiEvler.Count; i++)
                if (i == 0)
                {
                    link_kiralikEv.Text = sattigiEvler[i].id.ToString();
                    linkler.Add(link_kiralikEv);
                    link_kiralikEv.Visible = true;
                }
                else
                {
                    LinkLabel yeniSatilicakEvLink = new LinkLabel();
                    yeniSatilicakEvLink.Text = sattigiEvler[i].id.ToString();
                    yeniSatilicakEvLink.AutoSize = true;
                    yeniSatilicakEvLink.Click += new System.EventHandler(this.link_satilikEv_Click);
                    this.Controls.Add(yeniSatilicakEvLink);
                    linkler.Add(yeniSatilicakEvLink);

                    Label virgül = new Label();
                    virgül.AutoSize = true;
                    this.Controls.Add(virgül);
                    virgül.Text = ",";
                    virgül.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width, 462);

                    yeniSatilicakEvLink.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width + 10, 462);
                }
        }
        void KiralananEvler()
        {
            List<evler> sattigiEvler = ctx.evler.Where(x => x.emlakTipi == "Kiralık" && x.eviKiralayanCariID == guncellenicekID).ToList();
            List<LinkLabel> linkler = new List<LinkLabel>();
            for (int i = 0; i < sattigiEvler.Count; i++)
                if (i == 0)
                {
                    link_kiralananEv.Text = sattigiEvler[i].id.ToString();
                    linkler.Add(link_kiralananEv);
                    link_kiralananEv.Visible = true;
                }
                else
                {
                    LinkLabel yeniSatilicakEvLink = new LinkLabel();
                    yeniSatilicakEvLink.Text = sattigiEvler[i].id.ToString();
                    yeniSatilicakEvLink.AutoSize = true;
                    yeniSatilicakEvLink.Click += new System.EventHandler(this.link_satilikEv_Click);
                    this.Controls.Add(yeniSatilicakEvLink);
                    linkler.Add(yeniSatilicakEvLink);

                    Label virgül = new Label();
                    virgül.AutoSize = true;
                    this.Controls.Add(virgül);
                    virgül.Text = ",";
                    virgül.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width, 496);

                    yeniSatilicakEvLink.Location = new System.Drawing.Point(linkler[linkler.Count - 2].Location.X + linkler[linkler.Count - 2].Size.Width + 10, 496);
                }
        }

        private void cariEkleDüzenle_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y < 110)
                this.Location = new System.Drawing.Point(Location.X, 110);
        }

        private void link_satilikEv_Click(object sender, EventArgs e)
        {
            evEkleDuzenle evDuzenle = new evEkleDuzenle(mdiIcin);
            evDuzenle.MdiParent = mdiIcin;
            evDuzenle.Show();
            evDuzenle.evBilgileriniDoldur(Convert.ToInt32((( LinkLabel ) sender).Text));
        }

        private void button1_Click(object sender, EventArgs e)//cari ekle
        {
            cariler yeniCari = new cariler();
            if (btn_kayit.Text == "Cari Ekle")
            {
                yeniCari.ad = txt_Ad.Text;
                yeniCari.adres = txt_adres.Text;
                yeniCari.cariNotu = txt_not.Text;
                yeniCari.cinsiyet = combo_cinsiyet.Text;
                yeniCari.tel1 = txt_tel1.Text;
                yeniCari.tel2 = txt_tel2.Text;
                yeniCari.yas = ( int ) numarik_yas.Value;
                ctx.cariler.Add(yeniCari);
                ctx.SaveChanges();
                if (evSahibiYap != null)
                {
                    if (islemTuru == "Kiracı")
                    {
                        evSahibiYap.link_eviKiralayan.Visible = true;
                        List<cariler> cariler2 = ctx.cariler.ToList();
                        evSahibiYap.link_eviKiralayan.Text = cariler2[cariler2.Count - 1] + "-" + cariler2[cariler2.Count - 1].ad;
                        evSahibiYap.btn_evKiraciDegistir.Visible = true;

                        evSahibiYap.combo_kisiler.Items.Add(cariler2[cariler2.Count - 1].id + "-" + cariler2[cariler2.Count - 1].ad);
                        evSahibiYap.combo_kisiler2.Items.Add(cariler2[cariler2.Count - 1].id + "-" + cariler2[cariler2.Count - 1].ad);
                        evSahibiYap.groupBox4.Visible = false;
                    }
                    else if (islemTuru == "evSahibi")
                    {
                        evSahibiYap.link_evSahibi.Visible = true;
                        List<cariler> cariler2 = ctx.cariler.ToList();
                        evSahibiYap.link_evSahibi.Text = cariler2[cariler2.Count - 1].id+"-"+ cariler2[cariler2.Count - 1].ad;
                        evSahibiYap.btn_evSahibiDegistir.Visible = true;

                        evSahibiYap.combo_kisiler.Items.Add(cariler2[cariler2.Count - 1].id + "-" + cariler2[cariler2.Count - 1].ad);
                        evSahibiYap.combo_kisiler2.Items.Add(cariler2[cariler2.Count - 1].id + "-" + cariler2[cariler2.Count - 1].ad);
                        evSahibiYap.groupBox3.Visible = false;
                    }

                }
                MessageBox.Show("Cari Kaydedildi.");
            }
            else
            {
                yeniCari = ctx.cariler.SingleOrDefault(x => x.id == guncellenicekID);
                yeniCari.ad = txt_Ad.Text;
                yeniCari.adres = txt_adres.Text;
                yeniCari.cariNotu = txt_not.Text;
                yeniCari.cinsiyet = combo_cinsiyet.Text;
                yeniCari.tel1 = txt_tel1.Text;
                yeniCari.tel2 = txt_tel2.Text;
                yeniCari.yas = ( int ) numarik_yas.Value;
                ctx.SaveChanges();
                MessageBox.Show("Cari Başarıyla Güncellendi.");

                if (tabloyuGuncelle != null)
                    tabloyuGuncelle.listeRefresh();
            }
            this.Close();
        }


    }
}
