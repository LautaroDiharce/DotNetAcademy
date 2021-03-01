using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Persistance.Database.Models;


namespace Services
{
    public class IngredienteService
    {
        public static List<Ingrediente> GetAll()
        {
            using (var db = new PizzeriaDbContext())
            {
                List<Ingrediente> ing = db.Ingrediente.ToList();

                return ing;
            }
        }
        public static void Save(Ingrediente i)
        {
            using (var db = new PizzeriaDbContext())
            {
                try
                {
                    if (i.id != 0)
                    {
                        db.Entry(i).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Ingrediente.Add(i);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }
    }
}
