namespace Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    using DBModel;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Adjunto = new HashSet<Adjunto>();
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        public int Sexo { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaNacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjunto> Adjunto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        //public List<Alumno> ListarAlumnos()
        //{
        //    var alumnos = new List<Alumno>();

        //    try
        //    {
        //        using (var ctx = new DBModel.Model1())
        //        {
        //            alumnos = ctx.Alumno.ToList();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }

        //    return alumnos;

        //}

        public Alumno ObtenerAlumno(int id)
        {
            var alumno = new Alumno();
            try
            {
                using (var ctx = new Model1())
                {
                    alumno = ctx.Alumno.Include("AlumnoCurso")
                        .Include("AlumnoCurso.Curso")
                        .Where(x => x.id == id).SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return alumno;
        }

   }

}
