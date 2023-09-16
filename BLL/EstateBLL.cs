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
    public class EstateBLL
    {

        EstateDAL dal = new EstateDAL();
        public string Create(Estate e,Customer c)
        {
                  return dal.Create(e,c);
           
        }
       
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Read(string s)
        {
            return dal.Read(s);
        }

        public Estate Read(int id)
        {
            return dal.Read(id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
       
    }
}
