using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class Variedad
    {
        public int id { get; set; }
        public int descripcion { get; set; }

        public List<string> ingredientes { get; set; }
    }
}
