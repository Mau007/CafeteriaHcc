using System.ComponentModel.DataAnnotations;

namespace CafeteriaHCC.Models
{
    public class Tb_HccAlmacen
    {
        [Key]
        public int alm_id { get; set; }
        public int alm_cantidad { get; set; }
        public string? alm_fecha_actualizacion { get; set; }
        public int alm_estaus{ get; set; }
    }
}
