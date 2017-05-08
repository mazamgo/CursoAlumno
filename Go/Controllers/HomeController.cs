﻿using System;
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
using System.IO;

namespace Go.Controllers
{
    public class HomeController : Controller
    {

        //private Alumno alumno = new Alumno();
        private AlumnoCurso alumno_curso = new AlumnoCurso();
        private Curso curso = new Curso();
        private Adjunto adjunto = new Adjunto();

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
        public ActionResult Guardar(Alumno alumno ) {

            if (ModelState.IsValid) 
            {
                int id = alumno.id;
                ctx.Alumno.SaveAlumnos2(alumno, id);
                return Redirect ("~/Home");            
            }
            else 
            {
                return View("~/Views/Home/crud.cshtml", alumno);
            }
            return View(alumno);
        }
             
        public JsonResult Guardar2(Alumno alumno)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
                int id = alumno.id;
                rm = ctx.Alumno.SaveAlumnos3(alumno, id);
                if (rm.response) 
                {
                    //rm.function = "SoyAlgo()";
                    rm.href = Url.Content("~/Home");
                }                
            }
            return Json(rm);
        }

       public ActionResult Eliminar(int id) 
        {
            //int id = alumno.id;
            ctx.Alumno.EliminarAlumno(id);
            return Redirect("~/Home");
        }

       public PartialViewResult Cursos(int alumnoID ) 
       {
           ViewBag.Cursos = ctx.Curso.GetListCursos2(alumnoID);
           ViewBag.AlumnoCurso = ctx.AlumnoCurso.GetListCursosAlumnos(alumnoID);

           alumno_curso.Alumno_id = alumnoID;   
           return PartialView(alumno_curso);
       }

       public JsonResult GuardarCurso(AlumnoCurso curso)
       {
           var rm = new ResponseModel();

           if (ModelState.IsValid)
           {
               int id = curso.id;
               rm = ctx.AlumnoCurso.SaveCurso3(curso, id);
               if (rm.response)
               {
                   rm.function = "CargarCursos()";                   
               }
           }
           return Json(rm);
       }
      
       public ActionResult EliminarAlumnoCurso2(int id)
       {           
           ctx.AlumnoCurso.EliminarAlumnoCurso2(id);
           return Redirect("~/Home/Crud");
       }

       //No  funciono bien.
        public JsonResult EliminarAlumnoCurso(int id) 
       {
           var rm = new ResponseModel();
           rm = ctx.AlumnoCurso.EliminarAlumnoCurso(id);
           if (rm.response) 
           {
               //rm.function = "CargarCursos()";
               rm.href = Url.Content("~/Home");
           }

           return Json(rm);
       }

        public PartialViewResult Adjuntos(int alumnoID) 
        {
            ViewBag.Adjuntos = ctx.Adjunto.GetListAdjunto(alumnoID);

            adjunto.Alumno_id = alumnoID;
            return PartialView(adjunto);
        }

        public JsonResult GuardarAdjunto(Adjunto adjunto, HttpPostedFileBase Archivo)
        {
            var rm = new ResponseModel();

            if(Archivo != null)           
            {
                //renombrarlo
                string archivo = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(Archivo.FileName);
                Archivo.SaveAs(Server.MapPath("~/Uploads/" + archivo));
                adjunto.Archivo = archivo;

                int id = adjunto.id;
                rm = ctx.Adjunto.SaveAdjunto3(adjunto, id);
                if (rm.response)
                {
                    rm.function = "CargarAdjuntos()";
                }
            }
            return Json(rm);
        }

    }
}
