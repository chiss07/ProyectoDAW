using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesarrolloBE;
namespace DesarrolloDAL
{
    public class UserDAO
    {

        public static Usuario validateUser(string user, string password)
        {
            Usuario retorno = null;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    retorno = data.Usuario.Where(x => x.usuario1 == user && x.clave == password).FirstOrDefault();
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return retorno;
        }


        public static int addUser(Usuario param)
        {
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {                     
                    data.Usuario.Add(param);
                    data.SaveChanges();
                    return param.Id_Usu;
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
