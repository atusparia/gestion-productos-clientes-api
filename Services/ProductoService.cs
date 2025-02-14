using Domain;
using Infrastructure;
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
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public List<Producto> Get() 
        {
            using (var context = new AppDbContext()) 
            { 
                var productos = context.Producto.ToList();
                return productos;
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
