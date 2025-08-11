using BookRadarFrontEnd.Models.books;
using BookRadarFrontEnd.Models.History;
using BookRadarFrontEnd.Services.Books;
using BookRadarFrontEnd.Services.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.BLL.History
{
    public class SearchHistoryBLL: ISearchHistoryBLL
    {

        readonly ISearchHistoryService _SearchHistoryService;
        public SearchHistoryBLL(ISearchHistoryService SearchHistoryService)
        {
            _SearchHistoryService = SearchHistoryService;
        }

        public async Task<ResponseHistory> GetBooksHistoryAsync()
        { 
            return await _SearchHistoryService.GetBooksHistoryAsync();
        }
    }
}
