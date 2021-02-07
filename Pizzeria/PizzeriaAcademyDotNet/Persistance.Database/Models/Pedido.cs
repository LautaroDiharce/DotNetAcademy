using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class Pedido
    {
        public int id { get; set; }
        public List<DetallePedido> detalles { get; set; }
        public int total { get; set; }
        public Estado estado { get; set; }
        public Cliente cliente { get; set; }


    }
}
