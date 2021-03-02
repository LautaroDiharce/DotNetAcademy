using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Database.Models;


namespace Services
{
    public class DetallePedidoService
    {
        
            public static void Save(DetallePedido detalle)
            {
                using (var db = new PizzeriaDbContext())
                {
                    try
                    {
                        if (detalle.id != 0)
                        {
                            db.Entry(detalle).State = EntityState.Modified;
                        }
                        else
                        {
                        db.Entry(detalle.pizza).State = EntityState.Unchanged;
                        db.Entry(detalle.pedido).State = EntityState.Unchanged;

                        db.Detalle.Add(detalle);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException("Error al guardar. " + ex.Message);
                    }
                }
            }

            public static DetallePedido Get(int Id)
            {
                using (var db = new PizzeriaDbContext())
                {
                    DetallePedido detalle = db.Detalle.Where(d => d.id == Id)
                        .Include(p =>p.pedido ).FirstOrDefault();
                    return detalle;
                }
            }

            public static List<DetallePedido> GetAll()
            {
                using (var db = new PizzeriaDbContext())
                {
                    List<DetallePedido> det = db.Detalle.ToList();

                    return det;
                }
            }
            
        public static List<DetallePedido> GetAllJoinPizza()
        {
            using (var db = new PizzeriaDbContext())
            {
                List<DetallePedido> det = db.Detalle.Include(d => d.pizza).ToList();
                
                return det;
            }
        }
        public static List<DetallePedido> GetAllJoinPedido()
        {
            using (var db = new PizzeriaDbContext())
            {
                List<DetallePedido> det = db.Detalle.Include(d=>d.pedido).ToList();

                return det;
            }
        }

    }
}
