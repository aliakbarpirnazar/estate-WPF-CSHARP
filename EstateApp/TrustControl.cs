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
    public partial class TrustControl : UserControl
    {
        public TrustControl()
        {
            InitializeComponent();
        }
        TrustGroup TG = new TrustGroup();
        Trust Tr = new Trust();
        MsgBox msgBox = new MsgBox();
        TrustGroupBLL Tgbll = new TrustGroupBLL();
        TrustControlBLL Trbll = new TrustControlBLL();

        CustomerBLL Cbll = new CustomerBLL();
        Customer c = new Customer();
        int id;
        void ShowDataGridview()
        {
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = Trbll.Read();
            dataGridViewX2.Columns["آیدی"].Visible = false;
            dataGridViewX2.Columns["توضیحات"].Visible = false;

        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            SettingTrustForm manager = new SettingTrustForm();
            manager.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TrustControl_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection Phone = new AutoCompleteStringCollection();
            foreach (var item in Cbll.ReadPhone())
            {
                Phone.Add(item);
            }
            textBoxX1.AutoCompleteCustomSource = Phone;
            comboBoxEx3.Items.Clear();
            foreach (var item in Tgbll.ReadName())
            {
                comboBoxEx3.Items.Add(item);
            }
            ShowDataGridview();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBoxX1.Enabled = false;
            c = Cbll.ReadC(textBoxX1.Text);
            labelX3.Text = c.NameFamily;
            labelX1.Text = c.Phone;
        }

        void clear()
        {
            textBoxX1.Text = "";
        }

        UserBLL Ubll = new UserBLL();
        public User LoggedInUser = new User();
        private void label4_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش امانات", 2))
            {
                Trust T = new Trust();
                T.RegDate = DateTime.Now;
                T.Title = comboBoxEx3.SelectedItem.ToString();
                T.Discription = richTextBoxEx2.Text;
                msgBox.MyShowDialog("اطلاعیه", Trbll.Create(T, c), "", false, false);
                clear();
                ShowDataGridview();

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }

           


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label4_Click(sender, e);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش امانات", 4))
            {
                DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف  تمام اطلاعات  حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", Trbll.Delete(id), "", false, false);
                    ShowDataGridview();
                }
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }

           

        }

        private void نمایشجزئیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trust c = Trbll.Read(id);
            string g = c.Discription;
            msgBox.MyShowDialog("توضیحات ", g, "", false, false);
        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }
    }
}
