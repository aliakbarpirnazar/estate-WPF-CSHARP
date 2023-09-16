using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data;

namespace DAL
{
    public class EstateDAL
    {
        DB db = new DB();
        public string Create(Estate f,Customer c)
        {
            try
            {
                f.Customers = db.Customers.Find(c.id);
                db.Estates.Add(f);
                db.SaveChanges();
                return "ثبت اطلاعات ملک با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با مشکل مواجه شد\n" + e.Message;
            }
        }
       
        public DataTable Read()
        {
            string cmd = "SELECT dbo.Estates.id AS آیدی, dbo.Estates.Sale AS فروشی, dbo.Estates.Rental AS [رهن و اجاره], dbo.Estates.PropertyType AS [نوع ملک], dbo.Estates.Presell AS [پیش فروش], dbo.Estates.Construction AS مشارک, dbo.Estates.Exchange AS معاوضه, dbo.Estates.TypeExchange AS[توضیحات معاوضه], dbo.Estates.State AS استان, dbo.Estates.City AS شهر, dbo.Estates.Street AS منطقه, dbo.Estates.Address AS آدرس,  dbo.Estates.PriceAmount AS[مبلغ رهن], dbo.Estates.PriceRent AS[مبلغ اجاره], dbo.Estates.PriceSale AS[مبلغ فروش], dbo.Estates.Amber AS عمربنا, dbo.Estates.KeyNot AS[کلید نخورده], dbo.Estates.KUsers AS کاربری,  dbo.Estates.Geography AS جغرافیا, dbo.Estates.Area AS مساحت, dbo.Estates.BarMelk AS برملک, dbo.Estates.Foundation AS زیربنا, dbo.Estates.NRooms AS[تعداد اتاق], dbo.Estates.NFloor AS[تعداد طبقات], dbo.Estates.Floor AS طبقه,  dbo.Estates.NUnitFloor AS[تعداد واحد], dbo.Estates.TypeDoucument AS[نوع سند], dbo.Estates.ProductionLicense AS[پروانه ساخت], dbo.Estates.Parking AS پارکینگ, dbo.Estates.WareHouse AS انباری,  dbo.Estates.Elevator AS آسانسور, dbo.Estates.Pilot AS پیلوت, dbo.Estates.Discription AS توضیحات, dbo.Customers.NameFamily AS[نام مشتری], dbo.Estates.RegDate AS [تاریخ ثبت], dbo.Customers.id AS[آیدی مشتری] FROM dbo.Estates INNER JOIN dbo.Customers ON dbo.Estates.Customers_id = dbo.Customers.id ORDER BY [تاریخ ثبت] DESC";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }  
        public DataTable Read(string s)
        {
            string cmd = s;
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public Estate Read(int id)
        {
            return db.Estates.Where(i => i.id == id).FirstOrDefault();
        }

        public string Delete(int id)
        {
            var q = db.Estates.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    db.Estates.Remove(q);
                    db.SaveChanges();
                    return "شهر موردنظر حذف شد";
                }
                else
                    return "شهر مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "حذف شهر با مشکل مواجه بود \n" + e.Message;
            }
        }
       
    }
}
