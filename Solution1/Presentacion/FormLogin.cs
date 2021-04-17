using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }


        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text != "Usuario")
            {
                if (txtpass.Text != "Contraseña")
                {
                    lblErrorMessagge.Visible = false;
                    if (txtuser.Text.Equals("Ktomasm")&& txtpass.Text.Equals("admin"))
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;

                        this.Hide();
                    }
                    else
                    {
                        msgError("Revise sus credenciales.");
                        txtpass.Clear();
                        txtuser.Focus();
                    }
                }
                else msgError("Ingrese su contraseña.");
            }
            else msgError("Ingrese su nombre de usuario.");
        

    }
        private void msgError(string msg)
        {
            lblErrorMessagge.Text = "      " + msg;
            lblErrorMessagge.Visible = true;
        }

        private void Logout(object sender,FormClosedEventArgs e)
        {
            txtpass.Clear();
            txtuser.Clear();
            txtuser.Focus();
            lblErrorMessagge.Visible = false;
            this.Show();
        }

    }
}
