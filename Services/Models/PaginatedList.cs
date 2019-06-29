using Services.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PaginatedList<T> : List<T>, IPaginatedList
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        public int WindowSize { get; private set; }

        public PaginatedList() { }

        public PaginatedList(List<T> source, int pageIndex, int pageSize = 12, int windowSize = 12)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            WindowSize = windowSize;

            this.AddRange(source.Skip((PageIndex - 1) * PageSize).Take(PageSize));
        }

        public void CopyPaginatedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount, int totalPages, int windowSize)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPages = totalPages;
            this.WindowSize = windowSize;
            this.AddRange(source);
        }
    }
}
