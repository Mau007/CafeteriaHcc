namespace CafeteriaHCC.Models
{
    public class Response
    {
        public int estatus { get; set; }
        public string mensaje { get; set; }
        public string codigo { get; set; }
        public dynamic? datos {  get; set; }
    }
}
