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
    public class SearchControlDAL
    {
        DB db = new DB();


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
