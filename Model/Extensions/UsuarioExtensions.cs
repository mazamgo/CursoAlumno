using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Helper;
using Model.DBModel;
using Model.Wrapper;

using System.Data;
using System.Data.Entity;

namespace Model.Extensions
{
    public static class UsuarioExtensions
    {
        public static ResponseModel Acceder(this DbSet<Usuario> dbset, string correos, string password) 
        {
            var rm = new ResponseModel();

            try 
            {
                using (var ctx = new Model1()) 
                {
                    password = HashHelper.MD5(password);

                    var usuario = ctx.Usuario.Where(x => x.Email == correos)
                                             .Where(x => x.Password == password)
                                             .SingleOrDefault();
                    if (usuario != null) 
                    {
                        SessionHelper.AddUserToSession(usuario.UsuarioID.ToString());
                        rm.SetResponse(true);
                    }
                    else 
                    {
                        rm.SetResponse(false,"Correo o Contraseña incorrecto.");
                    }
                }            
            }
            catch (Exception e) 
            {
                throw;
            }

            return rm;
        }





    }
}
