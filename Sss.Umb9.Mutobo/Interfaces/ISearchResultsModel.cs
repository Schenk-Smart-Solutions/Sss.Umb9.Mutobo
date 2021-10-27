using Sss.Umb9.Mutobo.PoCo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.Umb9.Mutobo.Interfaces
{
    public interface ISearchResultsModel
    {
        string Term { get; set; }
        string Page { get; set; }
        IEnumerable<SearchResult> Results { get; set; }
    }
}
