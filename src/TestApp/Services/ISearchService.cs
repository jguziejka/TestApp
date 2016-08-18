using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Services
{
    public interface ISearchService
    {
        Task<SearchResultsModel> RunSearch(SearchModel search);
    }
}
