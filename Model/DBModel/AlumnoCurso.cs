namespace Model.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AlumnoCurso")]
    public partial class AlumnoCurso
    {
        public int id { get; set; }

        public int Alumno_id { get; set; }

        public int Curso_id { get; set; }

        [Required(ErrorMessage="Nota Requerida")]
        [Range(0,20,ErrorMessage="Valor entre 0 y 20")]
        public decimal Nota { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
