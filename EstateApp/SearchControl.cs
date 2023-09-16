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
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }
        EstateBLL Ebll = new EstateBLL();
        CustomerBLL Cbll = new CustomerBLL();
        Customer c = new Customer();
        MsgBox msgBox = new MsgBox();
        MsgPMClass msgPM = new MsgPMClass();
        int id,idCU;
        StateBLL Sbll = new StateBLL();
        StreetBLL STbll = new StreetBLL();
        CityBLL CitBLL = new CityBLL();
        int l, ssi;
        State sc = new State();
        City Ct = new City();
        string s, CI, sst;

        void AmberState()
        {
            List<string> list1 = new List<string>();
           
            comboBoxEx12.Items.Clear();

            comboBoxEx12.Items.Add("نوساز");

            int p;
            for (p=1;p<30;p++)
            {
                comboBoxEx12.Items.Add(p);
            }


        }
       
        void NumFoolr()
        {
            int m;

            


        }
    


       
        void ShowDataGridview()
        {
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = Ebll.Read();
            dataGridViewX2.Columns["آیدی"].Visible = false;
            dataGridViewX2.Columns["پیش فروش"].Visible = false;
            dataGridViewX2.Columns["مشارک"].Visible = false;
            dataGridViewX2.Columns["معاوضه"].Visible = false;
            dataGridViewX2.Columns["توضیحات معاوضه"].Visible = false;
            dataGridViewX2.Columns["آدرس"].Visible = false;
            dataGridViewX2.Columns["کلید نخورده"].Visible = false;
            dataGridViewX2.Columns["کاربری"].Visible = false;
            dataGridViewX2.Columns["جغرافیا"].Visible = false;
            dataGridViewX2.Columns["برملک"].Visible = false;
            dataGridViewX2.Columns["زیربنا"].Visible = false;
            dataGridViewX2.Columns["تعداد اتاق"].Visible = false;
            dataGridViewX2.Columns["طبقه"].Visible = false;
            dataGridViewX2.Columns["تعداد واحد"].Visible = false;
            dataGridViewX2.Columns["نوع سند"].Visible = false;
            dataGridViewX2.Columns["پروانه ساخت"].Visible = false;
            dataGridViewX2.Columns["توضیحات"].Visible = false;
            dataGridViewX2.Columns["تاریخ ثبت"].Visible = false;
           // dataGridViewX2.Columns["نام کاربری"].Visible = false;
            dataGridViewX2.Columns["نام مشتری"].Visible = false;
            dataGridViewX2.Columns["توضیحات"].Visible = false;
            dataGridViewX2.Columns["پارکینگ"].Visible = false;
            dataGridViewX2.Columns["انباری"].Visible = false;
            dataGridViewX2.Columns["آسانسور"].Visible = false;
            dataGridViewX2.Columns["پیلوت"].Visible = false;
            dataGridViewX2.Columns["آیدی مشتری"].Visible = false;
            dataGridViewX2.Columns["تعداد طبقات"].Visible = false;

        }
        void ShowDataGridview1(string s)
        {
            
            dataGridViewX2.DataSource = null;
            dataGridViewX2.DataSource = Ebll.Read(s);
            dataGridViewX2.Columns["آیدی"].Visible = false;
            dataGridViewX2.Columns["پیش فروش"].Visible = false;
            dataGridViewX2.Columns["مشارک"].Visible = false;
            dataGridViewX2.Columns["معاوضه"].Visible = false;
            dataGridViewX2.Columns["توضیحات معاوضه"].Visible = false;
            dataGridViewX2.Columns["آدرس"].Visible = false;
            dataGridViewX2.Columns["کلید نخورده"].Visible = false;
            dataGridViewX2.Columns["کاربری"].Visible = false;
            dataGridViewX2.Columns["جغرافیا"].Visible = false;
            dataGridViewX2.Columns["برملک"].Visible = false;
            dataGridViewX2.Columns["زیربنا"].Visible = false;
            dataGridViewX2.Columns["تعداد اتاق"].Visible = false;
            dataGridViewX2.Columns["طبقه"].Visible = false;
            dataGridViewX2.Columns["تعداد واحد"].Visible = false;
            dataGridViewX2.Columns["نوع سند"].Visible = false;
            dataGridViewX2.Columns["پروانه ساخت"].Visible = false;
            dataGridViewX2.Columns["توضیحات"].Visible = false;
           dataGridViewX2.Columns["تاریخ ثبت"].Visible = false;
           // dataGridViewX2.Columns["نام کاربری"].Visible = false;
            dataGridViewX2.Columns["نام مشتری"].Visible = false;
            dataGridViewX2.Columns["توضیحات"].Visible = false;
            dataGridViewX2.Columns["پارکینگ"].Visible = false;
            dataGridViewX2.Columns["انباری"].Visible = false;
            dataGridViewX2.Columns["آسانسور"].Visible = false;
            dataGridViewX2.Columns["پیلوت"].Visible = false;
            dataGridViewX2.Columns["آیدی مشتری"].Visible = false;
            dataGridViewX2.Columns["تعداد طبقات"].Visible = false;

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

        private void comboBoxEx4_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        
    }

        private void SearchControl_Load(object sender, EventArgs e)
        {
            comboBoxEx11.Items.Add("فروشی");
            comboBoxEx11.Items.Add("رهن یا اجاره");
            //Load Ostan
            foreach (var item in Sbll.ReadName())
            {
                comboBoxEx2.Items.Add(item);
            }
            //
            //Load
            AmberState();
        
            NumFoolr();
            ShowDataGridview();
            //
            comboBoxEx11.SelectedIndex = 0;
            comboBoxEx2.SelectedIndex = 0;
            comboBoxEx3.SelectedIndex = 0;
            comboBoxEx12.SelectedIndex = 3;
           

        }
        string CM= "SELECT TOP (100) PERCENT dbo.Estates.id AS آیدی, dbo.Estates.Sale AS فروشی, dbo.Estates.Rental AS [رهن و اجاره], dbo.Estates.PropertyType AS [نوع ملک], dbo.Estates.Presell AS [پیش فروش], dbo.Estates.RegDate AS [تاریخ ثبت], dbo.Estates.Construction AS مشارک, dbo.Estates.Exchange AS معاوضه, dbo.Estates.TypeExchange AS[توضیحات معاوضه], dbo.Estates.State AS استان, dbo.Estates.City AS شهر, dbo.Estates.Street AS منطقه, dbo.Estates.Address AS آدرس,  dbo.Estates.PriceAmount AS[مبلغ رهن], dbo.Estates.PriceRent AS[مبلغ اجاره], dbo.Estates.PriceSale AS[مبلغ فروش], dbo.Estates.Amber AS عمربنا, dbo.Estates.KeyNot AS[کلید نخورده], dbo.Estates.KUsers AS کاربری,  dbo.Estates.Geography AS جغرافیا, dbo.Estates.Area AS مساحت, dbo.Estates.BarMelk AS برملک, dbo.Estates.Foundation AS زیربنا, dbo.Estates.NRooms AS[تعداد اتاق], dbo.Estates.NFloor AS[تعداد طبقات], dbo.Estates.Floor AS طبقه,  dbo.Estates.NUnitFloor AS[تعداد واحد], dbo.Estates.TypeDoucument AS[نوع سند], dbo.Estates.ProductionLicense AS[پروانه ساخت], dbo.Estates.Parking AS پارکینگ, dbo.Estates.WareHouse AS انباری,  dbo.Estates.Elevator AS آسانسور, dbo.Estates.Pilot AS پیلوت, dbo.Estates.Discription AS توضیحات, dbo.Customers.NameFamily AS[نام مشتری], dbo.Customers.id AS[آیدی مشتری] FROM dbo.Estates INNER JOIN dbo.Customers ON dbo.Estates.Customers_id = dbo.Customers.id  WHERE ";
        string Rent = "(dbo.Estates.Rental = 1)";
        string Sal = "(dbo.Estates.Sale = 1)";
        string PTypeAnd = "AND ((dbo.Estates.PropertyType=N'";
        string PType21="",PType22="", PType23="", PType24="", PType25="", PType26="", PType27="", ST1 = "", CT1 = "", AM = "", PR = "", ARE = "",Park ="1",War="1",Elv="1",Pil="1" , PRe="", PRes="";
        string PTypeEnd = "')";
        string PTypeOR = "OR (dbo.Estates.PropertyType = N'";
        string STAND = "AND (dbo.Estates.State = N'";
        string STEnd = "')";
        string CTAND = "AND (dbo.Estates.City = N'";
        string CTEnd = "')";
        string AMAND = "AND (dbo.Estates.Amber <= ";
        string AMEnd = ")";
        string PRAND = "AND (dbo.Estates.PriceSale <= ";
        string PREnd = ")";
        string AREAND = "AND (dbo.Estates.Area <= ";
        string AREEnd = ")";
        string ParkAND = "AND (dbo.Estates.Parking =";
        string ParkEnd = ")";
        string WarkAND = "AND (dbo.Estates.WareHouse = ";

        UserBLL Ubll = new UserBLL();
        public User LoggedInUser = new User();
        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ubll.Access(LoggedInUser, "بخش جستجو ", 4))
            {

                DialogResult dr = msgBox.MyShowDialog("اخطار", "درصوردت حذف مشتری تمام اطلاعات مشتری حذف میشود \nآیا مطمئن هستید که میخواهید حذف کنید؟", "", true, true);

                if (dr == DialogResult.Yes)
                {

                    msgBox.MyShowDialog("اطلاعیه", Ebll.Delete(id), "", false, false);
                    ShowDataGridview();
                }

            }
            else
            {
                msgBox.MyShowDialog("اخطار", "شما دسترسی به این قسمت را ندارید", "", false, true);
            }


        }

        private void نمایشکاملاطلاعاتملکToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estate es = Ebll.Read(id);
            Customer cu = Cbll.Read(idCU);

            bool sale = es.Sale, Rent = es.Rental, Presell = es.Presell,EXChange=es.Exchange, Construction=es.Construction,ProductionLicense=es.ProductionLicense, Parking=es.Parking, Warehouse=es.WareHouse, Elevator=es.Elevator, Pilot=es.Pilot;
            // MessageBox.Show(cu.NameFamily);
            string PropertyType = es.PropertyType, CUName = cu.NameFamily, CUPhone = cu.Phone, EXChangeType = es.TypeExchange, State=es.State, City=es.City, street=es.Street, Address=es.Address, KUsers=es.KUsers , Geghraphy=es.Geography, NFloor = es.NFloor, Floor = es.Floor, NUnitFloor = es.NUnitFloor,TypeDocument=es.TypeDoucument, Description=es.Discription;
            int Amber = es.Amber, Area=es.Area, BarMelk=es.BarMelk , Foundation=es.Foundation, NRooms=es.NRooms;
            double PriceSale = es.PriceSale, PriceAmount = es.PriceAmount, PriceRent = es.PriceRent;
            if (sale)
            {
                string StrSal = "فروشی";
                msgPM.MyShowDialog("اطلاعیه", StrSal, PropertyType, CUName, CUPhone, EXChange, Presell, EXChangeType, Construction, State, City, street, Address, Amber, KUsers, Geghraphy, Area, BarMelk, Foundation, NRooms, NFloor, Floor, NUnitFloor, TypeDocument, ProductionLicense, Parking, Warehouse, Elevator, Pilot, Description , PriceSale, PriceAmount, PriceRent, false, false);
            }
            else if (Rent)
            {
                string StrRent = "رهن و اجاره";
                msgPM.MyShowDialog("اطلاعیه", StrRent, PropertyType, CUName, CUPhone, Presell, EXChange, EXChangeType , Construction, State, City, street, Address, Amber, KUsers, Geghraphy, Area, BarMelk, Foundation, NRooms, NFloor, Floor, NUnitFloor, TypeDocument, ProductionLicense, Parking, Warehouse, Elevator, Pilot, Description, PriceSale, PriceAmount, PriceRent, false, false);
            }


        }

        private void textBoxX5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void textBoxX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == (char)Keys.Back)) { e.Handled = false; } else { e.Handled = true; }
        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells["آیدی"].Value);
            idCU  = Convert.ToInt32(dataGridViewX2.Rows[dataGridViewX2.CurrentRow.Index].Cells["آیدی مشتری"].Value);
        }

        string WarEnd = ")";
        string ElvAND = "AND (dbo.Estates.Elevator = ";
        string ElvEnd = ")";
        string PilAND = "AND (dbo.Estates.Pilot = ";
        string PilEnd = ")";
        string PReAND = "AND (dbo.Estates.PriceAmount <= ";
        string PReEnd = ")";
        string PResAND = "AND (dbo.Estates.PriceRent <= ";
        string PResEnd = ")";


        private void label4_Click(object sender, EventArgs e)
        {
          
            // msgBox.MyShowDialog("اطلاعیه", "شهر پیدا نشد", "", false, false);
            if (checkBox10.Checked | checkBox11.Checked | checkBox12.Checked | checkBox13.Checked | checkBox14.Checked | checkBox15.Checked | checkBox16.Checked)
            {
                if (checkBox10.Checked) { PType21 = checkBox10.Text; } else { PType21 = "1"; }
                if (checkBox11.Checked) { PType22 = checkBox11.Text; } else { PType22 = "1"; }
                if (checkBox12.Checked) { PType23 = checkBox12.Text; } else { PType23 = "1"; }
                if (checkBox13.Checked) { PType24 = checkBox13.Text; } else { PType24 = "1"; }
                if (checkBox14.Checked) { PType25 = checkBox14.Text; } else { PType25 = "1"; }
                if (checkBox15.Checked) { PType26 = checkBox15.Text; } else { PType26 = "1"; }
                if (checkBox16.Checked) { PType27 = checkBox16.Text; } else { PType27 = "1"; }
            }
            else
            {
                PType21 = checkBox10.Text;
                PType22 = checkBox11.Text;
                PType23 = checkBox12.Text;
                PType24 = checkBox13.Text;
                PType25 = checkBox14.Text;
                PType26 = checkBox15.Text;
                PType27 = checkBox16.Text;
            }
            if (checkBox6.Checked | checkBox7.Checked | checkBox8.Checked | checkBox9.Checked)
            {
                if (checkBox6.Checked) { Park = 1.ToString(); } else { Park = 0.ToString(); }
                if (checkBox7.Checked) { War = 1.ToString(); } else { War = 0.ToString(); }
                if (checkBox8.Checked) { Elv = 1.ToString(); } else { Elv = 0.ToString(); }
                if (checkBox9.Checked) { Pil = 1.ToString(); } else { Pil = 0.ToString(); }
                }
           
            if (comboBoxEx2.Text != ""){ST1 = comboBoxEx2.SelectedItem.ToString();}
            if (comboBoxEx3.Text != ""){CT1=comboBoxEx3.SelectedItem.ToString();}
            if (comboBoxEx12.Text != ""){
                if (comboBoxEx12.SelectedItem.ToString() == "نوساز")
                {int AMT = 0;AM = Convert.ToString(AMT);
                }
                else
                {
                    AM=comboBoxEx12.SelectedItem.ToString();                }
            }
            if (textBoxX2.Text == ""){PR = Convert.ToString(10000000000000000000); } else { PR = textBoxX2.Text; }
            if (textBoxX3.Text == "") { ARE = Convert.ToString(10000000000000000000); } else { ARE = textBoxX3.Text; }
            if (textBoxX5.Text == "") { PRe = Convert.ToString(10000000000000000000); } else { ARE = textBoxX5.Text; }
            if (textBoxX1.Text == "") { PRes = Convert.ToString(10000000000000000000); } else { ARE = textBoxX1.Text; }

  //MessageBox.Show(AMAND+AM+AMEnd);


            if (comboBoxEx11.SelectedItem.ToString() == "فروشی")
                {
                ShowDataGridview1(CM + Sal + PTypeAnd + PType21 + PTypeEnd + PTypeOR + PType22 + PTypeEnd+ PTypeOR + PType23 + PTypeEnd + PTypeOR + PType24 + PTypeEnd + PTypeOR + PType25 + PTypeEnd + PTypeOR + PType26 + PTypeEnd + PTypeOR + PType27 + PTypeEnd + ")" + STAND + ST1 + STEnd + CTAND + CT1 + CTEnd + AMAND + AM + AMEnd + PRAND + PR + PREnd + AREAND + ARE + AREEnd );
                if (checkBox6.Checked | checkBox7.Checked | checkBox8.Checked | checkBox9.Checked)
                {
                    ShowDataGridview1(CM + Sal + PTypeAnd + PType21 + PTypeEnd + PTypeOR + PType22 + PTypeEnd + PTypeOR + PType23 + PTypeEnd + PTypeOR + PType24 + PTypeEnd + PTypeOR + PType25 + PTypeEnd + PTypeOR + PType26 + PTypeEnd + PTypeOR + PType27 + PTypeEnd + ")" + STAND + ST1 + STEnd + CTAND + CT1 + CTEnd + AMAND + AM + AMEnd + PRAND + PR + PREnd + AREAND + ARE + AREEnd + ParkAND + Park + ParkEnd + WarkAND + War + WarEnd + ElvAND + Elv + ElvEnd + PilAND + Pil + PilEnd);
                }

                    dataGridViewX2.Columns["فروشی"].Visible = true;
                    dataGridViewX2.Columns["رهن و اجاره"].Visible = false;
                    dataGridViewX2.Columns["مبلغ رهن"].Visible = false;
                    dataGridViewX2.Columns["مبلغ اجاره"].Visible = false;
                }
            else if(comboBoxEx11.SelectedItem.ToString() == "رهن یا اجاره")
                {
                ShowDataGridview1(CM + Rent + PTypeAnd + PType21 + PTypeEnd + PTypeOR + PType22 + PTypeEnd + PTypeOR + PType23 + PTypeEnd + PTypeOR + PType24 + PTypeEnd + PTypeOR + PType25 + PTypeEnd + PTypeOR + PType26 + PTypeEnd + PTypeOR + PType27 + PTypeEnd + ")" + STAND + ST1 + STEnd + CTAND + CT1 + CTEnd + AMAND + AM + AMEnd + AREAND + ARE + AREEnd + PReAND + PRe + PReEnd + PResAND + PRes + PResEnd);
                if (checkBox6.Checked | checkBox7.Checked | checkBox8.Checked | checkBox9.Checked)
                {
                    ShowDataGridview1(CM + Rent + PTypeAnd + PType21 + PTypeEnd + PTypeOR + PType22 + PTypeEnd + PTypeOR + PType23 + PTypeEnd + PTypeOR + PType24 + PTypeEnd + PTypeOR + PType25 + PTypeEnd + PTypeOR + PType26 + PTypeEnd + PTypeOR + PType27 + PTypeEnd + ")" + STAND + ST1 + STEnd + CTAND + CT1 + CTEnd + AMAND + AM + AMEnd + AREAND + ARE + AREEnd + ParkAND + Park + ParkEnd + WarkAND + War + WarEnd + ElvAND + Elv + ElvEnd + PilAND + Pil + PilEnd + PReAND + PRe + PReEnd + PResAND + PRes + PResEnd);
                }

                dataGridViewX2.Columns["فروشی"].Visible =false;
                dataGridViewX2.Columns["مبلغ فروش"].Visible = false;
                dataGridViewX2.Columns["رهن و اجاره"].Visible = true;
                dataGridViewX2.Columns["مبلغ رهن"].Visible = true;
                dataGridViewX2.Columns["مبلغ اجاره"].Visible = true;
            }
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label4_Click(sender, e);
        }
        
        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
        }

       

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
         
            }

        
        private void comboBoxEx11_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (comboBoxEx11.SelectedItem.ToString() == "فروشی")
            {
                groupBox4.Visible = true;
                groupBox4.Enabled = true;
                groupBox5.Visible = false;
                groupBox5.Enabled = false;
                groupBox2.Enabled = true;
              
                
            }
            else if (comboBoxEx11.SelectedItem.ToString() == "رهن یا اجاره")
            {
                groupBox5.Visible = true;
                groupBox5.Enabled = true;
                groupBox4.Visible = false;
                groupBox4.Enabled = false;
                groupBox2.Enabled=true;
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }
    }
}
