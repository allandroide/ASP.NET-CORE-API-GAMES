using System;
using System.Collections.Generic;

namespace APIGAMES.Models
{
    public partial class Producto
    {
        public int? IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? Trailer { get; set; }
        public int? IdPlataforma { get; set; }

        public virtual Videojuego? Oplataforma { get; set; }
    }
}
