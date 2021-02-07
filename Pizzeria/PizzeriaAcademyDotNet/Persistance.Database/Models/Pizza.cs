using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class Pizza
    {
        public int id { get; set; }
        public TipoPizza tipoPizza { get; set; }
        public Variedad variedad { get; set; }
        public Tamaño tamaño { get; set; }
        public int precio { get; set; }


    }
}
