﻿namespace APIProCli.Response
{
    public class ProductoResponseGet
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
