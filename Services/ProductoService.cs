using Domain;
using Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductoService
    {
        public void Insert(Producto producto) 
        {
            using (var context = new AppDbContext())
            { 
                producto.Activo = true; //Revisar
                producto.FechaCreacion = DateTime.Now;
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public List<Producto> Get() 
        {
            using (var context = new AppDbContext()) 
            { 
                var productos = context.Producto.Where(p=>p.Activo==true).ToList();
                return productos;
            }
        }

        public List<Producto> GetByFilter(string filter)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Producto.Where(x => x.Activo== true);

                if (!filter.IsNullOrEmpty())
                {
                    query = query.Where(x => x.Nombre.Contains(filter));
                }

                return query.ToList();
            }
        }

        public void Delete(Producto producto)
        {
            using (var context = new AppDbContext())
            {
                context.Producto.Attach(producto);
                context.Entry(producto).Property(p=>p.Activo).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
