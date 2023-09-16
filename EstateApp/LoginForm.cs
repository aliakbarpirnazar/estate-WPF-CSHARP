using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace EstateApp
{
    public partial class LoginForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
          (
              int nLeftRect,     // x-coordinate of upper-left corner
              int nTopRect,      // y-coordinate of upper-left corner
              int nRightRect,    // x-coordinate of lower-right corner
              int nBottomRect,   // y-coordinate of lower-right corner
              int nWidthEllipse, // width of ellipse
              int nHeightEllipse // height of ellipse
          );
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        // کد انقال فرم
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        void Move()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //
        UserBLL Ubll = new UserBLL();
        bool _IsRegistered;
        MsgBox msg = new MsgBox();
        User u = new User();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            u = Ubll.Login(textBoxX1.Text, textBoxX2.Text);
            if (u != null)
            {
                this.Hide();
                Manager manager = new Manager();
                manager.LoggedInUser = u;
                manager.Show();
            }
            else
            {
                msg.MyShowDialog("اخطار","نام کاربری یا کلمه عبور اشتباه است!!","",false,true);
            }








            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Information Information = new Information();
            Information.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            pictureBox11_Click(sender, e);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            _IsRegistered = Ubll.IsRegistered();
            if (!_IsRegistered)
            {
                RegisterForm registerForm = new RegisterForm();
                registerForm.ShowDialog();
            }
        }
    }
}
