using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeteriaHCC.Models
{
    public class Tb_HccProductos
    {
        [Key]
        public int pro_id { get; set; }
        public int alm_id { get; set; }
        public string pro_nombre { get; set; }
        public string pro_descripcion { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal pro_precio { get; set; }
        public int pro_estaus { get; set; }
    }
}
