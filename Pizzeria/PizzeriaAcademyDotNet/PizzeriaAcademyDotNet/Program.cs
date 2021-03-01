using Persistance.Database.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaAcademyDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            bool ejecucion = true;

            while (ejecucion)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Elegir una opción:");
                Console.WriteLine("1- Cargar nueva pizza");
                Console.WriteLine("2- Cargar nuevo ingrediente");
                Console.WriteLine("3- Listar todas las pizzas");
                Console.WriteLine("4- Nuevo pedido");
                Console.WriteLine("5- Listar pedidos");
                Console.WriteLine("6- Finalizar Pedido");
                Console.WriteLine("7- Cancelar pedido");
                Console.WriteLine("8- Variedades mas pedidas");
                Console.WriteLine("9- Tipos mas pedidos");
                Console.WriteLine("10- Visualizar ingresos");
                Console.WriteLine("0- SALIR:");
                var opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        ejecucion = false;
                        break;
                    case 1:
                        Console.WriteLine("Escriba el nombre de la variedad de pizza a ingresar:");
                        var variedad = Console.ReadLine();
                        bool continuarAgregando = true;
                        List<Ingrediente> ingredientes = new List<Ingrediente>();

                        while (continuarAgregando)
                        {
                            Console.WriteLine("Seleccione un ingrediente a agregar:");
                            Console.WriteLine("Los ingredientes disponibles son:");
                            List<Ingrediente> listaI = IngredienteService.GetAll();
                            foreach (var I in listaI)
                            {
                                Console.WriteLine(I.id + " - " + I.nombre);
                            }
                            var ing = Int32.Parse(Console.ReadLine());
                            Ingrediente ingrediente = listaI.Where(i => i.id == ing).FirstOrDefault();
                            ingredientes.Add(ingrediente);
                            Console.WriteLine("Desea agregar mas ingredientes? Y/N:");
                            var seguir = Console.ReadLine().ToUpper();
                            switch (seguir)
                            {
                                case "Y":
                                    break;
                                case "N":
                                    continuarAgregando = false;
                                    break;
                                default:
                                    Console.WriteLine("Opcion invalida");
                                    break;
                            }
                            
                        }

                        Console.WriteLine("Escriba el precio de la variedad de pizza:");
                        var precio = Int32.Parse(Console.ReadLine());
                        var nuevaPizza = new Pizza { nombre = variedad, precio = precio };//, ingredientes= ingredientes};
                        PizzaService.Save(nuevaPizza);
                        break;

                    case 2:
                        Console.WriteLine("Escriba el nombre del ingrediente:");
                        var nombre = Console.ReadLine();
                        var ingNuevo = new Ingrediente { nombre = nombre};

                        IngredienteService.Save(ingNuevo);
                        break;
                    case 3:
                        listarPizzas();
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el nombre del cliente: ");

                        var cli = Console.ReadLine();

                        Console.WriteLine("Cuantas pizzas desea ordenar? ");
                        var totalAPedir = Int32.Parse(Console.ReadLine());
                        var demora = totalAPedir * 15;
                        Pedido p = new Pedido { cliente = cli, fechaEmision = DateTime.Now, estado = "En Preparacion", demora = demora };
                        PedidoService.Save(p);
                        while (totalAPedir != 0)
                        {
                            Console.WriteLine("Elija una pizza de entre las siguiente opciones: ");
                            listarPizzas();
                            var pizzaId = Int32.Parse(Console.ReadLine());
                            Pizza pizza = PizzaService.Get(pizzaId);
                            double subtot = pizza.precio;
                            Console.WriteLine("Ingrese el tamaño de la pizza (numero de porciones): 8 Porciones/ 10 porciones/ 12 porciones");
                            var tam = Int32.Parse(Console.ReadLine());
                            switch (tam)
                            {
                                case 8:
                                    break;
                                case 10:
                                    subtot = subtot * 1.10;
                                    break;
                                case 12:
                                    subtot = subtot * 1.20;
                                    break;
                                default:
                                    Console.WriteLine("tamaño no valido");
                                    break;
                            }
                            Console.WriteLine("Ingrese el tipo de pizza: 1- A la piedra/ 2- A la parrilla/ 3- De molde");
                            var op = Int32.Parse(Console.ReadLine());
                            string tipoPizza;
                            if (op ==1)
                            {
                                tipoPizza = "A la piedra";
                                
                                
                            }
                            else
                            {
                                if (op == 2 )
                                {
                                    tipoPizza = "A la parrilla";
                                   
                                }
                                else
                                {
                                    tipoPizza = "De molde";

                                }
                            }

                            Console.WriteLine("Ingrese la cantidad de pizzas de la variedad " + pizza.nombre + " de " + tam.ToString() +" porciones, del tipo " + tipoPizza + " a ordenar: ");
                            var cantidad = Int32.Parse(Console.ReadLine());
                            DetallePedido det = new DetallePedido {  cantidad = cantidad, subtotal = subtot, tamaño = tam, tipo = tipoPizza };
                            DetallePedidoService.Save(det);
                            totalAPedir = totalAPedir - cantidad;
                        }
                        break;

                   case 5:
                        List<Pedido> pedidos = PedidoService.GetAll();
                        foreach (var ped in pedidos)
                        {
                            Console.WriteLine("ID- " + ped.id);
                            Console.WriteLine("Cliente- " + ped.cliente);
                            Console.WriteLine("Estado- " + ped.estado);
                            Console.WriteLine("Demora- " + ped.demora);
                            Console.WriteLine("Fecha Emision- " + ped.fechaEmision);
                        }
                        break;

                    case 6:

                        var Listapedidos=listarPedidosEnPreparacion();
                        Console.WriteLine("Seleccione el id del pedido a Finalizar:");
                        var final = Int32.Parse(Console.ReadLine());
                        PedidoService.Update(final);
                        Console.WriteLine("Ingrese forma de pago:");
                        var FP = Console.ReadLine();
                        var pedido = Listapedidos.Where(p => p.id == final).FirstOrDefault();
                        Factura factura = new Factura { pedido = pedido, formaPago = FP };
                        break;
                    case 7:
                        var ListapedidosEnPrep = listarPedidosEnPreparacion();
                        Console.WriteLine("Seleccione el id del pedido a cancelar:");
                        var idCancelacion = Int32.Parse(Console.ReadLine());

                        var exito = PedidoService.Remove(idCancelacion);
                        if (exito)
                        {
                            Console.WriteLine("Pedido cancelado");

                        }
                        else
                        {
                            Console.WriteLine("Pedido Inexistente");

                        }
                        break;

                    case 8:
                        Console.WriteLine("Variedades de pizza mas pedidas del ultimo mes");
                        List<DetallePedido> detallepedidosParaVariedad = DetallePedidoService.GetAll();
                        Dictionary<string, int> PizzasMasPedidas = new Dictionary<string, int>();
                        foreach (var detalle in detallepedidosParaVariedad)
                        {
                            if (PizzasMasPedidas.ContainsKey(detalle.pizza.nombre.ToString()))
                                PizzasMasPedidas[detalle.pizza.nombre.ToString()]++;
                            else
                                PizzasMasPedidas.Add(detalle.pizza.nombre.ToString(), 1);
                        }
                        var sortedDict = (from entry in PizzasMasPedidas
                                          orderby entry.Value descending
                                          select entry).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);
                        foreach (KeyValuePair<string, int> kvp in sortedDict)
                        {
                            
                            Console.WriteLine("Variedad = {0}, Cantidad de veces pedida = {1}", kvp.Key, kvp.Value);
                        }
                        break;
                    case 9:

                        Console.WriteLine("Tipos de pizza mas pedidas del ultimo mes");
                        List<DetallePedido> detallepedidosParaTipo = DetallePedidoService.GetAll();
                        Dictionary<string, int> tiposMasPedidas = new Dictionary<string, int>();
                        foreach (var detalle in detallepedidosParaTipo)
                        {
                            if (tiposMasPedidas.ContainsKey(detalle.tipo.ToString()))
                                tiposMasPedidas[detalle.tipo.ToString()]++;
                            else
                                tiposMasPedidas.Add(detalle.tipo.ToString(), 1);
                        }
                        var sortedDictionary = (from entry in tiposMasPedidas
                                                orderby entry.Value descending
                                          select entry).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);
                        foreach (KeyValuePair<string, int> kvp in sortedDictionary)
                        {

                            Console.WriteLine("Tipo = {0}, Cantidad de veces pedida = {1}", kvp.Key, kvp.Value);
                        }
                        break;
                    case 10:
                        Console.WriteLine("Ingresos del ultimo mes");
                        List<DetallePedido> detalles = DetallePedidoService.GetAll();
                        foreach (var d in detalles)
                        {
                            Console.WriteLine("Fecha: " + d.pedido.fechaEmision.ToString());
                            Console.WriteLine("Monto: " + d.subtotal.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("No existe la opcion ingresada.");
                        break;
                }

            }

        }
        static public void listarPizzas()
        {
            List<Pizza> pizza = PizzaService.GetAll();
            foreach (var p in pizza)
            {
                Console.WriteLine(p.id.ToString() +"- " + p.nombre);
            }
        }
        static public List<Pedido> listarPedidosEnPreparacion()
        {
            Console.WriteLine("Pedidos en Preparacion:");
            List<Pedido> Listapedidos = PedidoService.GetAll();
            Listapedidos = Listapedidos.Where(p => p.estado == "En Preparacion").ToList();
            foreach (var ped in Listapedidos)
            {
                Console.WriteLine("ID- " + ped.id);
                Console.WriteLine("Cliente- " + ped.cliente);
                Console.WriteLine("Estado- " + ped.estado);
                Console.WriteLine("Demora- " + ped.demora);
                Console.WriteLine("Fecha Emision- " + ped.fechaEmision);
            }
            return Listapedidos;
        }
    }
}
