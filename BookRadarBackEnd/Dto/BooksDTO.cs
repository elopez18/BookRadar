namespace BookRadarBackEnd.Dto
{
    public class BooksDTO
    {
        public required string Titulo { get; set; }
        public required string AnioPublicacion { get; set; }
        public required string Editorial { get; set; }
        public required string AutorBuscado { get; set; }
        public required DateTime FechaConsulta { get; set; }
    }
}
