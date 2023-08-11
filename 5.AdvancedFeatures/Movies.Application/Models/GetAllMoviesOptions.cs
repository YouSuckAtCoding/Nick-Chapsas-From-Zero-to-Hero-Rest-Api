using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Models
{
    public class GetAllMoviesOptions
    {
        public  string? Title { get; set; }

        public  int? Year { get; set; }

        public Guid? UserId { get; set; }
        
        public  string? SortField { get; set; }

        public SortOrder? SortOrder { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public enum SortOrder
    {
        Unsorted, 
        Ascending,
        Descending
    }
}
