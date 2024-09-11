using System.ComponentModel.DataAnnotations;

namespace CafeteriaHCC.Models
{
    public class Tb_HccOrdenesDetalle
    {
        [Key]
        public int orddet_id { get; set; }
        public int ord_id { get; set; }
        public int pro_id { get; set; }
        public int orddet_cantidad { get; set; }
        public int orddet_estaus { get; set; }
    }
}
