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
    public class CityBLL
    {
        CityDAL dal = new CityDAL();
        public string Create(City c,State s)
        {
            if (dal.Read(c))
            {
                return dal.Create(c,s);
            }
            else
            {
                return "استان قبلا ثبت شده است";
            }
        }
        public City ReadC(string s)
        {
            return dal.ReadC(s);
        }
        public DataTable ReadCity(int s)
        { 
        return dal.ReadCity(s);
        }
        public DataTable ReadCityName(int s)
        { 
        return dal.ReadCityName(s);
        }
        public List<string> ReadName(int s)
        {
            return dal.ReadName(s);
        }
        public int Readid(string s)
        {
            return dal.Readid(s);
        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public City Read(int id)
        {
            return dal.Read(id);
        }
        public string Update(City c, int id)
        {
            return dal.Update(c, id);

        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
