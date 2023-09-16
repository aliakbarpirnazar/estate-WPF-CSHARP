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
    public class TrustGroupDAL
    {
        DB db = new DB();
        public string Create(TrustGroup c)
        {
            try
            {
                db.trustGroups.Add(c);
                db.SaveChanges();
                return "ثبت اطلاعات دسته بندی با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با مشکل مواجه شد\n" + e.Message;
            }
        }
        public bool Read(TrustGroup c)
        {
            var q = db.trustGroups.Where(i => c.NameTrust == i.NameTrust);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;


        }
        public DataTable Read()
        {
            string cmd = "SELECT id AS [آیدی], NameTrust AS [نام گروه دسته بندی] FROM dbo.trustGroups WHERE(DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable DelRead()
        {
            string cmd = "SELECT id AS [آیدی], NameTrust AS [نام دسته بندی FROM dbo.trustGroups WHERE(DeleteStatus = 1)";
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
        public TrustGroup ReadC(string s)
        {
            return db.trustGroups.Where(i => i.NameTrust == s).SingleOrDefault();
        }

        public TrustGroup Read(int id)
        {
            return db.trustGroups.Where(i => i.id == id).FirstOrDefault();
        }
        public List<string> ReadName()
        {
            return db.trustGroups.Where(i => i.DeleteStatus == false).Select(i => i.NameTrust).ToList();
        }
      
        private SqlConnection SqlConnection(string v)
        {
            throw new NotImplementedException();
        }

        public string Update(TrustGroup c, int id)
        {
            var q = db.trustGroups.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.NameTrust = c.NameTrust;
                   
                    db.SaveChanges();
                    return "ویرایش اطلاعات مشتری موفق بود";
                }
                else
                    return "مشتری مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.trustGroups.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "دسته بندی موردنظر حذف شد";
                }
                else
                    return "دسته بندی مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "حذف اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Recovery(int id)
        {
            var q = db.trustGroups.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeleteStatus = false;
                    db.SaveChanges();
                    return "دسته بندی موردنظر بازیابی شد";
                }
                else
                    return "دسته بندی مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "بازیابی اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
    }
}
