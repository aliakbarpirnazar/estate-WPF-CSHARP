using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace EstateApp
{
    public partial class DeleteControl : UserControl
    {
        public DeleteControl()
        {
            InitializeComponent();
        }
        CustomerBLL cbll = new CustomerBLL();
        MsgBox msgBox = new MsgBox();
        int id;
        void ShowDataGridview()
        {
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = cbll.DelRead();
            dataGridViewX2.Columns["آیدی"].Visible = false;

        }
        void ClearTextboxs()
        {
            textBoxX2.Text = "";
           
        }
        UserBLL Ubll = new UserBLL();
        public User LoggedInUser = new User();
        private void بازگردانیمشتریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش سطل زباله", 4))
            {
                DialogResult dr = msgBox.MyShowDialog("اخطار", "آیا مطمئن هستید که میخواهید بازیابی کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", cbll.Recovery(id), "", false, false);
                    ShowDataGridview();
                }

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {
            ShowDataGridview();
        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

              int index = 0;
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = cbll.SRead(textBoxX2.Text, index);
            dataGridViewX2.Columns["آیدی"].Visible = false;
            if (textBoxX2.Text == "")
            {
                ShowDataGridview();
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
