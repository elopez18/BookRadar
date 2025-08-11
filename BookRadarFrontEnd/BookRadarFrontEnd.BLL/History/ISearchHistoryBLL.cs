using BookRadarFrontEnd.Models.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRadarFrontEnd.BLL.History
{
    public interface ISearchHistoryBLL
    {
        Task<ResponseHistory> GetBooksHistoryAsync();
    }
}
