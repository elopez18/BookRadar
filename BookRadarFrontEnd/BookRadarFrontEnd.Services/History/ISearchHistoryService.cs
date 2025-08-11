using BookRadarFrontEnd.Models.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.Services.History
{
    public interface ISearchHistoryService
    {
        Task<ResponseHistory> GetBooksHistoryAsync();
    }
}
