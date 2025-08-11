using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Models.books
{
    public class ResponseSearch
    {
        public string version { get; set; }
        public int statusCode { get; set; }
        public string message { get; set; }
        public object isError { get; set; }
        public object responseException { get; set; }

        [JsonPropertyName("result")]
        public List<Book> BookList { get; set; } = new List<Book>();
    }

    public class Book
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string anioPublicacion { get; set; }
        public string editorial { get; set; }
        public string autorBuscado { get; set; }
        public DateTime fechaConsulta { get; set; }
    }
}
