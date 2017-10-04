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
using Go.filters;
using System.IO;

using Infragistics.Web.Mvc;
using System.Net.Http;
using System.Net;

namespace Go.Controllers
{
     [Autenticado]
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

        public ActionResult Index2()
        {
            GridModel model = new GridModel();
            model.AutoGenerateColumns = false;
            
            GridColumn idColumn = new GridColumn();           
            idColumn.Key = "id";
            idColumn.HeaderText = "ID";
            idColumn.DataType = "number";

            GridColumn NombreColumn = new GridColumn();            
            NombreColumn.Key = "Nombre";
            NombreColumn.HeaderText = "Nombre";
            NombreColumn.DataType = "string";

            GridColumn ApellidoColumn = new GridColumn();
            ApellidoColumn.Key = "Apellido";
            ApellidoColumn.HeaderText = "Apellido";
            ApellidoColumn.DataType = "string";

            GridColumn SexoColumn = new GridColumn();
            SexoColumn.Key = "Sexo";
            SexoColumn.HeaderText = "Sexo";
            SexoColumn.DataType = "string";

            GridColumn FechaNacimientoColumn = new GridColumn();
            FechaNacimientoColumn.Key = "FechaNacimiento";
            FechaNacimientoColumn.HeaderText = "Fecha Nacimiento";
            FechaNacimientoColumn.DataType = "datetime";

            model.Columns.Add(idColumn);
            model.Columns.Add(NombreColumn);
            model.Columns.Add(ApellidoColumn);
            model.Columns.Add(SexoColumn);
            model.Columns.Add(FechaNacimientoColumn);
            
            //Activando Ordenamiento
            GridSorting sorting = new GridSorting();
            sorting.Mode = SortingMode.Single;

            ColumnSortingSetting colSetting = new ColumnSortingSetting();
            colSetting.ColumnIndex = 1;
            colSetting.ColumnKey   = "Nombre";
            colSetting.AllowSorting = true;

            //Activando Filtrado
            GridFiltering filtering = new GridFiltering();

            ColumnFilteringSetting colFilter = new ColumnFilteringSetting();
            colFilter.AllowFiltering = true;
            
            sorting.ColumnSettings.Add(colSetting);
            filtering.ColumnSettings.Add(colFilter);

            model.Features.Add(sorting);
            model.Features.Add(filtering);

            //Activando Paginacion
            GridPaging gridpaging = new GridPaging();
            gridpaging.PageSize = 2;
            model.Features.Add(gridpaging);
                      
            model.DataSource = ctx.Alumno.GetAllAlumnos3();
            return View(model);           
        }

        public ActionResult Index3()
        {
            //return View(new Alumno());
            return View(ctx.Alumno.GetAllAlumnos3().AsQueryable());            
        }

        public IEnumerable<Model.Wrapper.AlumnoWrapper.ListAlumnosWrapper> GetAlumnosAll()
        {
            var customers = ctx.Alumno.GetAllAlumnos3();
           
            return customers;
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
       
        public ActionResult Guardar3(Alumno alumno)
        {
            //if (ModelState.IsValid)
            //{
                int id = alumno.id;
                ctx.Alumno.SaveAlumnos2(alumno, id);                              
                return Redirect("~/Home/Index3");
            //}
            //else
            //{
            //    return View("~/Views/Home/crud.cshtml", alumno);
            //}
            //return View(alumno);
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
