using BookRadarFrontEnd.Models.books;
using BookRadarFrontEnd.Models.History;
using BookRadarFrontEnd.Utils.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Services.History
{
    public class SearchHistoryService: ISearchHistoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;

        public SearchHistoryService(IGetConfig getConfig, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseApiUrl = getConfig.GetConfiguration()["BookRadarBackEnd"];
        }

        public async Task<ResponseHistory> GetBooksHistoryAsync()
        {
            var url = $"{_baseApiUrl}Books/GetBooksHistory";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return new ResponseHistory();

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var apiResponse = JsonSerializer.Deserialize<ResponseHistory>(responseString, options);

            return apiResponse ?? new ResponseHistory();
        }
    }
}
