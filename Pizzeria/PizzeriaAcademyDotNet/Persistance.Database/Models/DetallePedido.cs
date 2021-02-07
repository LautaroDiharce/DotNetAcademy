using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class DetallePedido
    {
        public int id { get; set; }
        public Pizza pizza { get; set; }
        public int montoUnitario { get; set; }

    }
}
