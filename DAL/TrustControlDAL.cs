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
    public class TrustControlDAL
    {
        DB db = new DB();
        public string Create(Trust t, Customer c)
        {
            try
            {
                t.Customers = db.Customers.Find(c.id);
                db.Trusts.Add(t);
                db.SaveChanges();
                return "ثبت اطلاعات با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با مشکل مواجه شد\n" + e.Message;
            }
        }
        public bool Read(Trust c)
        {
            var q = db.Trusts.Where(i => c.Discription == i.Discription);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;


        }
        public DataTable Read()
        {
            string cmd = "SELECT        dbo.Trusts.id AS آیدی, dbo.Customers.NameFamily AS [نام مشتری], dbo.Customers.Phone AS [شماره همراه] , dbo.Trusts.Title AS موضوع, dbo.Trusts.Discription AS توضیحات, dbo.Trusts.RegDate AS [تاریخ ثبت] FROM dbo.Customers INNER JOIN dbo.Trusts ON dbo.Customers.id = dbo.Trusts.Customers_id WHERE(dbo.Trusts.DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable DelRead()
        {
            string cmd = "SELECT id AS [آیدی], trustGroups AS [دسته بندی], Discription AS [توضیحات] FROM dbo.Customers WHERE(DeleteStatus = 1)";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        //public DataTable Read(string s, int index)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    if (index == 0)
        //    {
        //        cmd.CommandText = "dbo.SearchCustomer";
        //    }
        //    else if (index == 1)
        //    {
        //        cmd.CommandText = "dbo.SearchCustomerName";
        //    }
        //    else if (index == 2)
        //    {
        //        cmd.CommandText = "dbo.SearchCustomerPhone";
        //    }
        //    SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");

        //    cmd.Parameters.AddWithValue("@search", s);
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    var sqladapter = new SqlDataAdapter();
        //    sqladapter.SelectCommand = cmd;
        //    var commandBuilder = new SqlCommandBuilder(sqladapter);
        //    var ds = new DataSet();
        //    sqladapter.Fill(ds);
        //    return ds.Tables[0];
        //}
        //public DataTable SRead(string s, int index)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "dbo.SearchCustomerDel";
        //    SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");

        //    cmd.Parameters.AddWithValue("@search", s);
        //    cmd.Connection = con;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    var sqladapter = new SqlDataAdapter();
        //    sqladapter.SelectCommand = cmd;
        //    var commandBuilder = new SqlCommandBuilder(sqladapter);
        //    var ds = new DataSet();
        //    sqladapter.Fill(ds);
        //    return ds.Tables[0];

        //}
      

        public Trust Read(int id)
        {
            return db.Trusts.Where(i => i.id == id).FirstOrDefault();
        }
       
        private SqlConnection SqlConnection(string v)
        {
            throw new NotImplementedException();
        }

        public string Update(Trust c, int id)
        {
            var q = db.Trusts.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Discription = c.Discription;
                    q.Title = c.Title;
                    db.SaveChanges();
                    return "ویرایش اطلاعات موفق بود";
                }
                else
                    return "امانت مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Trusts.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "امانت موردنظر حذف شد";
                }
                else
                    return "امانت مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "حذف اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Recovery(int id)
        {
            var q = db.Trusts.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = false;
                    db.SaveChanges();
                    return "امانت موردنظر بازیابی شد";
                }
                else
                    return "امانت مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "بازیابی اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
    }
}
