using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Effects;


namespace EstateApp
{
    public partial class propertysale : UserControl
    {
        public propertysale()
        {
            InitializeComponent();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void buttonX1_Click(object sender, EventArgs e)
        {
            SettingStateForm settingStateForm = new SettingStateForm();
            settingStateForm.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox2.Enabled = true;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                checkBox5.Checked=false;
                checkBox5.Enabled = false;


                comboBoxEx8.Enabled = false;
                comboBoxEx9.Enabled = false;
            }
            else
            {
                checkBox3.Enabled = true;
                checkBox5.Enabled = true;
                comboBoxEx8.Enabled = true;
                comboBoxEx9.Enabled = true;

            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox3.Enabled = true;
                textBoxX8.Enabled = false;
                textBoxX7.Enabled = false;
            }
            else
            {
                checkBox5.Enabled = true;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX8.Enabled = true;
                textBoxX7.Enabled = true;

            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX7.Enabled= false;
                comboBoxEx7.Enabled = false;
                comboBoxEx1.Enabled = false;
                comboBoxEx9.Enabled = false;
                checkBox9.Checked = false;
                checkBox9.Visible = false;

            }
            else
            {
                checkBox5.Enabled = true;
                textBoxX7.Enabled = true;
                comboBoxEx7.Enabled = true;
                comboBoxEx1.Enabled = true;
                comboBoxEx9.Enabled = true;
                checkBox9.Visible = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Enabled = true;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX7.Enabled = false;
                textBoxX10.Enabled = false;
                comboBoxEx9.Enabled = false;
                comboBoxEx8.Enabled = false;
                comboBoxEx1.Enabled = false;
                groupBox3.Visible = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
            else
            {
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                textBoxX7.Enabled = true;
                textBoxX10.Enabled = true;
                comboBoxEx9.Enabled = true;
                comboBoxEx8.Enabled = true;
                comboBoxEx1.Enabled = true;
                groupBox3.Visible = true;
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX7.Enabled = false;
                textBoxX8.Enabled= false;
                textBoxX10.Enabled = false;
                comboBoxEx9.Enabled = false;
                comboBoxEx8.Enabled = false;
                comboBoxEx1.Enabled = false;
                groupBox3.Visible = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
            else
            {
                checkBox5.Enabled = true;
                textBoxX7.Enabled = true;
                textBoxX8.Enabled = true;
                textBoxX10.Enabled = true;
                comboBoxEx9.Enabled = true;
                comboBoxEx8.Enabled = true;
                comboBoxEx1.Enabled = true;
                groupBox3.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX7.Enabled = false;
                textBoxX8.Enabled = false;
                comboBoxEx1.Enabled = false;
                comboBoxEx7.Enabled = false;
                comboBoxEx8.Enabled = false;
                comboBoxEx9.Enabled = false;
                checkBox9.Checked = false;
                checkBox9.Visible = false;

            }
            else
            {
                checkBox5.Enabled = true;
                textBoxX7.Enabled = true;
                textBoxX8.Enabled = true;
                comboBoxEx1.Enabled = true;
                comboBoxEx7.Enabled = true;
                comboBoxEx8.Enabled = true;
                comboBoxEx9.Enabled = true;
                checkBox9.Visible = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                groupBox2.Enabled = true;
                checkBox5.Checked = false;
                checkBox5.Enabled = false;
                checkBox3.Checked = false;
                checkBox3.Enabled = false;
                textBoxX7.Enabled = false;
                textBoxX8.Enabled = false;
                textBoxX10.Enabled = false;
                comboBoxEx1.Enabled = false;
                comboBoxEx7.Enabled = false;
                comboBoxEx8.Enabled = false;
                comboBoxEx9.Enabled = false;
                checkBox9.Checked = false;
                checkBox9.Visible = false;
            }
            else
            {
                checkBox5.Enabled = true;
                textBoxX7.Enabled = true;
                textBoxX8.Enabled = true;
                textBoxX10.Enabled = true;
                comboBoxEx1.Enabled = true;
                comboBoxEx7.Enabled = true;
                comboBoxEx8.Enabled = true;
                comboBoxEx9.Enabled = true;
                checkBox9.Visible = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBoxX6.Enabled = true;
            }
            else
                textBoxX6.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            checkBox5.Enabled = true;
        }
    }
}
