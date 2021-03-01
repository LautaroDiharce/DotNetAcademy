using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    public class Factura
    {
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public string formaPago { get; set; }
    }
}
