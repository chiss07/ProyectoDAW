using DesarrolloBE;
using DesarrolloDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloBL
{
    public class AreaBL
    {
        public List<Area> getAreaByLocationId(int locationId)
        {
            return AreaDAO.getAreaByLocationId(locationId);
        }

        public int addArea(string locationId, string name)
        {
            int locationid = Convert.ToInt32(locationId);
            Area l = new Area()
            {
                Nombre = name,
                Id_Loc = locationid
            };
            return AreaDAO.addArea(l);
        }
    }
}
