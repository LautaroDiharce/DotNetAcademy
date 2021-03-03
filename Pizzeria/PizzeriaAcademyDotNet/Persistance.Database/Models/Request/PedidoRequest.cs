using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models.Request
{
    public class PedidoRequest
    {
        public int id { get; set; }
        public string estado { get; set; }
        public string cliente { get; set; }
        public double demora { get; set; }
        public DateTime fechaEmision { get; set; }
    }
}
