using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Wrapper
{
    public class AlumnoWrapper
    {
        public class AlumnosWrapper
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Sexo { get; set; }
            public string FechaNacimiento { get; set; }
            public decimal Nota { get; set; }
            public string NombreCurso { get; set; }

        }

        public class ListAlumnosWrapper 
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Sexo { get; set; }
            public string FechaNacimiento { get; set; }        
        }       


    }
}
