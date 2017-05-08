using Model.DBModel;
using Model.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Web;

namespace Model.Extensions
{
    public static class AdjuntoExtensions
    {
        public static IEnumerable<Adjunto> GetListAdjunto(this DbSet<Adjunto> dbset, int alumnoid) 
        {
            return dbset.Where(x => x.Alumno_id == alumnoid).ToList();        
        }

        public static ResponseModel SaveAdjunto3(this DbSet<Adjunto> dbset, Adjunto model, int id  )
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



    }
}
