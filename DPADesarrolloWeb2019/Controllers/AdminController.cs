using DesarrolloBE;
using DesarrolloBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPADesarrolloWeb2019.Controllers
{
    public class AdminController : Controller
    {
        UserBL userBL = new UserBL();
        CompanyBL companyBL = new CompanyBL();
        public ActionResult Administration()
        {
            return View();
        }

        [HttpPost]
        public JsonResult addCustomerData(string companyname, string companyid, string username, string userlogin, string userpassword)
        {

            try
            {
                int createdCompanyId = companyBL.addCompany(new Empresa()
                {
                    Razon_social = companyname,
                    Ruc = companyid,
                    Fecha_creado = DateTime.Now
                    
                });

                userBL.addUser(new Usuario()
                {
                    Id_Em = createdCompanyId,
                    Nombres = username,
                    Apellidos = username,
                    usuario1 = userlogin,
                    clave = userpassword
                });
                return Json(1);
            }
            catch (Exception)
            {

                throw;
                return Json(-1);
            }
           
           
           
           
        }


 
    }
}