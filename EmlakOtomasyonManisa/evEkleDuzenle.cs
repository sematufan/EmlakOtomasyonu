﻿using System;
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
    public partial class evEkleDuzenle : Form
    {
        EvleriGoruntule tabloGuncellemekIcın;
        ContainerForm mdiIcin;
        public int guncellenicekID = -1;
        public evEkleDuzenle(EvleriGoruntule tabloGuncellemekIcın)
        {
            InitializeComponent();
            this.tabloGuncellemekIcın = tabloGuncellemekIcın;
        }
        public evEkleDuzenle(ContainerForm mdiIcin)
        {
            InitializeComponent();
            this.mdiIcin = mdiIcin;
        }
        public evEkleDuzenle(ContainerForm mdiIcin, EvleriGoruntule tabloGuncellemekIcın)
        {
            InitializeComponent();
            this.mdiIcin = mdiIcin;
            this.tabloGuncellemekIcın = tabloGuncellemekIcın;
        }
        List<cariler> cariListesi;
        private void evEkleDuzenle_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width-500, 110);
            combo_emlakTipi.SelectedIndex = 0;
            combo_odaSayisi1.SelectedIndex = 0;
            combo_odaSayisi2.SelectedIndex = 0;
            combo_isitma.SelectedIndex = 0;
            combo_Esyali.SelectedIndex = 0;
            combo_SitedeMi.SelectedIndex = 0;
            combolaraCarileriGetir(ctx.cariler.ToList());
        }

        /// ////////////////////////////////////////////////////////////////////////////////////
        public void evBilgileriniDoldur(int id)
        {
            guncellenicekID = id;

            lbl_guncellenenID.Visible = true;
            lbl_guncellenenID.Text = "Ev ID : " + guncellenicekID;

            ctx = new EntityEmlakOtomasyonManisa();
            evler duzenlenicekEvVeriler = ctx.evler.SingleOrDefault(x => x.id == id);
            if (duzenlenicekEvVeriler.emlakTipi=="Satılık")
            {
                btn_kaydet.Location = new System.Drawing.Point(12, 527);
                this.ClientSize = new System.Drawing.Size(455, 578);
            }
            else if (duzenlenicekEvVeriler.emlakTipi == "Kiralık")
            {
                btn_kaydet.Location = new System.Drawing.Point(12, 574);
                this.ClientSize = new System.Drawing.Size(455, 625);
            }
            combo_emlakTipi.Text = duzenlenicekEvVeriler.emlakTipi;
            string[] odaSayisiGecici = duzenlenicekEvVeriler.odaSayisi.Split('+');
            combo_odaSayisi1.Text = odaSayisiGecici[0];
            combo_odaSayisi2.Text = odaSayisiGecici[1];
            numaric_BanyoSayisi.Value = ( int ) duzenlenicekEvVeriler.banyoSayisi;
            numaric_Alan.Value = ( int ) duzenlenicekEvVeriler.alan;
            numaric_DaireKatSayisi.Value = ( int ) duzenlenicekEvVeriler.daireKacKatli;
            numaric_Fiyat.Value = ( int ) duzenlenicekEvVeriler.fiyat;
            numaric_BinaYasi.Value = ( int ) duzenlenicekEvVeriler.binaYasi;
            numaric_BinaKatSayisi.Value = ( int ) duzenlenicekEvVeriler.binaKatSayisi;
            numaric_BulunduguKat.Value = ( int ) duzenlenicekEvVeriler.bulunduguKat;
            combo_SitedeMi.Text = duzenlenicekEvVeriler.siteIcerisinde;
            numaric_Aidat.Value = ( int ) duzenlenicekEvVeriler.aidat;
            combo_Esyali.Text = duzenlenicekEvVeriler.esyalı;
            combo_isitma.Text = duzenlenicekEvVeriler.isitma;
            txt_ilanLinki.Text = duzenlenicekEvVeriler.ilanLinki;
            txt_evAdresi.Text = duzenlenicekEvVeriler.adres;
            txt_daireNotu.Text = duzenlenicekEvVeriler.daireNotu;

            if (duzenlenicekEvVeriler.evSahibiCariID != null)
            {
                link_evSahibi.Visible = true;
                groupBox3.Visible = false;
                link_evSahibi.Text = duzenlenicekEvVeriler.evSahibiCariID+"-"+duzenlenicekEvVeriler.cariler.ad;
                btn_evSahibiDegistir.Visible = true;
            }
            btn_kaydet.Text = "Evi Güncelle";
        }
        /// ////////////////////////////////////////////////////////////////////////////////////


        private void evEkleDuzenle_LocationChanged(object sender, EventArgs e)
        {
            if (this.Location.Y < 110)
            {
                this.Location = new System.Drawing.Point(Location.X, 110);
            }
        }
        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();
        private void button1_Click(object sender, EventArgs e)
        {
            if (btn_kaydet.Text == "Yeni Evi Kaydet")
            {
                evler yeniEv = new evler();
                yeniEv.emlakTipi = combo_emlakTipi.Text;
                yeniEv.alan = ( int ) numaric_Alan.Value;
                yeniEv.odaSayisi = combo_odaSayisi1.Text + "+" + combo_odaSayisi2.Text;
                yeniEv.binaYasi = ( int ) numaric_BinaYasi.Value;
                yeniEv.binaKatSayisi = ( int ) numaric_BinaKatSayisi.Value;
                yeniEv.bulunduguKat = ( int ) numaric_BulunduguKat.Value;
                yeniEv.daireKacKatli = ( int ) numaric_DaireKatSayisi.Value;
                yeniEv.isitma = combo_isitma.Text;
                yeniEv.banyoSayisi = ( int ) numaric_BanyoSayisi.Value;
                yeniEv.esyalı = combo_Esyali.Text;
                yeniEv.siteIcerisinde = combo_SitedeMi.Text;
                yeniEv.aidat = ( int ) numaric_Aidat.Value;
                yeniEv.fiyat = ( int ) numaric_Fiyat.Value;
                yeniEv.ilanLinki = txt_ilanLinki.Text;
                yeniEv.adres = txt_evAdresi.Text;
                yeniEv.daireNotu = txt_daireNotu.Text;

                if (link_eviKiralayan.Visible == true)
                    yeniEv.eviKiralayanCariID = Convert.ToInt32(link_eviKiralayan.Text);
                else
                    yeniEv.eviKiralayanCariID = null;

                if (link_evSahibi.Visible == true)
                {
                    yeniEv.evSahibiCariID = Convert.ToInt32(link_evSahibi.Text);
                    ctx.evler.Add(yeniEv);
                    ctx.SaveChanges();
                    MessageBox.Show("Kayıt Başarılı.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Önce Ev Sahinini Seçiniz Lütfen");
                }
            }
            else
            {
                evler yeniEv = ctx.evler.SingleOrDefault(x => x.id == guncellenicekID);
                yeniEv.emlakTipi = combo_emlakTipi.Text;
                yeniEv.alan = ( int ) numaric_Alan.Value;
                yeniEv.odaSayisi = combo_odaSayisi1.Text + "+" + combo_odaSayisi2.Text;
                yeniEv.binaYasi = ( int ) numaric_BinaYasi.Value;
                yeniEv.binaKatSayisi = ( int ) numaric_BinaKatSayisi.Value;
                yeniEv.bulunduguKat = ( int ) numaric_BulunduguKat.Value;
                yeniEv.daireKacKatli = ( int ) numaric_DaireKatSayisi.Value;
                yeniEv.isitma = combo_isitma.Text;
                yeniEv.banyoSayisi = ( int ) numaric_BanyoSayisi.Value;
                yeniEv.esyalı = combo_Esyali.Text;
                yeniEv.siteIcerisinde = combo_SitedeMi.Text;
                yeniEv.aidat = ( int ) numaric_Aidat.Value;
                yeniEv.fiyat = ( int ) numaric_Fiyat.Value;
                yeniEv.ilanLinki = txt_ilanLinki.Text;
                yeniEv.adres = txt_evAdresi.Text;
                yeniEv.daireNotu = txt_daireNotu.Text;

                if (link_eviKiralayan.Visible == true)
                    yeniEv.eviKiralayanCariID = Convert.ToInt32(link_eviKiralayan.Text);
                else
                    yeniEv.eviKiralayanCariID = null;

                if (link_evSahibi.Visible == true)
                {
                    yeniEv.evSahibiCariID = Convert.ToInt32(link_evSahibi.Text);
                    ctx.SaveChanges();
                    if (tabloGuncellemekIcın != null)
                        tabloGuncellemekIcın.listeRefresh(combo_emlakTipi.Text);
                    MessageBox.Show("Güncelleme Başarılı.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Önce Ev Sahinini Seçiniz Lütfen");
                }
            }
        }

        private void btn_cariyiAta_Click(object sender, EventArgs e)
        {
            if (combo_kisiler.Items.Count > 0)
            {
                string[] IDcek = combo_kisiler.Text.Split('-');
                int id = Convert.ToInt32(IDcek[0]);
                link_evSahibi.Visible = true;
                groupBox3.Visible = false;
                link_evSahibi.Text = id.ToString();
                btn_evSahibiDegistir.Visible = true;
            }
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            cariEkleDüzenle cariform = new cariEkleDüzenle(mdiIcin);
            cariform.MdiParent = mdiIcin;
            cariform.Show();
            string[] IDcekmekIcin = link_evSahibi.Text.Split('-');
            cariform.cariBilgileriniDoldur(Convert.ToInt32(IDcekmekIcin[0]));
        }

        private void btn_evSahibiDegistir_Click(object sender, EventArgs e)
        {
            link_evSahibi.Visible = false;
            groupBox3.Visible = true;
            link_evSahibi.Text = "";
            btn_evSahibiDegistir.Visible = false;
        }

        private void btn_yeniCariEkle_Click(object sender, EventArgs e)
        {
            cariEkleDüzenle yeniCari = new cariEkleDüzenle(mdiIcin, this,"evSahibi");
            yeniCari.MdiParent = mdiIcin;
            yeniCari.Show();
        }

        private void combo_emlakTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_emlakTipi.Text == "Kiralık")
            {
                btn_kaydet.Location = new System.Drawing.Point(12, 574);
                this.ClientSize = new System.Drawing.Size(455, 625);
                if (guncellenicekID != -1)
                {
                    evler ev = ctx.evler.SingleOrDefault(x => x.id == guncellenicekID);
                    if (ev.eviKiralayanCariID != null)
                    {
                        link_eviKiralayan.Text = ev.eviKiralayanCariID+"-"+ev.cariler1.ad;
                        lbl_kirayaVer.Visible = true;
                        link_eviKiralayan.Visible = true;
                        btn_evKiraciDegistir.Visible = true;
                        groupBox4.Visible = false;
                    }
                    else
                    {
                        link_eviKiralayan.Visible = false;
                        btn_evKiraciDegistir.Visible = false;
                        lbl_kirayaVer.Visible = true;
                        groupBox4.Visible = true;
                    }
                }
                else
                {
                    link_eviKiralayan.Visible = false;
                    btn_evKiraciDegistir.Visible = false;
                    lbl_kirayaVer.Visible = true;
                    groupBox4.Visible = true;
                }
            }
            else if (combo_emlakTipi.Text == "Satılık")
            {
                btn_kaydet.Location = new System.Drawing.Point(12, 527);
                this.ClientSize = new System.Drawing.Size(455, 578);
                lbl_kirayaVer.Visible = false;
                groupBox4.Visible = false;
                link_eviKiralayan.Visible = false;
                btn_evKiraciDegistir.Visible = false;
            }
        }
        public void combolaraCarileriGetir(List<cariler> cariListesi)
        {
            this.cariListesi = cariListesi;
            for (int i = 0; i < cariListesi.Count; i++)
            {
                combo_kisiler.Items.Add(cariListesi[i].id + "-" + cariListesi[i].ad);
                combo_kisiler2.Items.Add(cariListesi[i].id + "-" + cariListesi[i].ad);
            }
            if (combo_kisiler.Items.Count > 0)
                combo_kisiler.SelectedIndex = 0;
            if (combo_kisiler2.Items.Count > 0)
                combo_kisiler2.SelectedIndex = 0;
        }

        private void btn_cariyiAta2_Click(object sender, EventArgs e)
        {
            if (combo_kisiler2.Items.Count > 0)
            {
                string[] IDcek = combo_kisiler2.Text.Split('-');
                int id = Convert.ToInt32(IDcek[0]);
                link_eviKiralayan.Visible = true;
                groupBox4.Visible = false;
                link_eviKiralayan.Text = id.ToString();
                btn_evKiraciDegistir.Visible = true;
            }
        }

        private void btn_evKiraciDegistir_Click(object sender, EventArgs e)
        {
            link_eviKiralayan.Visible = false;
            groupBox4.Visible = true;
            link_eviKiralayan.Text = "";
            btn_evKiraciDegistir.Visible = false;
        }

        private void link_eviKiralayan_Click(object sender, EventArgs e)
        {
            cariEkleDüzenle cariform = new cariEkleDüzenle(mdiIcin);
            cariform.MdiParent = mdiIcin;
            cariform.Show();
            string[] IDcek = link_eviKiralayan.Text.Split('-');
            cariform.cariBilgileriniDoldur(Convert.ToInt32(IDcek[0]));
        }

        private void btn_yeniCariEkle2_Click(object sender, EventArgs e)
        {
            cariEkleDüzenle yeniCari = new cariEkleDüzenle(mdiIcin, this, "Kiracı");
            yeniCari.MdiParent = mdiIcin;
            yeniCari.Show();
        }
    }
}
