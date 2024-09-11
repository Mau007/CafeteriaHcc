namespace CafeteriaHCC.Dominio
{
    public class Enums
    {
        public const int Status200 = 200;
        public const int Status500 = 500;

        public enum EstatusOrdenes
        {
            Borrado,
            NuevaOrden,
            OrdenRecibida,
            OrdenenPreparacion,
            OrdenLista,
            OrdenPagada
        }
    }
}
