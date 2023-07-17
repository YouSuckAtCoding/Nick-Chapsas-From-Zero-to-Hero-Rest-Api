using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Models
{
    public class Movie
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required int YearOfRelease { get; set; }
        public required List<string> Genres { get; set; }
    }
}
