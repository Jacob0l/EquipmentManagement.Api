using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class PagedList<T>
    {
        /// <summary>
        /// The list which has been paginated.
        /// </summary>
        public required IEnumerable<T> List { get; set; }

        /// <summary>
        /// The total number of pages from the query available.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// The currently viewed page.
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
