using Microsoft.EntityFrameworkCore;
using Persistance.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    public class PizzeriaDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Pizzeria;Integrated Security=True");
        }

        public virtual DbSet<DetallePedido> Detalle { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            new PedidoConfig(modelBuilder.Entity<Pedido>());
            new DetallePEdidoConfig(modelBuilder.Entity<DetallePedido>());
            new FacturaConfig(modelBuilder.Entity<Factura>());
            new PizzaConfig(modelBuilder.Entity<Pizza>());
            new IngredienteConfig(modelBuilder.Entity<Ingrediente>());

            base.OnModelCreating(modelBuilder);
        }
        }
}
