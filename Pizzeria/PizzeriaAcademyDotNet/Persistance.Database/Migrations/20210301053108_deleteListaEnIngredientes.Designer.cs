﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Database.Models;

namespace Persistance.Database.Migrations
{
    [DbContext(typeof(PizzeriaDbContext))]
    [Migration("20210301053108_deleteListaEnIngredientes")]
    partial class deleteListaEnIngredientes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Persistance.Database.Models.DetallePedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("pedidoid")
                        .HasColumnType("int");

                    b.Property<int?>("pizzaid")
                        .HasColumnType("int");

                    b.Property<double>("subtotal")
                        .HasColumnType("float");

                    b.Property<int>("tamaño")
                        .HasColumnType("int");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("pedidoid");

                    b.HasIndex("pizzaid");

                    b.ToTable("Detalle");
                });

            modelBuilder.Entity("Persistance.Database.Models.Factura", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("formaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("pedidoid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pedidoid");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Persistance.Database.Models.Ingrediente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Pizzaid")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Pizzaid");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("Persistance.Database.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("demora")
                        .HasColumnType("float");

                    b.Property<string>("estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaEmision")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Persistance.Database.Models.Pizza", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Pizza");
                });

            modelBuilder.Entity("Persistance.Database.Models.DetallePedido", b =>
                {
                    b.HasOne("Persistance.Database.Models.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("pedidoid");

                    b.HasOne("Persistance.Database.Models.Pizza", "pizza")
                        .WithMany()
                        .HasForeignKey("pizzaid");

                    b.Navigation("pedido");

                    b.Navigation("pizza");
                });

            modelBuilder.Entity("Persistance.Database.Models.Factura", b =>
                {
                    b.HasOne("Persistance.Database.Models.Pedido", "pedido")
                        .WithMany()
                        .HasForeignKey("pedidoid");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("Persistance.Database.Models.Ingrediente", b =>
                {
                    b.HasOne("Persistance.Database.Models.Pizza", null)
                        .WithMany("ingredientes")
                        .HasForeignKey("Pizzaid");
                });

            modelBuilder.Entity("Persistance.Database.Models.Pizza", b =>
                {
                    b.Navigation("ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
