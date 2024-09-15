using System.Drawing.Printing;

namespace EmployeeManagement.Web.ViewModels
{
    public class PaginationViewModel
    {
        public int? TotalPages { get; set; }
        public int? PageNumber { get; set; }
        public int CurrentPage { get; private set; }
        public int? PageSize { get; set; }
        public int TotalItems { get; private set; }
        public bool IsFirstPage => CurrentPage == 1;
        public bool IsLastPage => CurrentPage == TotalPages;

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public PaginationViewModel(int count, int pageNumber, int pageSize)
        {
            TotalItems = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

    }
}



