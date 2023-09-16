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
    public class StateDAL
    {
        DB db = new DB();
        public string Create(State c)
        {
            try
            {
                db.States.Add(c);
                db.SaveChanges();
                return "ثبت اطلاعات استان با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "ثبت اطلاعات با مشکل مواجه شد\n" + e.Message;
            }
        }
        public List<string> ReadName()
        {
            return db.States.Select(i => i.Name).ToList();
        }
        public int Readid(string s)
        {
            var q = db.States.Where(i => i.Name == s).FirstOrDefault();
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

        public State ReadC(string s)
        {
            return db.States.Where(i => i.Name == s).SingleOrDefault();
        }
        public bool Read(State c)
        {
            var q = db.States.Where(i => c.Name == i.Name);
            if (q.Count() == 0)
            {
                return true;
            }
            else
                return false;


        }
        public DataTable Read()
        {
            string cmd = "SELECT id AS [آیدی], Name AS [نام استان] FROM dbo.States";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
      

        public State Read(int id)
        {
            return db.States.Where(i => i.id == id).FirstOrDefault();
        }
    
       


        public string Update(State c, int id)
        {
            var q = db.States.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = c.Name;
                    
                    db.SaveChanges();
                    return "ویرایش استان موفق بود";
                }
                else
                    return "استان مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.States.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    db.States.Remove(q);
                    db.SaveChanges();
                    return "استان موردنظر حذف شد";
                }
                else
                    return "استان مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "حذف استان با مشکل مواجه بود \n" + e.Message;
            }
        }
    }
}
