using System.ComponentModel.DataAnnotations;

namespace CafeteriaHCC.Models
{
    public class Tb_HccCatEstatusOrden
    {
        [Key]
        public int catord_id { get; set; }
        public string catord_nombre { get; set; }
        public int catord_estaus { get; set; }
    }
}
