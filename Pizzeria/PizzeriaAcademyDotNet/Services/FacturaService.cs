using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Database.Models;

namespace Services
{
    public class FacturaService
    {
        public static void Save(Factura factura)
        {
            using (var db = new PizzeriaDbContext())
            {
                try
                {
                    if (factura.id != 0)
                    {
                        db.Entry(factura).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(factura.pedido).State = EntityState.Unchanged;
                        db.Factura.Add(factura);
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
