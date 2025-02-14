using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIProCli.Response
{
    public class ClienteResponseGet
    {
        public string Nombre { get; set; }        
        public string Correo { get; set; }        
        public string Telefono { get; set; }        
        public DateTime FechaCreacion { get; set; }        
    }
}
