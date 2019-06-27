using Services.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PaginationModel
    {

        public PaginationModel() { }

        public PaginationModel(IPaginatedList paginatedList)
        {
            PageIndex = paginatedList.PageIndex;
            TotalPages = paginatedList.TotalPages;
            TotalCount = paginatedList.TotalCount;
            PageSize = paginatedList.PageSize;
            WindowSize = paginatedList.WindowSize;
        }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string PageActionLink { get; set; }
        public int WindowSize { get; set; }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 <= TotalPages);
            }
        }

        public int LeftMargin
        {
            get
            {
                if (PageIndex - WindowSize / 2 <= 1)
                {
                    return 1;
                }
                else
                {
                    if (PageIndex + WindowSize / 2 > TotalPages)
                    {
                        var leftMargin = WindowSize > TotalPages ? 1 : TotalPages - WindowSize + 1;
                        return leftMargin;
                    }
                    else
                    {
                        return PageIndex - WindowSize / 2;
                    }
                }
            }
        }

        public int RightMargin
        {
            get
            {
                if (PageIndex - WindowSize / 2 <= 1)
                {
                    var rightMargin = WindowSize > TotalPages ? TotalPages : WindowSize;
                    return rightMargin;
                }
                else
                {
                    if (PageIndex + WindowSize / 2 > TotalPages)
                    {
                        return TotalPages;
                    }
                    else
                    {
                        return PageIndex + (int)Math.Ceiling((double)WindowSize / 2) - 1;
                    }
                }
            }
        }
    }
}
