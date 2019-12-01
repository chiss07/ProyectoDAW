using DesarrolloBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesarrolloDAL
{
    public static class PuestoTrabajoDAO
    {

        public static List<Puesto_trabajo> getReportByParams(string dni, string name)
        {
            List<Puesto_trabajo> retorno = null;
            try
            {

                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    data.Configuration.LazyLoadingEnabled = false;

                    if (string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(name))
                    {
                        retorno = data.Puesto_trabajo.ToList();
                        return retorno;
                    }
                    else if(string.IsNullOrEmpty(dni) && !string.IsNullOrEmpty(name))
                    {
                        retorno = data.Puesto_trabajo.Where(x=>x.NombreCompleto.ToLower().Contains(name)).ToList();
                        return retorno;
                    }
                    else if (!string.IsNullOrEmpty(dni) && string.IsNullOrEmpty(name))
                    {
                        retorno = data.Puesto_trabajo.Where(x => x.Documento_identidad.ToLower().Contains(dni)).ToList();
                        return retorno;
                    }
                    else
                    {
                        retorno = data.Puesto_trabajo.Where(x => x.Documento_identidad.Contains(dni) ||
                            x.NombreCompleto.ToLower().Contains(name)).ToList();
                        return retorno;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                 //throw ex;
            }
            return retorno;
        }

        public static int loadEmployees(int company, int location, int area, List<Puesto_trabajo> lst)
        {
            int procesados = 0;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    foreach (var item in lst)
                    {
                        item.Id_Ar = area;
                        item.Id_Em = company;
                        item.Id_Loc = location;
                        data.Puesto_trabajo.Add(item);
                        data.SaveChanges();
                        procesados++;
                    }
                    
                }
            }
            catch
            {

                procesados = -1;
            }

            return procesados;

        }



        public static int processEmployees(int company, int location, int area, List<Puesto_trabajo> lst)
        {

            int procesados = 0;
            try
            {
                using (var data = new DB_SISTEMAS_DAWEntities())
                {
                    foreach (var item in lst)
                    {
                        Puesto_trabajo stored = data.Puesto_trabajo.Where(
                            x => x.Documento_identidad == item.Documento_identidad && 
                            x.Id_Loc == location && 
                            x.Id_Ar == area
                            ).FirstOrDefault();

                        stored.ResultadoMedidaVisual = item.ResultadoMedidaVisual;
                        stored.ResultadoMedidaAuditiva = item.ResultadoMedidaAuditiva;
                        stored.MedidaVisual = item.MedidaVisual;
                        stored.MedidaAuditiva = item.MedidaAuditiva;
                        data.SaveChanges();
                        procesados++;
                    }

                }
            }
            catch
            {

                procesados = -1;
            }

            return procesados;

        }
    }
}
