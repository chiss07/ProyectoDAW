using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPADesarrolloWeb2019.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Administration()
        {
            return View();
        }

        [HttpPost]
        public JsonResult addEmpresa(string nombre, string ruc)
        {

           
                return Json(-1);
           
        }

        [HttpPost]
        public JsonResult addUserCredentials(string username, string userlogin, string userpassword)
        {


            return Json(-1);

        }
    }
}