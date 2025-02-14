using APIProCli.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
using APIProCli.Response;

namespace APIProCli.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public void Insertar(ClienteRequestInsert cliente) 
        { 
            ClienteService service = new ClienteService();

            Cliente domain = new Cliente
            { 
                Nombre = cliente.Nombre,
                Correo = cliente.Correo,
                Telefono = cliente.Telefono,
                FechaCreacion = cliente.FechaCreacion,
                Activo = cliente.Activo,
            };

            service.Insert(domain);
        }

        [HttpGet]
        public List<ClienteResponseGet> Listar()
        {
            ClienteService service = new ClienteService();

            service.Get();

            var clientes = service.Get();

            var response = clientes.Select(x => new ClienteResponseGet
            {
                Nombre = x.Nombre,
                Correo= x.Correo,
                Telefono = x.Telefono,
                FechaCreacion = x.FechaCreacion,
            }).ToList();

            return response;
        }

        [HttpPut]
        public void Eliminar(ClienteRequestDelete request)
        {
            ClienteService service = new ClienteService();

            Cliente domain = new Cliente
            {
                Id = request.Id,
                Activo = false,
            };

            service.Delete(domain);
        }
    }
}
