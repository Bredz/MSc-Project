using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.Common.Interfaces
{
     public interface ISearchable
    {
        //Guid Id { get; }
        string SearchResultSummary { get; }
        string SearchResultType { get; }
        string url { get; }
        bool ContainsKeyword(string keyword);
       
    }
}
