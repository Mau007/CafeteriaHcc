using CafeteriaHCC.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaHCC.DAL
{
    public class AccesoDatos:DbContext
    {
        public AccesoDatos(DbContextOptions options) : base(options) { }
        public DbSet<Tb_HccAlmacen> Tb_HccAlmacen { get; set; }
        public DbSet<Tb_HccProductos> Tb_HccProductos { get; set; }
        public DbSet<Tb_HccMesas> Tb_HccMesas { get; set; }
        public DbSet<Tb_HccCatEstatusOrden> Tb_HccCatEstatusOrden { get; set; }
        public DbSet<Tb_HccOrdenes> Tb_HccOrdenes { get; set; }
        public DbSet<Tb_HccOrdenesDetalle> Tb_HccOrdenesDetalle { get; set; }
    }
}
