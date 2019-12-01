using DesarrolloBE;
using DesarrolloBL;
using DPADesarrolloWeb2019.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DPADesarrolloWeb2019.Controllers
{
    public class HomeController : Controller
    {

        private UserBL userlogic = new UserBL();
        private PuestoTrabajoBL puestoTrabajo = new PuestoTrabajoBL();
        private LocationBL location = new LocationBL();
        private AreaBL area = new AreaBL();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Administration()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session[Constants.SESSION_USER_NAME] = null;
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Login(string usuario, string password)
        {
            Usuario resultado = userlogic.validateUser(usuario, password);
            //consulta bd para saber si el usuario es super admin o usuario
            if (usuario == Constants.ADMIN_USERNAME_KEYWORD && password == Constants.ADMIN_PASSWORD_KEYWORD)
            {
                Session[Constants.SESSION_USER_NAME] = Constants.ADMIN_USERNAME_KEYWORD;
                Session[Constants.SESSION_COMPANY_ID] = Constants.ADMIN_USERNAME_KEYWORD;
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Json(1); //la respuesta debeá ser diferente para super admin y para usuario para que se reconozca en el front
            }else if (/*usuario == "user" && password == "user"*/ resultado != null)
            {
                Session[Constants.SESSION_USER_NAME] = resultado.usuario1;
                Session[Constants.SESSION_COMPANY_ID] = resultado.Id_Em;
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Json(2); //la respuesta debeá ser diferente para super admin y para usuario para que se reconozca en el front
            }
            else
            {
                return Json(-1);
            }
        }


        #region

        [HttpPost]
        public JsonResult addLocal(string localId, string nombre, string direccion, string encargado, string companyId)
        {
        
            int r = 1;
            if(localId.Equals("-1"))
            {
                r = location.addLocation(nombre, direccion, encargado, companyId);
            }
            else
            {
                //int locationId, string nombre, string telefono, string encargado
                r = location.updateLocation(Convert.ToInt32(localId), nombre, direccion, encargado);
            }
            
            if (r > 0) {
                return Json(1);
            }
            else
            {
                return Json(-1);
            }
        }

        [HttpPost]
        public JsonResult addArea(string locationId, string nombre)
        {
            int r = area.addArea(locationId, nombre);
            return Json(1);
        }


        [HttpPost]
        public JsonResult getLocationByCompanyId(string companyId)
        {
            int param = Convert.ToInt32(companyId);
            List<Local> lstLocal = location.getLocationByCompanyId(param);
            return Json(lstLocal);
        }

        [HttpPost]
        public JsonResult getLocationById(string localID)
        {
            int param = Convert.ToInt32(localID);
            Local lstLocal = location.getLocationById(param);
            return Json(lstLocal);
        }

        [HttpPost]
        public JsonResult getAreaByLocationId(string locationId)
        {
            int param = Convert.ToInt32(locationId);
            List<Area> lstLocal = area.getAreaByLocationId (param);
            return Json(lstLocal);
        }
        #endregion



        #region UploadFile

        [HttpPost]
        public ActionResult UploadFiles(string username)
        {
            string company = Request.Form.Get(Constants.PORCESSING_DATA_COMPANY);
            string location = Request.Form.Get(Constants.PORCESSING_DATA_LOCATION);
            string area = Request.Form.Get(Constants.PORCESSING_DATA_AREA);

            int process = 0;
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            if(!file.FileName.Contains(".txt") && !file.FileName.Contains(".csv"))
                            {
                                return Json("Imposible procesar formatos desconocidos. Solo se permite CSV y TXT. Ok?");
                            }
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath(Constants.PATH_UPLOAD_FOLDER), fname);
                        file.SaveAs(fname);

                        List<Puesto_trabajo> data = Utils.Utils.csvLoad(fname, true);
                        puestoTrabajo.loadEmployees(company, location, area, data);
                        process = data.Count;
                        
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!, procesados :"  + process);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        [HttpPost]
        public ActionResult processFiles()
        {
            string company = Request.Form.Get(Constants.PORCESSING_DATA_COMPANY);
            string location = Request.Form.Get(Constants.PORCESSING_DATA_LOCATION);
            string area = Request.Form.Get(Constants.PORCESSING_DATA_AREA);

            int process = 0;
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            if (!file.FileName.Contains(".txt") && !file.FileName.Contains(".csv"))
                            {
                                return Json("Imposible procesar formatos desconocidos. Solo se permite CSV y TXT. Ok?");
                            }
                            fname = file.FileName;
                        }
                        fname = Path.Combine(Server.MapPath(Constants.PATH_UPLOAD_FOLDER), fname);
                        file.SaveAs(fname);


                        List<Puesto_trabajo> data = Utils.Utils.csvProcessing(fname, true);
                        puestoTrabajo.processEmployees(company, location, area, data);
                        process = data.Count;
                    }
                    return Json("File Uploaded Successfully!, procesados :" + process);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        #endregion
    }
}