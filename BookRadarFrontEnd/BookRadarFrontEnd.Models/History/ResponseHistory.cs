using BookRadarFrontEnd.Models.books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Models.History
{
    public class ResponseHistory
    {
        public string version { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public object isError { get; set; }
        public object responseException { get; set; }

        [JsonPropertyName("result")]
        public List<HistorialBusquedasModel> HistoryList { get; set; } = new List<HistorialBusquedasModel>();

    }

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
