using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Precio { get; set; }
        [Required]
        public int Stock {  get; set; }
        //Consideraciones para distintas zonas horarias y el manejo por parte del SQL
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;        
        public bool Activo { get; set; }=true;
    }
}
