using DesarrolloBE;
using DesarrolloDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloBL
{
    public class CompanyBL
    {
        public int addCompany(Empresa e)
        {
            return CompanyDAO.addCompany(e);

        }

    }
}
