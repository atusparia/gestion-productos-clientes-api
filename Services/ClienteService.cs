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
    public class ClienteService
    {
        public void Insert(Cliente cliente) 
        {
            using (var context = new AppDbContext())
            {
                cliente.Activo = true; //Revisar
                cliente.FechaCreacion = DateTime.Now;
                context.Cliente.Add(cliente);
                context.SaveChanges();
            }
        }

        public List<Cliente> Get()
        {
            using (var context = new AppDbContext())
            {
                var clientes = context.Cliente.Where(p => p.Activo == true).ToList();
                return clientes;
            }
        }

        public List<Cliente> GetByFilter(string filter)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Cliente.Where(x => x.Activo == true);

                if (!filter.IsNullOrEmpty())
                {
                    query = query.Where(x => x.Nombre.Contains(filter));
                }

                return query.ToList();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (var context = new AppDbContext())
            {
                context.Cliente.Attach(cliente);
                context.Entry(cliente).Property(p => p.Activo).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
