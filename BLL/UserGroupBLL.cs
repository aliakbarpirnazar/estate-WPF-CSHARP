using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class UserGroupBLL
    {
        UserGroupDAL dal = new UserGroupDAL();
        public string Create(UserGroup ug)
        {
            return dal.Create(ug);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public UserGroup ReadN(string s)
        {
            return dal.ReadN(s);
        }
        public List<string> ReadNam()
        {
            return dal.ReadNam();
        }

        }
}
