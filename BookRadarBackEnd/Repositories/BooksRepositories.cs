using BookRadarBackEnd.Context;
using BookRadarBackEnd.Dto;
using BookRadarBackEnd.Helpers;
using BookRadarBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookRadarBackEnd.Repositories
{
    public class BooksRepositories: IBooksRepositories
    {
        private readonly BooksRadarContext _context;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ILogger<BooksRepositories> _logger;
        private readonly IGetConfig _configuration;
        public BooksRepositories(IGetConfig configuration, 
            ILogger<BooksRepositories> logger, BooksRadarContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de libros por autor desde la base de datos o una API externa.
        /// </summary>
        /// <param name="AuthorName"></param>
        /// <returns></returns>
        public async Task<List<BooksModel>> GetBooksByAuthorRepositories(string AuthorName)
        {
            List<BooksModel> listBooksByAuthors = new List<BooksModel>();
            listBooksByAuthors = await GetBooksByAuthorApi(AuthorName);
            
            return listBooksByAuthors;
        }

        /// <summary>
        /// Obtiene una lista de libros por autor desde una API externa.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public async Task<List<BooksModel>> GetBooksByAuthorApi(string authorName)
        {
            var encodedAuthor = Uri.EscapeDataString(authorName);
            var config = _configuration.GetConfiguration();
            var baseUrl = config["apiBookStore"];
            // URL con los datos requeridos, de acuerdo a la documentacion del API
            var url = $"{baseUrl}?author={encodedAuthor}&fields=title,first_publish_year,publisher,author_name";
            var response = await _httpClient.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var results = new List<BooksModel>();

            // Si el elemento raíz tiene la propiedad docs y es un array JSON, entramos al bloque
            if (doc.RootElement.TryGetProperty("docs", out var docs) && docs.ValueKind == JsonValueKind.Array)
            {
                // Recorremos cada elemento del array docs cada elemento es un JsonElement
                foreach (var book in docs.EnumerateArray())
                {
                    string autor = "Desconocido";

                    // Si 'book' tiene la propiedad "author_name", y es un array <> vacío, entonces asigna el nombre de autor; si es null usa "Desconocido"
                    if (book.TryGetProperty("author_name", out var authorElem) &&
                        authorElem.ValueKind == JsonValueKind.Array &&
                        authorElem.GetArrayLength() > 0)
                    {
                        autor = authorElem[0].GetString() ?? "Desconocido";
                    }

                    // Crea una nueva instancia de BooksModel con los campos extraídos y la agrega a la lista results -- Que se envia al front
                    results.Add(new BooksModel
                    {
                        Titulo = book.TryGetProperty("title", out var t) ? t.GetString() ?? "Sin título" : "Sin título",
                        AnioPublicacion = book.TryGetProperty("first_publish_year", out var yearElem) && yearElem.TryGetInt32(out int y) ? y.ToString() : "Desconocido",
                        Editorial = book.TryGetProperty("publisher", out var pubElem) && pubElem.ValueKind == JsonValueKind.Array && pubElem.GetArrayLength() > 0 ? pubElem[0].GetString() ?? "Desconocida" : "Desconocida",
                        AutorBuscado = autor,
                        FechaConsulta = DateTime.Now
                    });
                }
            }

            return results;
        }

        /// <summary>
        /// Crea un nuevo libro y lo guarda en la base de datos, junto con su historial de búsqueda.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> CreateBookRepositories(BooksDTO data)
        {
            bool resultado = false;

            try
            {
                _logger.LogInformation("Creacion del objeto: Books => ", data);
                if (!ExistsBook(data))
                {
                    BooksModel book = new BooksModel()
                    {
                        Titulo = data.Titulo,
                        AnioPublicacion = data.AnioPublicacion,
                        Editorial = data.Editorial,
                        AutorBuscado = data.AutorBuscado,
                        FechaConsulta = data.FechaConsulta
                    };

                    // En usa sola transaccion manejo la insercion de datos a la tabla de busqueda como a la de historico 
                    using var transaction = _context.Database.BeginTransaction();

                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();

                    var historial = new HistorialBusquedasModel
                    {
                        Autor = book.AutorBuscado,
                        Titulo = book.Titulo,
                        AnioPublicacion = book.AnioPublicacion,
                        Editorial = book.Editorial,
                        FechaConsulta = book.FechaConsulta
                    };

                    _logger.LogInformation("Creacion del objeto: HistorialBusquedas => ", data);
                    _context.HistorialBusquedas.Add(historial);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al crear el libro. Detalle: " + ex.Message, data);
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene el historial de búsquedas de libros desde la base de datos mediante SP.
        /// </summary>
        /// <returns></returns>
        public async Task<List<HistorialBusquedasModel>> GetBooksHistoryRepositories()
        {
            List<HistorialBusquedasModel> listHistorico = new List<HistorialBusquedasModel>();
            try
            {

                listHistorico = await _context.HistorialBusquedas
                    .FromSqlRaw("EXEC ConsultarHistorico")
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listHistorico;
        }

        /// <summary>
        /// Verifica si un libro ya existe en la base de datos.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private bool ExistsBook(BooksDTO data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return _context.Books.Any(e =>
                e.Titulo == data.Titulo &&
                e.AnioPublicacion == data.AnioPublicacion &&
                e.Editorial == data.Editorial);
        }


    }
}
