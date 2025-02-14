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
        public void Insertar(Producto producto) 
        {
            using (var context = new AppDbContext())
            { 
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }


    }
}
