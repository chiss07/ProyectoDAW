using DesarrolloBE;
using DesarrolloDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloBL
{
    public class UserBL
    {
        public Usuario validateUser(string user, string password)
        {
            return UserDAO.validateUser(user, password);
        }

        public int addUser(Usuario u)
        {
            return UserDAO.addUser(u);
        }
    }
}
