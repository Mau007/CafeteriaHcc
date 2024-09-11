using CafeteriaHCC.Models;

namespace CafeteriaHCC.Interfaces
{
    public interface IOrdenesAdministrador
    {
        public IEnumerable<dynamic> NumeroTotalOrdenesxMesa();
        public void InsertarNuevaOrden(Tb_HccOrdenes orden);
        public string ActualizarOrdenAgregarProducto(Tb_HccOrdenesDetalle Orden);
        public string ActualizarOrdenCambiaEstatus(Tb_HccOrdenes Orden);
        public string EliminarOrden(Tb_HccOrdenes Orden);
    }
}
