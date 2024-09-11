using System.ComponentModel.DataAnnotations;

namespace CafeteriaHCC.Models
{
    public class Tb_HccMesas
    {
        [Key]
        public int mes_id { get; set; }
        public System.Int16 mes_lugares { get; set; }
        public int mes_disponible { get; set; }
        public int mes_estaus { get; set; }
    }
}
