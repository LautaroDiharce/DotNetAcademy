using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class Factura
    {
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public int monto { get; set; }
    }
}
