using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Model.DBModel;
using Model.Wrapper;
using Model.Extensions;
using System.Web.Http.Description;

namespace WebApi.Controllers
{
    //[Authorize]
    public class AlumnosController : ApiController
    {
        public IHttpActionResult GetApiAllCursos() 
        {
            Model1 ctx = new Model1();
           
            var data = ctx.Curso.GetListCursos();
            return Ok(data);
        }

       [HttpGet]
       [Route("GetApiAllAlumnos")]
        public IHttpActionResult GetApiAllAlumnos()
        {
           Model1 contex = new Model1();
           //var data = contex.Alumno.GetAlumnos();           
           var data = contex.Alumno.GetAllAlumnos();
           return Ok(data);
        }

        [HttpGet]
        [Route("GetApiAlumnosID/{id}")]
       public IHttpActionResult GetApiAlumnosID(int id)
       {
           Model1 context = new Model1();
           var data = context.Alumno.GetAlumnosID(id);
           return Ok(data);
        }

        [HttpGet]
        [Route("GetApiAlumnosNota/{id}")]
        [ResponseType(typeof(IEnumerable<AlumnoWrapper.AlumnosWrapper>))]
        public IHttpActionResult GetApiAlumnosNota(int id)
        {
            Model1 context = new Model1();
            var data = context.Alumno.GetAlumnosNota(context, id);
            return Ok(data);
        }

        [HttpPost]
        [Route("PostApiNewAlumno")]
        public IHttpActionResult PostApiNewAlumno(Alumno model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                AlumnosExtensions.SaveAlumno(model, 1,0);

                return Ok();
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("PostApiUpdateAlumno/{id}")]
        public IHttpActionResult PostApiUpdateAlumno(Alumno model, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                AlumnosExtensions.SaveAlumno(model, 1, id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
