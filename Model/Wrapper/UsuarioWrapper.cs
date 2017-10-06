using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Wrapper
{
    public class UsuarioWrapper
    {
        public class LoginUsuario
        {
            public long UsuarioID { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Email { get; set; }
            public string Foto { get; set; }
        }

    }
}
