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
    public class CityDAL
    {

        DB db = new DB();
        public string Create(City c,State s)
        {
            try
            {
                c.States = db.States.Find(s.id);
                db.Cities.Add(c);
                db.SaveChanges();
                return "ثبت اطلاعات شهر با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با مشکل مواجه شد\n" + e.Message;
            }
        }
        public int Readid(string s)
        {
            var q = db.Cities.Where(i => i.Name == s).FirstOrDefault();
            try
            {
                if (q != null)
                {


                    return q.id;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }


        }
        public City ReadC(string s)
        {
            return db.Cities.Where(i => i.Name == s).SingleOrDefault();
        }
        public bool Read(City c)
        {
            var q = db.Cities.Where(i => c.Name == i.Name);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;


        }
        public DataTable Read()
        {
            string cmd = "SELECT  dbo.Cities.id AS آیدی, dbo.States.Name AS [نام استان], dbo.Cities.Name AS [نام شهر] FROM dbo.Cities INNER JOIN dbo.States ON dbo.Cities.States_id = dbo.States.id";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }


        public City Read(int id)
        {
            return db.Cities.Where(i => i.id == id).FirstOrDefault();
        }
        public DataTable ReadCity(int s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.SearchCity";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            cmd.Parameters.AddWithValue("@search", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable ReadCityName(int s)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "dbo.SearchCityName";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            cmd.Parameters.AddWithValue("@search", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public List<string> ReadName(int s)
        {
            
            return db.Cities.Where(i=>i.States.id==s).Select(i => i.Name).ToList();
        }


        public string Update(City c, int id)
        {
            var q = db.Cities.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = c.Name;
                    db.SaveChanges();
                    return "ویرایش شهر موفق بود";
                }
                else
                    return "شهر مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.Cities.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    db.Cities.Remove(q);
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
