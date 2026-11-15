namespace test1.Models
{
    public class Canton
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int extencion { get; set; }
        public int numero_habitantes { get; set; }


        // relacion entre las tablas
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
    }
}
