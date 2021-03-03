using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Persistance.Database.Models;
using Persistance.Database.Models.Request;

namespace WebApiPizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        public ReporteController()
        {

        }

        [HttpGet]
        [Route("InformeVariedad")]
        public IActionResult GetInformeVariedades()
        {
            var sortedDict = new Dictionary<string, int>();

            try
            {
                List<DetallePedido> detallepedidosParaVariedad = DetallePedidoService.GetAll();
                Dictionary<string, int> PizzasMasPedidas = new Dictionary<string, int>();
                foreach (var detalle in detallepedidosParaVariedad)
                {
                    if (PizzasMasPedidas.ContainsKey(detalle.pizza.nombre.ToString()))
                        PizzasMasPedidas[detalle.pizza.nombre.ToString()]++;
                    else
                        PizzasMasPedidas.Add(detalle.pizza.nombre.ToString(), 1);
                }
                sortedDict = (from entry in PizzasMasPedidas
                                  orderby entry.Value descending
                                  select entry).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al consultar los datos " + ex.Message);
            }
            return Ok(sortedDict);
        }
        [HttpGet]
        [Route("InformeTipo")]
        public IActionResult GetInformeTipos()
        {
            var sortedDictionary = new Dictionary<string, int>();

            try
            {
                List<DetallePedido> detallepedidosParaTipo = DetallePedidoService.GetAllJoinPizza();
                Dictionary<string, int> tiposMasPedidas = new Dictionary<string, int>();
                foreach (var detalle in detallepedidosParaTipo)
                {
                    if (tiposMasPedidas.ContainsKey(detalle.tipo.ToString()))
                        tiposMasPedidas[detalle.tipo.ToString()]++;
                    else
                        tiposMasPedidas.Add(detalle.tipo.ToString(), 1);
                }
                sortedDictionary = (from entry in tiposMasPedidas
                                        orderby entry.Value descending
                                        select entry).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al consultar los datos " + ex.Message);
            }
            return Ok(sortedDictionary);
        }

        [HttpGet]
        [Route("InformeIngreso")]
        public IActionResult GetIngresos()
        {
            var sortedDictionary = new Dictionary<DateTime, double>();

            try
            {
                Console.WriteLine("Ingresos del ultimo mes");
                List<DetallePedido> detalles = DetallePedidoService.GetAllJoinPedido();
                foreach (var d in detalles)
                {
                    sortedDictionary.Add(d.pedido.fechaEmision, d.subtotal);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al consultar los datos " + ex.Message);
            }
            return Ok(sortedDictionary);
        }


    }
}
