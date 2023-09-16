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
    public partial class SettingControl : UserControl
    {
        public SettingControl()
        {
            InitializeComponent();
        }
        StateBLL Sbll = new StateBLL();
        StreetBLL STbll = new StreetBLL();
        CityBLL CitBLL = new CityBLL();
        MsgBox msgBox = new MsgBox();
        int id,l,ssi;
        State sc = new State();
        City Ct = new City();
        string s,c,sst;
        void ShowDataGridview()
        {
            dataGridViewX3.DataSource = null;
            dataGridViewX3.DataSource = Sbll.Read();
            dataGridViewX3.Columns["آیدی"].Visible = false;
        }

        void ShowDataGridviewCity()
        {
          s = comboBoxEx1.SelectedItem.ToString();
          sc.id=Sbll.Readid(s);
            if (Sbll.Readid(s) == 0)
            {
                msgBox.MyShowDialog("اطلاعیه", "استان پیدا نشد", "", false, false);
            }
            else
            {

                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = CitBLL.ReadCity(Sbll.Readid(s));
                dataGridViewX1.Columns["آیدی"].Visible = false;
                dataGridViewX1.Columns["آیدی استان"].Visible = false;

            }

}
        void ShowDataGridViewStreet()
        {
            sst = comboBoxEx3.SelectedItem.ToString();
            Ct.id = CitBLL.Readid(sst);
            if (CitBLL.Readid(sst) == 0)
            {
                msgBox.MyShowDialog("اطلاعیه", "خیابان یا منطقه پیدا نشد", "", false, false);
            }
            else
            {

                dataGridViewX2.DataSource = null;
                dataGridViewX2.DataSource = STbll.ReadStreet(CitBLL.Readid(sst));
                dataGridViewX2.Columns["آیدی"].Visible = false;
                dataGridViewX2.Columns["آیدی شهر"].Visible = false;

            }
        }
        void ClearTextboxs()
        {
        
            textBoxX3.Text = "";
            textBoxX2.Text = "";
            textBoxX1.Text = "";
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label3_Click(sender, e);
        }
        UserBLL Ubll = new UserBLL();
        public User LoggedInUser = new User();
        private void label3_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 2))
            {
                State c = new State();
                c.Name = textBoxX3.Text;
                if (label3.Text == "ویرایش استان")
                {
                    msgBox.MyShowDialog("اطلاعیه", Sbll.Update(c, id), "", false, false);
                    label3.Text = "ثبت استان جدید";
                }
                else if (label3.Text == "ثبت استان جدید")
                {
                    msgBox.MyShowDialog("اطلاعیه", Sbll.Create(c), "", false, false);
                }
                ShowDataGridview();
                ClearTextboxs();

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }


           
        }

        private void SettingControl_Load(object sender, EventArgs e)
        {
            ShowDataGridview();
            
            foreach (var item in Sbll.ReadName())
            {
                comboBoxEx1.Items.Add(item);
                comboBoxEx2.Items.Add(item);
            }
            
            //ShowDataGridviewCity();

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 3))
            {
                State c = Sbll.Read(id);
                textBoxX3.Text = c.Name;
                label3.Text = "ویرایش استان";
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 4))
            {

                DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف استان تمام اطلاعات استان حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", Sbll.Delete(id), "", false, false);
                    ShowDataGridview();
                }
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }



        }

        private void dataGridViewX3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX3.Rows[dataGridViewX3.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 2))
            {
                City c = new City();
                c.Name = textBoxX2.Text;

                if (label1.Text == "ویرایش شهر")
                {
                    msgBox.MyShowDialog("اطلاعیه", CitBLL.Update(c, id), "", false, false);
                    comboBoxEx1.Enabled = true;
                    label1.Text = "ثبت شهر جدید";

                }
                else if (label1.Text == "ثبت شهر جدید")
                {
                    msgBox.MyShowDialog("اطلاعیه", CitBLL.Create(c, sc), "", false, false);
                }
                //ShowDataGridviewCity();
                ShowDataGridviewCity();
                ClearTextboxs();

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }

           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip2.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataGridviewCity();

        }

        private void ویرایشToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 3))
            {
                City c = CitBLL.Read(id);
                textBoxX2.Text = c.Name;
                comboBoxEx1.Enabled = false;
                label1.Text = "ویرایش شهر";
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }
           

        }

        private void حذفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 4))
            {

                DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف شهر تمام اطلاعات شهر حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", CitBLL.Delete(id), "", false, false);
                    comboBoxEx1_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label5_Click(sender, e);
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataGridViewStreet();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش تنظیمات", 2))
            {
                Street c = new Street();
                c.Name = textBoxX1.Text;

                if (label5.Text == "ویرایش")
                {
                    // msgBox.MyShowDialog("اطلاعیه", STbll.Update(c, id), "", false, false);
                    comboBoxEx1.Enabled = true;
                    label5.Text = "ثبت";

                }
                else if (label5.Text == "ثبت")
                {
                    msgBox.MyShowDialog("اطلاعیه", STbll.Create(c, Ct), "", false, false);
                }

                ShowDataGridViewStreet();
                ClearTextboxs();
            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }


        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = comboBoxEx2.SelectedItem.ToString();
            l = Sbll.Readid(c);
            sc.id = Sbll.Readid(s);
            if (Sbll.Readid(c) == 0)
            {
                msgBox.MyShowDialog("اطلاعیه", "شهر پیدا نشد", "", false, false);
            }
            else
            {
                comboBoxEx3.Items.Clear();
                foreach (var item in CitBLL.ReadName(l))
                {

                    comboBoxEx3.Items.Add(item);
                }

            }
        }
    }
}
