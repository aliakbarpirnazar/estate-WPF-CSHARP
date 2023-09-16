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
using BE;
using BLL;


namespace EstateApp
{
    public partial class PropertySaleControl : UserControl
    {
        public PropertySaleControl()
        {
            InitializeComponent();
        }
        EstateBLL Ebll = new EstateBLL();
        CustomerBLL Cbll = new CustomerBLL();
        Customer c = new Customer();
        MsgBox msgBox = new MsgBox();
        int id;
        StateBLL Sbll = new StateBLL();
        StreetBLL STbll = new StreetBLL();
        CityBLL CitBLL = new CityBLL();
        int  l, ssi;
        State sc = new State();
        City Ct = new City();
        string s, CI, sst;


        void clear()
        {
            checkBox3.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;
            checkBox1.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            richTextBoxEx1.Text = "";
            richTextBoxEx2.Text = "";
            textBoxX6.Text = "";
            textBoxX3.Text = "";
            textBoxX1.Text = "";
            textBoxX5.Text = "";
            textBoxX9.Text = "";
            textBoxX8.Text = "";
            textBoxX7.Text = "";
            textBoxX10.Text = "";
            AmberState();
            Kusers();
            Goghraphy();
            NumFoolr();
            Foolers();
            NumStateFoolr();
            TypeDuc();

        }
        
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void buttonX1_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            clear();
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
            clear();
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
            clear(); 
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
            clear();
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
            clear();
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
            clear();
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
            clear();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
                textBoxX3.Text = null;
                textBoxX1.Text = null;
                textBoxX3.Enabled = true;
                textBoxX3.Visible = true;
                textBoxX1.Enabled = true;
                textBoxX1.Visible = true;
                label25.Enabled = true;
                label25.Visible = true;
                label26.Enabled = true;
                label26.Visible = true;

            }
            else
            {
                textBoxX3.Text = null;
                textBoxX1.Text = null;
                textBoxX3.Enabled = false;
                textBoxX3.Visible = false;
                textBoxX1.Enabled = false;
                textBoxX1.Visible = false;
                label25.Enabled = false;
                label25.Visible = false;
                label26.Enabled = false;
                label26.Visible = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                textBoxX5.Text = null;
                textBoxX5.Enabled = true;
                textBoxX5.Visible = true;
                label10.Enabled = true;
                label10.Visible = true;
               

            }
            else
            {
                textBoxX5.Text = null;
                textBoxX5.Enabled = false;
                textBoxX5.Visible = false;
                label10.Enabled = false;
                label10.Visible = false;
            }
        }
        UserBLL Ubll = new UserBLL();
        public User LoggedInUser = new User();
        private void label4_Click(object sender, EventArgs e)
        {
            
            if (Ubll.Access(LoggedInUser, "بخش ثبت املاک", 2))
            {

                Estate f = new Estate();
                f.RegDate = DateTime.Now;
                if (checkBox11.Checked)
                {
                    f.Sale = true;

                }
                else
                {
                    f.Sale = false;
                }
                if (textBoxX5.Text == "")
                {
                    f.PriceSale = 0;
                }
                else
                {
                    f.PriceSale = Convert.ToDouble(textBoxX5.Text);
                }
                if (textBoxX3.Text == "")
                {
                    f.PriceAmount = 0;
                }
                else
                {
                    f.PriceAmount = Convert.ToDouble(textBoxX3.Text);
                }
                if (textBoxX1.Text == "")
                {
                    f.PriceRent = 0;
                }
                else
                {
                    f.PriceRent = Convert.ToDouble(textBoxX1.Text);
                }
                if (checkBox10.Checked)
                {
                    f.Rental = true;
                }
                else
                {
                    f.Rental = false;
                }
                if (radioButton1.Checked)
                {
                    f.PropertyType = radioButton1.Text;
                }
                if (radioButton2.Checked)
                {
                    f.PropertyType = radioButton2.Text;
                }
                if (radioButton3.Checked)
                {
                    f.PropertyType = radioButton3.Text;
                }
                if (radioButton4.Checked)
                {
                    f.PropertyType = radioButton4.Text;
                }
                if (radioButton5.Checked)
                {
                    f.PropertyType = radioButton5.Text;
                }
                if (radioButton6.Checked)
                {
                    f.PropertyType = radioButton6.Text;
                }
                if (radioButton7.Checked)
                {
                    f.PropertyType = radioButton7.Text;
                }
                if (checkBox3.Checked)
                {
                    f.Presell = true;
                }
                else
                {
                    f.Presell = false;
                }
                if (checkBox2.Checked)
                {
                    f.Construction = true;
                }
                else
                {
                    f.Construction = false;
                }
                if (checkBox4.Checked)
                {
                    f.Exchange = true;
                }
                else
                {
                    f.Exchange = false;
                }
                if (textBoxX6.Text != "")
                {
                    f.TypeExchange = textBoxX6.Text;
                }
                if (comboBoxEx2.Text != "")
                {
                    f.State = comboBoxEx2.SelectedItem.ToString();
                }
                if (comboBoxEx3.Text != "")
                {
                    f.City = comboBoxEx3.SelectedItem.ToString();
                }
                if (comboBoxEx4.Text != "")
                {
                    f.Street = comboBoxEx4.SelectedItem.ToString();
                }
                if (richTextBoxEx1.Text != "")
                {
                    f.Address = richTextBoxEx1.Text;
                }
                if (textBoxX9.Text != "")
                {
                    f.Area = Convert.ToInt32(textBoxX9.Text);
                }
                else { f.Area = 0; }
                if (comboBoxEx5.Text != "")
                {
                    if (comboBoxEx5.SelectedItem.ToString() == "نوساز")
                        f.Amber = 0;
                    else
                        f.Amber = Convert.ToInt32(comboBoxEx5.SelectedItem.ToString());
                }
                if (checkBox1.Checked)
                {
                    f.KeyNot = true;

                }
                else
                {
                    f.KeyNot = false;
                }
                if (comboBoxEx6.Text != "")
                {
                    f.KUsers = comboBoxEx6.SelectedItem.ToString();
                }
                if (comboBoxEx7.Text != "")
                {
                    f.Geography = comboBoxEx7.SelectedItem.ToString();
                }
                if (textBoxX8.Text != "")
                {
                    f.BarMelk = Convert.ToInt32(textBoxX8.Text);
                }
                if (textBoxX7.Text != "")
                {
                    f.Foundation = Convert.ToInt32(textBoxX7.Text);
                }
                if (textBoxX10.Text != "")
                {
                    f.NRooms = Convert.ToInt32(textBoxX10.Text);
                }
                if (comboBoxEx1.Text != "")
                {
                    f.NFloor = comboBoxEx1.SelectedItem.ToString();
                }
                if (comboBoxEx8.Text != "")
                {
                    f.Floor = comboBoxEx8.SelectedItem.ToString();
                }
                if (comboBoxEx9.Text != "")
                {
                    f.NUnitFloor = comboBoxEx9.SelectedItem.ToString();
                }
                if (comboBoxEx10.Text != "")
                {
                    f.TypeDoucument = comboBoxEx10.SelectedItem.ToString();
                }
                if (checkBox5.Checked)
                {
                    f.ProductionLicense = true;

                }
                else
                {
                    f.ProductionLicense = false;
                }
                if (checkBox6.Checked)
                {
                    f.Parking = true;

                }
                else
                {
                    f.Parking = false;
                }
                if (checkBox7.Checked)
                {
                    f.WareHouse = true;

                }
                else
                {
                    f.WareHouse = false;
                }
                if (checkBox8.Checked)
                {
                    f.Elevator = true;

                }
                else
                {
                    f.Elevator = false;
                }
                if (checkBox9.Checked)
                {
                    f.Pilot = true;

                }
                else
                {
                    f.Pilot = false;
                }
                if (richTextBoxEx2.Text != "")
                {
                    f.Discription = richTextBoxEx2.Text;
                }
                msgBox.MyShowDialog("اطلاعیه", Ebll.Create(f, c), "", false, false);
                clear();
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

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CI = comboBoxEx2.SelectedItem.ToString();
            l = Sbll.Readid(CI);
            sc.id = Sbll.Readid(s);
            if (Sbll.Readid(CI) == 0)
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

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {
            sst = comboBoxEx3.SelectedItem.ToString();
            Ct.id = CitBLL.Readid(sst);
            if (CitBLL.Readid(sst) == 0)
            {
                msgBox.MyShowDialog("اطلاعیه", "خیابان یا منطقه پیدا نشد", "", false, false);
            }
            else
            {

                comboBoxEx4.Items.Clear();
                foreach (var item in STbll.ReadName(CitBLL.Readid(sst)))
                {

                    comboBoxEx4.Items.Add(item);
                }

            }
        }


        void AmberState()
        {
            List<string> list1 = new List<string>();

            comboBoxEx5.Items.Clear();

            comboBoxEx5.Items.Add("نوساز");

            int p;
            for (p = 1; p < 30; p++)
            {
                comboBoxEx5.Items.Add(p);
            }


        }

        void Kusers()
        {
           List<string> KUser = new List<string>(){"مسکونی","مسکونی - تجاری","مسکونی -اداری","مسکونی - مزروعی",
               "اداری","اداری - صنعتی","تجاری","تجاری - اداری","تجاری - صنعتی","مزروعی","مزروعی - تجاری",
               "مزروعی - دامپروری","صنعتی","صنعتی - کشاورزی","گردشگری","دامداری"};
            comboBoxEx6.Items.Clear();
            comboBoxEx6.RightToLeft = RightToLeft.Yes;
            
            foreach (var item in KUser)
            {

                comboBoxEx6.Items.Add(item);
                comboBoxEx6.RightToLeft = RightToLeft.Yes;

            }


        }
        void Goghraphy()
        {
           List<string> Goghraphies = new List<string>(){"جنوبی","شمالی","دوکله","سه بر",
               "دوبر","شرغی - غربی"};
            comboBoxEx7.Items.Clear();
            comboBoxEx7.RightToLeft = RightToLeft.Yes;
            
            foreach (var item in Goghraphies)
            {

                comboBoxEx7.Items.Add(item);
                comboBoxEx7.RightToLeft = RightToLeft.Yes;

            }


        }
        void NumFoolr()
        {
            int m;
          
            comboBoxEx1.Items.Clear();
            comboBoxEx1.RightToLeft = RightToLeft.Yes;
            
            for (m=1;m<=50;m++)
            {

                comboBoxEx1.Items.Add(m);
              

            }


        }
        void Foolers()
        {
            int m;
           
            comboBoxEx8.Items.Clear();
            comboBoxEx8.RightToLeft = RightToLeft.Yes;
            List<string> Goghraphies = new List<string>(){"-3","-2","زیرزمین","همکف"};
            foreach (var item in Goghraphies)
            {
                comboBoxEx8.Items.Add(item);
            }

            for (m=1;m<=50;m++)
            {

                comboBoxEx8.Items.Add(m);
              

            }


        }
        void NumStateFoolr()
        {
            int m;

            comboBoxEx9.Items.Clear();
            comboBoxEx9.RightToLeft = RightToLeft.Yes;

            for (m = 1; m <= 7; m++)
            {

                comboBoxEx9.Items.Add(m);


            }


        }
        void TypeDuc()
        {
            List<string> TypeDuc = new List<string>(){"اوقافی","قرارداد واگذاری سازمانی مسکن","شش دانگ",
                "مشاع","شورایی","سرقفلی","وکالتی","قولنامه ای"};
            comboBoxEx10.Items.Clear();
            comboBoxEx10.RightToLeft = RightToLeft.Yes;

            foreach (var item in TypeDuc)
            {

                comboBoxEx10.Items.Add(item);
                comboBoxEx10.RightToLeft = RightToLeft.Yes;

            }


        }

        private void comboBoxEx4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEx5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void PropertySaleControl_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection Phone = new AutoCompleteStringCollection();
            foreach (var item in Cbll.ReadPhone())
            {
                Phone.Add(item);
            }
            textBoxX4.AutoCompleteCustomSource = Phone;
            foreach (var item in Sbll.ReadName())
            {
                comboBoxEx2.Items.Add(item);
            }
            checkBox11.Checked = true;
            comboBoxEx2.SelectedIndex = 0;
            comboBoxEx3.SelectedIndex = 0;
            AmberState();
            Kusers();
            Goghraphy();
            NumFoolr();
            Foolers();
            NumStateFoolr();
            TypeDuc();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBoxX4.Enabled = false;
            c = Cbll.ReadC(textBoxX4.Text);
            label28.Text = c.NameFamily;
            label29.Text = c.Phone;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
