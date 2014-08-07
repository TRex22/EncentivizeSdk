using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entelect.Encentivize.Sdk
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int FirstItem { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int LastItem { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
