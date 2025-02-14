using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIProCli.Request
{
    public class ClienteRequestInsert
    {       
        public string Nombre { get; set; }     
        public string Correo { get; set; }     
        public string? Telefono { get; set; }     
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }
    }
}
