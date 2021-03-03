using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models.Request
{
    public class DetalleRequest
    {
        public int id { get; set; }

        public Pizza pizza { get; set; }
        public double subtotal { get; set; }
        public Pedido pedido { get; set; }
        public string tipo { get; set; }
        public int cantidad { get; set; }
        public int tamaño { get; set; }
    }
}
