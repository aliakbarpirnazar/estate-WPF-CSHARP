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
using System.IO;
using BE;
using BLL;
using FoxLearn.License;

namespace EstateApp
{
    public partial class RegisterForm : Form
    {
        

        // گرد دور صفحه

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
        public RegisterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        //
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


        OpenFileDialog ofd = new OpenFileDialog();
        Image pic;
        UserBLL bll = new UserBLL();
        UserGroupBLL UGbll = new UserGroupBLL();
        MsgBox MsgBox = new MsgBox();
        string Savepic(string UserName)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\UserPic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string PicName = UserName + ".JPG";
            try
            {
                string PicPath = ofd.FileName;
                File.Copy(PicPath, path + PicName, true);
            }
            catch (Exception e)
            {
                MessageBox.Show("سیستم قادر به ذخیره عکس نمیباشد \n" + e.Message);

            }
            return path + PicName;
        }

        UserAccessRole FillAccessRole(string Section, bool CanEnter, bool CanCreate, bool CanUpdate, bool CanDelete)
        {
            UserAccessRole uar = new UserAccessRole();
            uar.Section = Section;
            uar.CanEnter = CanEnter;
            uar.CanCreate = CanCreate;
            uar.CanUpdate = CanUpdate;
            uar.CanDelete = CanDelete;
            return uar;
        }
        void CreateAdminGroup()
        {
            UserGroup ug = new UserGroup();
            ug.Title = "مدیر";
            ug.UserAccessRoles.Add(FillAccessRole("بخش مشتریان", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش ثبت املاک", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش امانات", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش جستجو ", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش سطل زباله", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش تنظیمات", true, true, true, true));
            ug.UserAccessRoles.Add(FillAccessRole("بخش کاربران", true, true, true, true));
            UGbll.Create(ug);
           

        }
        void CreateLocationState()
        {
            State STAT = new State();
            STAT.Name = "قم";
            StateBLL Sbll = new StateBLL();
            Sbll.Create(STAT);
        }
        void CreateLocationcity()
        {
            State sc = new State();
            StateBLL Sbll = new StateBLL();
            sc.id = Sbll.Readid("قم");
            City CIT = new City();
            CIT.Name = "قم";
            CityBLL CitBLL = new CityBLL();
            CitBLL.Create(CIT, sc);
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label3_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(textBoxX1.Text);
            string productKey = textBoxX7.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }
                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("!فعال سازی برنامه با موفقیت انجام شد", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox2.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("!کد لایسنس نامعتبر است", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxX2.Focus();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
           ofd.Filter = " JPEG(*.JPEG)|*.JPEG | PNG(*.PNG)|*.PNG | JPG(*.JPG)|*.JPG ";

            ofd.Title = "تصویر کاربر را انتخاب کنید";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(ofd.FileName);
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label4_Click(sender, e);
        }

        private void RegisterForm_MouseDown(object sender, MouseEventArgs e)
        {
            Move();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            MsgBox msgBox = new MsgBox();
            msgBox.MyShowDialog("اطلاعیه", "نرم افزار فعال نشده است \n لطفا کد لایسنس خریداری شده را وارد نمایید", "", false, false);
            textBoxX1.Text = ComputerInfo.GetComputerId();
            CreateLocationState();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            User u = new User();
            if (textBoxX2.Text != "")
            {
                u.Name = textBoxX2.Text;
                if(textBoxX3.Text != "")
                {
                    u.UserName = textBoxX3.Text;
                    u.RegDate = DateTime.Now;
                    if (textBoxX4.Text == textBoxX5.Text)
                    {
                        u.Password = textBoxX4.Text;
                        u.Pic = Savepic(textBoxX3.Text);
                        CreateAdminGroup();
                        CreateLocationcity();

                        DialogResult dr = MessageBox.Show(bll.Create(u, UGbll.ReadN("مدیر")), "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (dr == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }

                    else
                    {
                        MessageBox.Show("تکرار کلمه عبور درست وارد نشده است");
                        textBoxX4.Text = "";
                        textBoxX5.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("نام کاربر خالی نمیتواند باشد!!");
                }
            }
            else
            {
                MessageBox.Show("نام و نام خانوادگی کاربر خالی نمیتواند باشد!!");

            }
            
            
           

        }
    }
}
