using DesarrolloBE;
using DesarrolloDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloBL
{
    public class LocationBL
    {
        public List<Local> getLocationByCompanyId(int company)
        {
            return LocationDAO.getLocationByCompanyId(company);
        }

        public Local getLocationById(int localID)
        {
            return LocationDAO.getLocationById(localID);
        }

        public int addLocation(string nombre, string direccion, string encargado, string companyId)
        {
            Local l = new Local()
            {
                Nombre = nombre,
                Direccion = direccion,
                Encargado = encargado,
                Id_Em = Convert.ToInt32(companyId)
            };
            return LocationDAO.addLocal(l);
        }


        public int updateLocation(int locationId, string nombre, string direccion, string encargado)
        {
            Local l = new Local()
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = "0",
                Encargado = encargado,
                Id_Loc = locationId
            };
            return LocationDAO.updateLocal(l);
        }

    }
}
