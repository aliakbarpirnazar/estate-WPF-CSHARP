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

namespace EstateApp
{
    public class MsgPMClass
    {
        public DialogResult MyShowDialog(string Title, string FaInfo, string PropertyType, string CUName, string CuPhone, bool Presell, bool EXChange, string EXChangeType, bool Construction, string State, string City, string street, string Address, int Amber, string KUsers, string Geghraphy, int Area, int BarMelk, int Foundation, int NRooms, string NFloor, string Floor, string NUnitFloor, string TypeDocument, bool ProductionLicense, bool Parking, bool Warehouse, bool Elevator, bool Pilot, string Description, double PriceSale, double PriceAmount, double PriceRent, bool Buttons, bool Type)
        {
            MsgPM m = new MsgPM();
            m.labelX2.Text = Title;
            m.labelX4.Text = PropertyType;
            m.labelX5.Text = CUName;
            m.labelX6.Text = CuPhone;
            m.labelX3.Text = FaInfo;
            if (Presell) { m.labelX7.Text = "دارد"; } else { m.labelX7.Text = "ندارد"; }
            if (EXChange) { m.labelX8.Text = "دارد"; } else { m.labelX8.Text = "ندارد"; }
            m.labelX9.Text = EXChangeType;
            if (Construction) { m.labelX10.Text = "دارد"; } else { m.labelX10.Text = "ندارد"; }
            m.labelX11.Text = State;
            m.labelX12.Text = City;
            m.labelX13.Text = street;
            m.labelX14.Text = Address;
            m.labelX15.Text = Amber.ToString();
            m.labelX17.Text = KUsers;
            m.labelX18.Text = Geghraphy;
            m.labelX19.Text = Area.ToString();
            m.labelX20.Text = BarMelk.ToString();
            m.labelX21.Text = Foundation.ToString();
            m.labelX22.Text = NRooms.ToString();
            m.labelX23.Text = NFloor;
            m.labelX24.Text = Floor;
            m.labelX25.Text = NUnitFloor;
            m.labelX26.Text = TypeDocument;
            if (ProductionLicense) { m.labelX27.Text = "دارد"; } else { m.labelX27.Text = "ندارد"; }
            if (Parking) { m.labelX28.Text = "دارد"; } else { m.labelX28.Text = "ندارد"; }
            if (Warehouse) { m.labelX29.Text = "دارد"; } else { m.labelX29.Text = "ندارد"; }
            if (Elevator) { m.labelX30.Text = "دارد"; } else { m.labelX30.Text = "ندارد"; }
            if (Pilot) { m.labelX31.Text = "دارد"; } else { m.labelX31.Text = "ندارد"; }
            m.labelX32.Text = Description;
            if (FaInfo == "فروشی")
            {
                m.labelX34.Text = PriceSale.ToString("N0");
                m.labelX33.Text = "مبلغ فروش :";
                m.labelX35.Visible = false;
                m.labelX36.Visible = false;

            }
            else if(FaInfo == "رهن و اجاره")
            {
                m.labelX34.Text = PriceAmount.ToString("N0");
                m.labelX36.Text = PriceRent.ToString("N0");
                m.labelX33.Text = "مبلغ رهن :";
                m.labelX35.Visible = true;
                m.labelX36.Visible = true;
            }

            if (Buttons)
            {
                m.buttonX1.Text = "خیر";
                m.buttonX2.Text = "بله";
            }
            else
            {
                m.buttonX2.Visible = false;
                m.buttonX1.Text = "خروج";
            }
            if (Type)
            {
                m.BackColor = Color.FromArgb(242, 69, 29);
                m.pictureBox1.Image = Properties.Resources.Warning;
            }

            m.ShowDialog();
            return m.DialogResult;
        }
    }
}
