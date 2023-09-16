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
    public class StateBLL
    {
        StateDAL dal = new StateDAL();
        public string Create(State c)
        {
            if (dal.Read(c))
            {
                return dal.Create(c);
            }
            else
            {
                return "استان قبلا ثبت شده است";
            }
        }
        public State ReadC(string s)
        {
            return dal.ReadC(s);
        }
   
        public DataTable Read()
        {
            return dal.Read();
        }

        public List<string> ReadName()
        { 
            return dal.ReadName(); 
        }
        public State Read(int id)
        {
            return dal.Read(id);
        }
        public string Update(State c, int id)
        {
            return dal.Update(c, id);

        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public int Readid(string s)
        {
            return dal.Readid(s);
        }

        }
}
