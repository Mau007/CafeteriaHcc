using CafeteriaHCC.DAL;
using CafeteriaHCC.Dominio;
using CafeteriaHCC.Interfaces;
using CafeteriaHCC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CafeteriaHCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly AccesoDatos _AccesoDatos;
        private readonly IOrdenesAdministrador _OrdenesAdministrador;
        private readonly IMesasAdministrador _MesasAdministrador;

        public OrdenesController(AccesoDatos accesodatos, IOrdenesAdministrador ordenesAdministrador,IMesasAdministrador mesasadministrador)
        {
            _AccesoDatos = accesodatos;
            _OrdenesAdministrador = ordenesAdministrador;
            _MesasAdministrador = mesasadministrador;
        }

        [HttpGet("OrdenesTotalesporMesa")]
        public IActionResult OrdenesTotalporMesa()
        {
            Response response = new Response();
            try
            {
                response.mensaje = "Proceso correcto";
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = _OrdenesAdministrador.NumeroTotalOrdenesxMesa();
                var result = JsonConvert.SerializeObject(response);
                
                return Ok(result);
            }
            catch(Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }

        [HttpPost("InsertarNuevaOrden")]
        public IActionResult InsertarNuevaOrden([FromBody] Tb_HccOrdenes orden)
        {
            Response response = new Response();
            try
            {
                response.mensaje = "Orden agregada correctamente";
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = "";
                _OrdenesAdministrador.InsertarNuevaOrden(orden);
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }

        [HttpPost("ActualizarOrdenAgregarProducto")]
        public IActionResult ActualizarOrdenAgregarProducto([FromBody] Tb_HccOrdenesDetalle Orden)
        {
            Response response = new Response();
            try
            {
                if(Orden == null)
                {
                    response.mensaje = "Datos de la orden incorrectos";
                    response.estatus = Enums.Status500;
                    response.codigo = "-1";
                    return Ok(JsonConvert.SerializeObject(response));
                }
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = "";
                response.mensaje = _OrdenesAdministrador.ActualizarOrdenAgregarProducto(Orden);
                var result = JsonConvert.SerializeObject(response);

                return Ok(result);
            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }

        [HttpPost("ActualizarOrdenCambiaEstatus")]
        public IActionResult ActualizarOrdenCambiaEstatus([FromBody] Tb_HccOrdenes Orden)
        {
            Response response = new Response();
            try
            {
                if (Orden == null)
                {
                    response.mensaje = "Datos de la orden incorrectos";
                    response.estatus = Enums.Status500;
                    response.codigo = "-1";
                    return Ok(JsonConvert.SerializeObject(response));
                }
                response.mensaje = _OrdenesAdministrador.ActualizarOrdenCambiaEstatus(Orden);
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = "";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }

        [HttpPost("EliminarOrden")]
        public IActionResult EliminarOrden([FromBody] Tb_HccOrdenes Orden)
        {
            Response response = new Response();
            try
            {
                if (Orden == null)
                {
                    response.mensaje = "Datos de la orden incorrectos";
                    response.estatus = Enums.Status500;
                    response.codigo = "-1";
                    return Ok(JsonConvert.SerializeObject(response));
                }
                response.mensaje = _OrdenesAdministrador.EliminarOrden(Orden);
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = "";
                
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }

        [HttpGet("TotalMesasDisponibles")]
        public IActionResult TotalMesasDisponibles()
        {
            Response response = new Response();
            try
            {

                response.mensaje =  "Proceso correctamente";
                response.estatus = Enums.Status200;
                response.codigo = "1";
                response.datos = _MesasAdministrador.TotalMesasDisponibles();
                
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);

            }
            catch (Exception ex)
            {
                response.mensaje = ex.Message;
                response.estatus = Enums.Status500;
                response.codigo = "-1";
                var result = JsonConvert.SerializeObject(response);
                return Ok(result);
            }
        }
    }
}
