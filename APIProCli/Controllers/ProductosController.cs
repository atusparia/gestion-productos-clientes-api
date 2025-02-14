using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProCli.Request;
using Services;
using Domain;
using APIProCli.Response;

namespace APIProCli.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpPost]
        public void Insertar(ProductoRequestInsert request) 
        { 
            ProductoService service = new ProductoService();

            Producto domain = new Producto
            { 
                Nombre = request.Nombre,
                Precio = request.Precio,
                Stock = request.Stock,
                FechaCreacion = request.FechaCreacion,
                Activo = request.Activo
            };

            service.Insert(domain);
        }

        [HttpGet]
        public List<ProductoResponseGet> Listar() 
        {
            ProductoService service = new ProductoService();

            service.Get();

            var productos = service.Get();

            var response = productos.Select(x => new ProductoResponseGet
            {
                Nombre = x.Nombre,
                Precio = x.Precio,
                Stock = x.Stock,
                FechaCreacion = x.FechaCreacion,
            }).ToList();

            return response;
        }

        [HttpPut]
        public void Eliminar(ProductoRequestDelete request) 
        { 
            ProductoService service= new ProductoService();

            Producto domain = new Producto
            {
                Id = request.Id,
                Activo = false,
            };

            service.Delete(domain);            
        }
    }
}
