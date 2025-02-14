using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProCli.Request;
using Services;
using Domain;

namespace APIProCli.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public void Insertar(ProductoRequestInsertar request) 
        { 
            ProductoService service = new ProductoService();

            Producto domain = new Producto 
            { 
                Nombre = request.Nombre,
                Precio = request.Precio,
                Stock = request.Stock,
                FechaCreacion = request.FechaCreacion,
                Activo = request.Activo,
            };

            service.Insertar(domain);
        }
    }
}
