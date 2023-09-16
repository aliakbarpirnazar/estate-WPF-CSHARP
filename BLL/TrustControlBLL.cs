using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data;

namespace BLL
{
    public class TrustControlBLL
    {

        TrustControlDAL dal = new TrustControlDAL();
        public string Create(Trust t,Customer c)
        {
            if (dal.Read(t))
            {
                return dal.Create(t,c);
            }
            else
            {
                return "امانت قبلا با این شماره ثبت نام کرده است \n لطفا با شماره جستجو کنید \n یا در منو حذف شده جستجو کنید.";
            }
        }
       
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable DelRead()
        {
            return dal.DelRead();
        }
       
        public Trust Read(int id)
        {
            return dal.Read(id);
        }
        public string Update(Trust c, int id)
        {
            return dal.Update(c, id);

        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string Recovery(int id)
        {
            return dal.Recovery(id);
        }
      
    }
}
