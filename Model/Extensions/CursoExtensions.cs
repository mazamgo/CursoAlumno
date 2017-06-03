using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Entity;

using Model.DBModel;
using Model.Wrapper;

namespace Model.Extensions
{
    public static class CursoExtensions
    {
        public static IEnumerable<CursoWrapper.ListCursoWrapper> GetListCursos (this DbSet<Curso> dbSet)
        {
            var data = dbSet.Select(x => new CursoWrapper.ListCursoWrapper
            {
                id = x.id,
                Nombre = x.Nombre
            }).OrderBy(x => x.Nombre).ToList();

            return data;

        }

        public static IEnumerable<AlumnoCurso> GetListCursosAlumnos (this DbSet<AlumnoCurso> dbSet, int Alumno_id = 0)
        {
            var data = dbSet.Include("Curso").Where(x => x.Alumno_id == Alumno_id).ToList();

            return data;        
        }
        public static IEnumerable<Curso> GetListCursos2(this DbSet<Curso> dbSet, int Alumno_id = 0) 
        {
            List<Curso> curso = new List<Curso>();

            try 
            {
                using (var ctx = new Model1())
                {
                    if (Alumno_id > 0) 
                    {
                        var tomados = ctx.AlumnoCurso
                            .Where(x => x.Alumno_id == Alumno_id)
                            .Select(x => x.Curso_id)
                            .ToList();

                        curso = ctx.Curso.Where(x => !tomados.Contains(x.id)).ToList();


                        //curso = ctx.Database.SqlQuery<Curso>("Select c.* from Curso c WHERE c.id NOT IN (SELECT ac.Curso_id FROM dbo.AlumnoCurso ac WHERE ac.Curso_id = c.id AND ac.Alumno_id = @Alumno_id )", new sqlParameter("Alumno_id",Alumno_id)).ToList();
                    
                    }
                    else
                    curso = ctx.Curso.ToList();
                }

            }
            catch (Exception) 
            {
                throw;
            }
                      
            return curso;        
        }

        public static ResponseModel SaveCurso3(this DbSet<AlumnoCurso> dbset, AlumnoCurso model, int id)
        {
            var rm = new ResponseModel();
            try
            {
                using (var ctx = new Model1())
                {
                    if (id > 0)
                    {
                        //Actualizar
                        ctx.Entry(model).State = EntityState.Modified;
                    }
                    else
                    {
                        //Agregar
                        ctx.Entry(model).State = EntityState.Added;
                    }
                    rm.SetResponse(true);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return rm;
        }

        public static ResponseModel EliminarAlumnoCurso(this DbSet<AlumnoCurso> dbset, int id) 
        {
            var rm = new ResponseModel();
            try 
            {
                using (var ctx = new Model1()) 
                {
                    AlumnoCurso alumnocurso = new AlumnoCurso();                    
                    alumnocurso = ctx.AlumnoCurso.Where(x => x.id == id).FirstOrDefault();
                    if (alumnocurso != null) 
                    {
                        ctx.Entry(alumnocurso).State = EntityState.Deleted;
                        rm.SetResponse(true);
                        ctx.SaveChanges();                
                    }
                    
                }
                return rm;
            }
            catch (Exception e) 
            {
                throw;
            }
        }

        public static void EliminarAlumnoCurso2(this DbSet<AlumnoCurso> dbset, int id)
        {           
            try
            {
                using (var ctx = new Model1())
                {
                    AlumnoCurso alumnocurso = new AlumnoCurso();
                    alumnocurso = ctx.AlumnoCurso.Where(x => x.id == id).FirstOrDefault();
                    if (alumnocurso != null)
                    {
                        ctx.Entry(alumnocurso).State = EntityState.Deleted;                       
                        ctx.SaveChanges();
                    }

                }              
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
