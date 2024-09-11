using CafeteriaHCC.DAL;
using CafeteriaHCC.Interfaces;

namespace CafeteriaHCC.Dominio
{
    public class MesasAdministrador : IMesasAdministrador
    {
        private readonly AccesoDatos _AccesoDatos;
        public MesasAdministrador(AccesoDatos accesodatos)
        {
            _AccesoDatos = accesodatos;
        }
        public IEnumerable<dynamic> TotalMesasDisponibles()
        {
            return _AccesoDatos.Tb_HccMesas.Where(m => m.mes_disponible == 1)
                    .GroupBy(m => m.mes_lugares)
                    .Select(x => new { mes_lugares = x.Key, Total = x.Count() });
        }
    }
}
