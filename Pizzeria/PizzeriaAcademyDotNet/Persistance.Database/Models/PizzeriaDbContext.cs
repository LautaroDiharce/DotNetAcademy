using Microsoft.EntityFrameworkCore;
using Persistance.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Database.Models
{
    class PizzeriaDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;InitialCatalog = Pizzeria; Integrated Security = True");
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetallePedido> Detalle { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Tamaño> Tamaño { get; set; }
        public virtual DbSet<TipoPizza> TipoPizza { get; set; }
        public virtual DbSet<Variedad> Variedad { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            new PedidoConfig(modelBuilder.Entity<Pedido>());
            new ClienteConfig(modelBuilder.Entity<Cliente>());
            new DetallePEdidoConfig(modelBuilder.Entity<DetallePedido>());
            new EstadoConfig(modelBuilder.Entity<Estado>());
            new FacturaConfig(modelBuilder.Entity<Factura>());
            new MenuConfig(modelBuilder.Entity<Menu>());
            new PizzaConfig(modelBuilder.Entity<Pizza>());
            new TamañoConfig(modelBuilder.Entity<Tamaño>());
            new VariedadConfig(modelBuilder.Entity<Variedad>());
            new TipoPizzaConfig(modelBuilder.Entity<TipoPizza>());
            new IngredienteConfig(modelBuilder.Entity<Ingrediente>());

            base.OnModelCreating(modelBuilder);
        }
        }
}
