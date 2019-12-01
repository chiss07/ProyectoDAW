using DesarrolloBE;
using DesarrolloBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPADesarrolloWeb2019.Controllers
{
    public class ReportsController : Controller
    {
        private PuestoTrabajoBL puestotrabajo = new PuestoTrabajoBL();

        [HttpPost]
        public JsonResult getReport(string id, string name, string companyId)
        {
            string nameParam = (name != null) ? name.ToLower(): null;
            List<Puesto_trabajo> l = puestotrabajo.getReportByParams(id, nameParam);
            return Json(l); 
        }

        public ActionResult RIndex()
        {
            return View();
        }
    }
}