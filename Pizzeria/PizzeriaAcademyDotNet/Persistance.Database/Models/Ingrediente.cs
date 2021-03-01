using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    public class Ingrediente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Pizza> pizzas { get; set; }
    }
}
