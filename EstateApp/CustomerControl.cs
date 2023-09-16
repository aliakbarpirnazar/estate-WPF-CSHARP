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
    public partial class CustomerControl : UserControl
    {
        public CustomerControl()
        {
            InitializeComponent();
        }
        CustomerBLL bll = new CustomerBLL();
        UserBLL Ubll = new UserBLL();
        MsgBox msgBox =new MsgBox();
        int id;
        public User LoggedInUser = new User();
        void ShowDataGridview()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read();
            dataGridViewX1.Columns["آیدی"].Visible = false;

        }
        void ClearTextboxs()
        {
            textBoxX1.Text = "";
            textBoxX3.Text = "";
            textBoxX5.Text = "";
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش مشتریان", 2))
            {
                Customer c = new Customer();
                c.NameFamily = textBoxX1.Text;
                c.Phone = textBoxX3.Text;
                c.RegDate = DateTime.Now;
                if (label4.Text == "ویرایش مشتری")
                {
                    msgBox.MyShowDialog("اطلاعیه", bll.Update(c, id), "", false, false);
                    label4.Text = "افزون مشتری";
                }
                else if (label4.Text == "افزون مشتری")
                {
                    msgBox.MyShowDialog("اطلاعیه", bll.Create(c), "", false, false);
                }
                ShowDataGridview();
                ClearTextboxs();

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           

        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            ShowDataGridview();
           
        }
        int index;

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked && checkBox3.Checked || !checkBox1.Checked && !checkBox3.Checked)
            {
                index = 0;
               
            }
            else if (checkBox1.Checked)
            {
                index = 1;
              
            }
            else if (checkBox3.Checked)
            {
                index = 2;
               
            }
           
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read(textBoxX5.Text, index);
            dataGridViewX1.Columns["آیدی"].Visible = false;
            if (textBoxX5.Text == "")
            {
                ShowDataGridview();
            }
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Ubll.Access(LoggedInUser, "بخش مشتریان", 3))
            {
                Customer c = bll.Read(id);
                textBoxX1.Text = c.NameFamily;
                textBoxX3.Text = c.Phone;
                label4.Text = "ویرایش مشتری";

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش مشتریان", 4))
            {
                DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف مشتری تمام اطلاعات مشتری حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", bll.Delete(id), "", false, false);
                    ShowDataGridview();
                }

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }


          
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >='0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) {e.Handled = false;}else{e.Handled = true;}
        }
    }
}
