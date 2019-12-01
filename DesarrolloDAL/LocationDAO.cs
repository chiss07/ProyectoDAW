using DesarrolloBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDAL
{
    public static class LocationDAO
    {
        public static List<Local> getLocationByCompanyId(int company)
        {
            List<Local> retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Configuration.LazyLoadingEnabled = false;
                    retorno = data.Local.Where(x => x.Id_Em == company).ToList();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            return retorno;
        }


        public static Local getLocationById(int localId)
        {
            Local retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Configuration.LazyLoadingEnabled = false;
                    retorno = data.Local.Where(x => x.Id_Loc == localId).FirstOrDefault();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public static int addLocal(Local param)
        {
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    param.Telefono = "00";
                    data.Local.Add(param);
                    return data.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return -1;
            }
        }


        public static int updateLocal(Local param)
        {    
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    Local localActual = data.Local.Where(x => x.Id_Loc == param.Id_Loc).FirstOrDefault();

                    localActual.Nombre = param.Nombre;
                    localActual.Direccion = param.Direccion;
                    localActual.Telefono = param.Telefono;
                    localActual.Encargado = param.Encargado;
                    return data.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
