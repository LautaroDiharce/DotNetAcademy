using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Database.Models;

namespace Services
{
    public class PedidoService
    {
        public static void Save(Pedido pedido)
        {
            using (var db = new PizzeriaDbContext())
            {
                try
                {
                    if (pedido.id != 0)
                    {
                        db.Entry(pedido).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Pedido.Add(pedido);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        public static Pedido Get(int Id)
        {
            using (var db = new PizzeriaDbContext())
            {
                Pedido pedido = db.Pedido.Where(d => d.id == Id).FirstOrDefault();
                return pedido;
            }
        }

        public static List<Pedido> GetAll()
        {
            using (var db = new PizzeriaDbContext())
            {
                List<Pedido> pedidos = db.Pedido.ToList();

                return pedidos;
            }
        }
        public static void Update(int id)
        {
            using (var db = new PizzeriaDbContext())
            {
                Pedido result = (from p in db.Pedido
                                 where p.id == id && p.estado == "En Preparacion"
                                 select p).SingleOrDefault();

                if (result != null)
                {
                    result.estado = "Finalizado";
                }
                else
                {
                    Console.WriteLine("Pedido Inexistente");
                }

                db.SaveChanges();
            }
        }

        public static bool Remove(int id)
        {
            using (var db = new PizzeriaDbContext())
            {
                Pedido p = db.Pedido.Where(p => p.id == id).FirstOrDefault();
                if (p != null)
                {
                    db.Entry(p).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
