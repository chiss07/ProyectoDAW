using DesarrolloBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDAL
{
    public static class AreaDAO
    {

        public static List<Area> getAreaByLocationId(int locationId)
        {
            List<Area> retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Configuration.LazyLoadingEnabled = false;
                    retorno = data.Area.Where(x => x.Id_Loc == locationId).ToList();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                // throw ex;
            }
            return retorno;
        }

        public static int addArea(Area a)
        {
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Area.Add(a);
                    return data.SaveChanges();
                }
            }
            catch
            {

                return -1;
            }
        }
    }
}
