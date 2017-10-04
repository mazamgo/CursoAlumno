using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model;
using Model.DBModel;
using Model.Wrapper;
using Model.Extensions;
using Go.filters;

namespace Go.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Usuario usuario = new Usuario();
        Model1 ctx = new Model1(); 
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Email, string password) 
        {
            var rm = new ResponseModel();
            rm = ctx.Usuario.Acceder(Email, password);

            if (rm.response) 
            {
                rm.href = Url.Content("~/Home");
            }

            return Json(rm);
        }

    }
}
