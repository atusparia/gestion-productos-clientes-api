using Domain;
using Infrastructure;
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
