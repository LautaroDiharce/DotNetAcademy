using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Database.Models;

namespace Services
{
    public class PizzaService
    {
        public static void Save(Pizza p)
        {
            using (var db = new PizzeriaDbContext())
            {
                try
                {
                    if (p.id != 0)
                    {
                        db.Entry(p).State = EntityState.Modified;
                    }
                    else
                    {
                        foreach (var i in p.ingredientes)
                        {
                            db.Entry(i).State = EntityState.Unchanged;
                        }

                        db.Pizza.Add(p);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static Pizza Get(int Id)
        {
            using (var db = new PizzeriaDbContext())
            {
                Pizza pizza = db.Pizza.Where(p => p.id == Id).FirstOrDefault();
                return pizza;
            }
        }

        public static List<Pizza> GetAll()
        {
            using (var db = new PizzeriaDbContext())
            {
                List<Pizza> pizzas = db.Pizza.ToList();

                return pizzas;
            }
        }
    }
}
