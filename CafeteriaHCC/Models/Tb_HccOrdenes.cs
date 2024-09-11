using System.ComponentModel.DataAnnotations;
using static CafeteriaHCC.Dominio.Enums;

namespace CafeteriaHCC.Models
{
    public class Tb_HccOrdenes
    {
        [Key]
        public int ord_id { get; set; }
        public int mes_id { get; set; }
        public int catord_id { get; set; }
        public string? ord_fecha_inicio { get; set; }
        public EstatusOrdenes ord_estaus { get; set; }
        
        public List<Tb_HccOrdenesDetalle> ordendetalle { get; set; }
    }
}
