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
    public class PedidoController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pedido> pedidos = new List<Pedido>();
            try
            {
                pedidos =PedidoService.GetAll();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al consultar los datos " + ex.Message);
            }
            return Ok(pedidos);

        }

        [HttpPost]
        public ActionResult PostPedido(PedidoRequest ped, List<DetalleRequest> det)
        {
            try
            {
                Pedido pedido = new Pedido();
                List<DetallePedido> detalles = new List<DetallePedido>();
                pedido.cliente = ped.cliente;
                pedido.demora = ped.demora;
                pedido.estado = ped.estado;
                pedido.fechaEmision = ped.fechaEmision;

                
                PedidoService.Save(pedido);
                for (int i = 0; i < det.Count(); i++)
                {
                    detalles[i].pedido = det[i].pedido;
                    detalles[i].pizza = det[i].pizza;
                    detalles[i].subtotal = det[i].subtotal;
                    detalles[i].tamaño = det[i].tamaño;
                    detalles[i].tipo = det[i].tipo;
                    DetallePedidoService.Save(detalles[i]);                            
                }

            }

            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(PedidoRequest ped)
        {
            try
            {

                PedidoService.Update(ped.id);


            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(ped);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            bool exito;
            try
            {



                exito = PedidoService.Remove(id);


            }
            catch (Exception ex)
            {
                throw; ;
            }
            return Ok(exito);
        }
    }
}
