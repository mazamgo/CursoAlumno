﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DBModel;
using System.Data.Entity;
using Model.Wrapper;

using System.ComponentModel.DataAnnotations;

namespace Model.Extensions
{
    public static class AlumnosExtensions
    {
        public static IEnumerable<AlumnoWrapper.ListCursoWrapper> GetListCursos (this DbSet<Curso> dbSet) 
        {
            var data = dbSet.Select(x => new AlumnoWrapper.ListCursoWrapper
            {
                id = x.id,
                Nombre = x.Nombre
            }).OrderBy(x => x.Nombre).ToList();

            return data;
        
        }
        public static IEnumerable<AlumnoWrapper.ListAlumnosWrapper> GetAlumnos(this DbSet<Alumno> dbSet)
        {
            return dbSet.Select( x => new AlumnoWrapper.ListAlumnosWrapper {
                id = x.id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sexo = x.Sexo,
                FechaNacimiento = x.FechaNacimiento
            }).OrderBy(x => x.Nombre).ToArray();           
        }

        public static IEnumerable<AlumnoWrapper.ListAlumnosWrapper> GetAllAlumnos(this DbSet<Alumno> dbSet)
        {
            var data = dbSet.Select(x => new AlumnoWrapper.ListAlumnosWrapper
            {
                id = x.id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Sexo = x.Sexo,
                FechaNacimiento = x.FechaNacimiento
            }
                ).OrderBy(x => x.Nombre).ToArray();           

            return data;
        }

        public static IEnumerable<AlumnoWrapper.ListAlumnosWrapper>GetAlumnosID(this DbSet<Alumno> dbSet, int id)
        {
            return dbSet.Select(x => new AlumnoWrapper.ListAlumnosWrapper
                    {
                        id = x.id,
                        Nombre = x.Nombre,
                        Apellido = x.Apellido,
                        Sexo = x.Sexo,
                        FechaNacimiento = x.FechaNacimiento
                    }).Where(x => x.id == id).ToArray();
        }

        public static Alumno GetAlumnoId(this DbSet<Alumno> dbSet, int id)
        {
            return dbSet.Where(x => x.id == id).FirstOrDefault();
        }

        public static IEnumerable<AlumnoWrapper.AlumnosWrapper> GetAlumnosNota(this DbSet<Alumno> dbSet, Model1 context)
        {
            //dbSet,
            return AlumnosNota(context);
        }

        public static IEnumerable<AlumnoWrapper.AlumnosWrapper> GetAlumnosNota(this DbSet<Alumno> dbSet, Model1 context, int id)
        {
            //dbSet,
            return AlumnosNota(context).Where(x => x.id == id).ToArray();
        }

        //this DbSet<Alumno> dbSet
        private static IQueryable<AlumnoWrapper.AlumnosWrapper>AlumnosNota(Model1 context)
        {
            var data = context.Alumno.Join(context.AlumnoCurso, x => x.id, y => y.Alumno_id,
                       (x, y) => new { x.id, x.Nombre, x.Apellido, x.Sexo, x.FechaNacimiento, y.Nota, y.Curso_id })
                       .Join(context.Curso, x => x.Curso_id, y => y.id,
                       (x, y) => new { x.id, x.Nombre, x.Apellido, x.Sexo, x.FechaNacimiento, x.Nota, x.Curso_id, NombreCurso = y.Nombre })
                       .Select(x => new AlumnoWrapper.AlumnosWrapper
                       {
                           id = x.id,
                           Nombre = x.Nombre,
                           Apellido = x.Apellido,
                           Sexo = x.Sexo,
                           FechaNacimiento = x.FechaNacimiento,
                           Nota = x.Nota,
                           NombreCurso = x.NombreCurso
                       });
            return data;

        }

        public static bool SaveAlumno(Alumno model,int iType, int id)
        {
            try
            {
                Model1 context = new Model1();
                Alumno Alumn = new Alumno();
                if (iType ==1) // Nuevo
                {
                    context.Alumno.Add(model);
                    context.SaveChanges();
                }
                else //Actualizar
                {
                    Alumn = context.Alumno.Where(x => x.id == id).FirstOrDefault();
                    if (Alumn !=null)
                    {
                        context.SaveChanges();
                    }
                }
                return true;
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error al Guardar" + ex.Message);
            }
        }

        public static bool SaveAlumnos2 (this DbSet<Alumno> dbset, int id )
        {
            Model1 ctx = new Model1();

            if (id == 0) 
            {
                
            }
           return true; 
        }


    }
}