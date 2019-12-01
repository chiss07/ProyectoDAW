using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesarrolloBE;

namespace DesarrolloDAL
{
    public class CompanyDAO
    {
        public static Empresa getById(int id)
        {
            Empresa retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    retorno = data.Empresa.Where(x => x.Id_Em == id ).FirstOrDefault();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                // throw ex;
            }
            return retorno;
        }

        public static Empresa getByName(string name)
        {
            Empresa retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    retorno = data.Empresa.Where(x => x.Razon_social == name).FirstOrDefault();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                // throw ex;
            }
            return retorno;
        }

        public static int addCompany(Empresa e)
        {
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Configuration.LazyLoadingEnabled = false;
                    data.Empresa.Add(e);
                    data.SaveChanges();
                    return e.Id_Em;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return -1;
            }
        }
    }
}
