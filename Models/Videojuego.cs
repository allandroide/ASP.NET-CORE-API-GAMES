using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIGAMES.Models
{
    public partial class Videojuego
    {
        public Videojuego()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idplataforma { get; set; }
        public string? Plataforma { get; set; }
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
