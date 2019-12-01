using DesarrolloBE;
using DesarrolloDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesarrolloBL.MedicalReference;

namespace DesarrolloBL
{
    public class PuestoTrabajoBL
    {


       

        CalculatorSoapClient calculator = null;
        public List<Puesto_trabajo> getReportByParams(string dni, string name)
        {
            return PuestoTrabajoDAO.getReportByParams(dni, name);
        }

        public int loadEmployees(string company, string location, string area, List<Puesto_trabajo> lst)
        {
            int paramCompany = Convert.ToInt32(company);
            int paramLocation = Convert.ToInt32(location);
            int paramArea = Convert.ToInt32(area);

             

            return PuestoTrabajoDAO.loadEmployees(paramCompany, paramLocation, paramArea, lst);
        }

        public int processEmployees(string company, string location, string area, List<Puesto_trabajo> lst)
        {


            int paramCompany = Convert.ToInt32(company);
            int paramLocation = Convert.ToInt32(location);
            int paramArea = Convert.ToInt32(area);


            CalculatorSoap a = new CalculatorSoapClient();
            
  
            foreach (var item in lst)
            {

                int visual = Convert.ToInt32(item.MedidaVisual);
                int audio = Convert.ToInt32(item.MedidaAuditiva);
                item.MedidaVisual = a.Divide(visual, 2);
                item.MedidaAuditiva = a.Divide(audio, 2);

                if (item.MedidaVisual > (decimal)1 && item.MedidaVisual < 5)
                {
                    item.ResultadoMedidaVisual = "Bajo";
                } else if (item.MedidaVisual >= (decimal)5 && item.MedidaVisual < 10)
                {
                    item.ResultadoMedidaVisual = "Medio";
                }
                else if (item.MedidaVisual >= (decimal)10 && item.MedidaVisual < 15)
                {
                    item.ResultadoMedidaVisual = "Alto";
                }

                // auditivo

                if (item.MedidaAuditiva > (decimal)10 && item.MedidaAuditiva < 20)
                {
                    item.ResultadoMedidaAuditiva = "Bajo audio";
                }
                else if (item.MedidaAuditiva >= (decimal)20 && item.MedidaAuditiva < 30)
                {
                    item.ResultadoMedidaAuditiva = "Medio audio";
                }
                else if (item.MedidaAuditiva >= (decimal)30 && item.MedidaAuditiva < 40)
                {
                    item.ResultadoMedidaAuditiva = "Alto Khe?";
                }
            }

            return PuestoTrabajoDAO.processEmployees(paramCompany, paramLocation, paramArea, lst);
        }
    }
}
