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
    public class TrustGroupBLL
    {
        TrustGroupDAL dal = new TrustGroupDAL();
        public string Create(TrustGroup c)
        {
            if (dal.Read(c))
            {
                return dal.Create(c);
            }
            else
            {
                return "دسته بندی قبلا با این نام ثبت شده است \n لطفا با نام جستجو کنید \n یا در منو حذف شده جستجو کنید.";
            }
        }
        //public DataTable Read(string s, int index)
        //{
        //    return dal.Read(s, index);
        //}

        //public DataTable SRead(string s, int index)
        //{
        //    return dal.SRead(s, index);
        //}
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable DelRead()
        {
            return dal.DelRead();
        }
        //public List<string> ReadPhone()
        //{ return dal.ReadPhone(); }
        public List<string> ReadName()
        {
            return dal.ReadName();
        }
        public TrustGroup Read(int id)
        {
            return dal.Read(id);
        }
        public string Update(TrustGroup c, int id)
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
      
        public TrustGroup ReadC(string s)
        {
            return dal.ReadC(s);
        }

    }
}
