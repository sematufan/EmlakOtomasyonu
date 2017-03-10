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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }


        EntityEmlakOtomasyonManisa ctx = new EntityEmlakOtomasyonManisa();
        users girisKontrol = new users();
        private void login_Load(object sender, EventArgs e)
        {
            girisKontrol = ctx.users.SingleOrDefault(x => x.userName == txt_name.Text && x.password == txt_pass.Text);
        }
        private void lbl_name_Enter(object sender, EventArgs e)
        {
            if (txt_name.Text == "Kullanıcı Adı")
            {
                txt_name.Text = "";
                txt_name.ForeColor = Color.Black;
            }
        }

        private void lbl_name_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_name.Text))
            {
                txt_name.ForeColor = Color.Gray;
                txt_name.Text = "Kullanıcı Adı";
            }
        }

        private void txt_pass_Enter(object sender, EventArgs e)
        {
            if (txt_pass.Text == "Şifre")
            {
                txt_pass.PasswordChar = '*';
                txt_pass.Text = "";
                txt_pass.ForeColor = Color.Black;
            }
        }

        private void txt_pass_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_pass.Text))
            {
                txt_pass.PasswordChar = '\0';
                txt_pass.ForeColor = Color.Gray;
                txt_pass.Text = "Şifre";
            }
        }

        private void lbl_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_login.PerformClick();
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    
        private void btn_login_Click(object sender, EventArgs e)
        {
            girisKontrol = ctx.users.SingleOrDefault(x=>x.userName==txt_name.Text && x.password==txt_pass.Text);
            if (girisKontrol!=null)
            {
                girisYapildimi = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve/ya Şifre Hatalı.");
            }
        }
        bool girisYapildimi = false;
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!girisYapildimi)
            {
                Application.Exit();
            }
        }
    }
}
