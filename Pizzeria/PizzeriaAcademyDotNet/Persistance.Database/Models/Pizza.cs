using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    public class Pizza
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public List<Ingrediente> ingredientes { get; set; }


    }
}
