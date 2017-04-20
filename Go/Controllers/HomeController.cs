using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;

using Model;
using Model.DBModel;
using Model.Extensions;
using Model.Wrapper;

namespace Go.Controllers
{
    public class HomeController : Controller
    {
        private Alumno alumno = new Alumno();
        Model1 ctx = new Model1();

        public ActionResult Index()
        {           
            return View(ctx.Alumno.GetAllAlumnos());                          
            //return View(alumno.ListarAlumnos());
        }

        public ActionResult ver(int id) 
        {            
            //return View(alumno.ObtenerAlumno(id));
            return View(ctx.Alumno.ObtenerAlumno(id));
        }

        public ActionResult crud(int id = 0)
        {
            return View(id == 0 ? new Alumno() : ctx.Alumno.GetAlumnoId(id));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(Alumno x ) {

            if (ModelState.IsValid) 
            {
                int id = x.id;
                ctx.Alumno.SaveAlumnos2(x, id);
                return Redirect ("~/Home");            
            }
                        
            return View(x);
        }

    }
}
