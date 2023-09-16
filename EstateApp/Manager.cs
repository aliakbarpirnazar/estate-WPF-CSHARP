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
using BE;
using BLL;

namespace EstateApp
{
    public partial class Manager : Form
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
        public Manager()
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

        public User LoggedInUser = new User();
        private void Manager_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        UserBLL Ubll = new UserBLL();
        MsgBox MsgBox = new MsgBox();
        private void label2_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش مشتریان", 1))
            {
            CustomerControl s = new CustomerControl();
            s.LoggedInUser = LoggedInUser;
            panel1.Controls.Clear();
            panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار","شما دسترسی به این قسمت را ندارید","",false,true);
            }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label2_Click(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label3_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش ثبت املاک", 1))
            {
                PropertySaleControl s = new PropertySaleControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش امانات", 1))
            {
                TrustControl s = new TrustControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }

           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label4_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label8_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش جستجو ", 1))
            {
                SearchControl s = new SearchControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            label6_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش کاربران", 1))
            {
                PersonalControl s = new PersonalControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش سطل زباله", 1))
            {
                DeleteControl s = new DeleteControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            label9_Click(sender, e);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Information Information = new Information();
            Information.ShowDialog();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            label10_Click(sender, e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            label11_Click(sender, e);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 1))
            {
                SettingControl s = new SettingControl();
                s.LoggedInUser = LoggedInUser;
                panel1.Controls.Clear();
                panel1.Controls.Add(s);

            }
            else
            {
                MsgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            labelX1.Text =LoggedInUser.Name;
        }
    }
}
