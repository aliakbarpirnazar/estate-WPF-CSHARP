using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserGroupDAL
    {
        DB db = new DB();
        public string Create(UserGroup ug)
        {
            try
            {
                db.userGroups.Add(ug);
                db.SaveChanges();
                return "ثبت گروه کاربری با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "در ثبت گروه کاربری کشکل به وجود آمده است \n" + e.Message;
            }
        }
        public DataTable Read()
        {
            string cmd = "SELECT id AS آیدی, Title AS [نام گروه] FROM dbo.UserGroups";
            SqlConnection con = new SqlConnection("Data Source =.;Initial Catalog = DBESTATE ;Integrated Security = True");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public List<string> ReadNam()
        {
            return db.userGroups.Select(i => i.Title).ToList();
        }
        public UserGroup ReadN(string s)
        {
            return db.userGroups.Where(i => i.Title == s).SingleOrDefault();
        }
        public string Update(UserAccessRole c, int id)
        {
            var q = db.userAccessRoles.Where(i => i.UserGroup.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Section = c.Section;
                    q.CanEnter = c.CanEnter;
                    q.CanCreate = c.CanCreate;
                    q.CanUpdate = c.CanUpdate;
                    q.CanDelete = c.CanDelete;
                    db.SaveChanges();
                    return "ویرایش اطلاعات موفق بود";
                }
                else
                    return "کاربر مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "ویرایش اطلاعات با مشکل مواجه بود \n" + e.Message;
            }
        }

    }
}
