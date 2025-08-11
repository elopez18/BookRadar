namespace BookRadarBackEnd.Models
{
    public class BooksModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string AnioPublicacion { get; set; }
        public required string Editorial { get; set; }
        public string AutorBuscado { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
