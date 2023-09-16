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
    public partial class SettingTrustForm : Form
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
        public SettingTrustForm()
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TrustGroupBLL bll = new TrustGroupBLL();
        MsgBox msgBox = new MsgBox();
        int id;

        void ShowDataGridview()
        {
            dataGridViewX3.DataSource = null;
            dataGridViewX3.DataSource = bll.Read();
            dataGridViewX3.Columns["آیدی"].Visible = false;

        }
        void ClearTextboxs()
        {
            
            textBoxX3.Text = "";
           
        }
        private void SettingTrustForm_Load(object sender, EventArgs e)
        {
            ShowDataGridview();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TrustGroup c = new TrustGroup();
          if(textBoxX3.Text != "")
            {
                c.NameTrust = textBoxX3.Text;
                c.RegDate = DateTime.Now;
                if (label3.Text == "ویرایش دسته بندی")
                {
                    msgBox.MyShowDialog("اطلاعیه", bll.Update(c, id), "", false, false);
                    label3.Text = "افزون دسته بندی";
                }
                else if (label3.Text == "افزون دسته بندی")
                {
                    msgBox.MyShowDialog("اطلاعیه", bll.Create(c), "", false, false);
                }
            }
            
            ShowDataGridview();
            ClearTextboxs();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label3_Click(sender, e);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrustGroup c = bll.Read(id);       
            textBoxX3.Text = c.NameTrust;
            label3.Text = "ویرایش مشتری";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف گروه تمام اطلاعات دسته بندی حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

            if (dr == DialogResult.Yes)
            {

                msgBox.MyShowDialog("اطلاعیه", bll.Delete(id), "", false, false);
                ShowDataGridview();
            }
        }

        private void dataGridViewX3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX3.Rows[dataGridViewX3.CurrentRow.Index].Cells["آیدی"].Value);
        }
    }
}
