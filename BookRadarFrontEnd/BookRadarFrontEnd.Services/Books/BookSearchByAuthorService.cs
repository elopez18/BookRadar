using BookRadarFrontEnd.Models.books;
using BookRadarFrontEnd.Utils.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BookRadarFrontEnd.Services.Books
{

    public class BookSearchByAuthorService: IBookSearchByAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public BookSearchByAuthorService(IGetConfig getConfig, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseApiUrl = getConfig.GetConfiguration()["BookRadarBackEnd"];
        }

        public async Task<ResponseSearch> GetBooksByAuthorAsync(string author)
        {
            var url = $"{_baseApiUrl}Books/GetBooksByAuthor?AuthorName={author}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new ResponseSearch();

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<ResponseSearch>(responseString, options);

            return apiResponse ?? new ResponseSearch();
        }

        public async Task<bool> SaveBookSearchAsync(saveBookModel libroSeleccionado)
        {
            var url = $"{_baseApiUrl}Books/CreateBook";
            var jsonContent = new StringContent(
            JsonSerializer.Serialize(libroSeleccionado),
             Encoding.UTF8,
               "application/json"
            );
           
            var response = await _httpClient.PostAsync(url, jsonContent);

            if (!response.IsSuccessStatusCode)
                return false;

            
            return true;
        }
    }
}
