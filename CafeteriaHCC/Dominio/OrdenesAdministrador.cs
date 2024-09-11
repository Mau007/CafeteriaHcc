using CafeteriaHCC.DAL;
using CafeteriaHCC.Interfaces;
using CafeteriaHCC.Models;
using Microsoft.EntityFrameworkCore.Update;
using Newtonsoft.Json;
using NuGet.Packaging;
using System.Linq;

namespace CafeteriaHCC.Dominio
{
    public class OrdenesAdministrador : IOrdenesAdministrador
    {
        private readonly AccesoDatos _AccesoDatos;
        public OrdenesAdministrador(AccesoDatos accesodatos)
        {
            _AccesoDatos = accesodatos;
        }
        public string ActualizarOrdenAgregarProducto(Tb_HccOrdenesDetalle Orden)
        {
            string Mensajeregreso = "Producto agregado correctamente";
            var orden = _AccesoDatos.Tb_HccOrdenes.FirstOrDefault(o => o.ord_id == Orden.ord_id);
            if (orden == null)
                Mensajeregreso = "La orden no existe";
            else
            {
                orden.ordendetalle.Add(Orden);
                _AccesoDatos.SaveChanges();
            }
           
            return Mensajeregreso;
        }

        public string ActualizarOrdenCambiaEstatus(Tb_HccOrdenes Orden)
        {
            string Mensajeregreso = "Cambio de estatus correctamente";
            var orden = _AccesoDatos.Tb_HccOrdenes.FirstOrDefault(o => o.ord_id == Orden.ord_id);
            if (orden == null)
                Mensajeregreso = "La orden no existe";
            else
            {
                orden.ord_estaus = Orden.ord_estaus;
                _AccesoDatos.SaveChanges();
            }

            return Mensajeregreso;
            
            
        }

        public string EliminarOrden(Tb_HccOrdenes Orden)
        {
            string Mensajeregreso = "orden eliminada correctamente";
            var orden = _AccesoDatos.Tb_HccOrdenes.FirstOrDefault(o => o.ord_id == Orden.ord_id);
            if (orden == null)
            {
                Mensajeregreso = "La orden no existe";
            }
            else
            {
                orden.ord_estaus = Enums.EstatusOrdenes.Borrado;
                _AccesoDatos.SaveChanges();
            }
            return Mensajeregreso;
        }

        public void InsertarNuevaOrden(Tb_HccOrdenes orden)
        {
            _AccesoDatos.Tb_HccOrdenes.Add(orden);
            _AccesoDatos.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<dynamic> NumeroTotalOrdenesxMesa()
        {
            return _AccesoDatos.Tb_HccOrdenes.GroupBy(o => o.mes_id)
                .Select(x => new { mes_id = x.Key, Total = x.Count() });
        }
    }
}
