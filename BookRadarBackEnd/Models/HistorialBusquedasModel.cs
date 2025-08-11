namespace BookRadarBackEnd.Models
{
    public class HistorialBusquedasModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string AnioPublicacion { get; set; }
        public required string Editorial { get; set; }
        public required string Autor { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}
