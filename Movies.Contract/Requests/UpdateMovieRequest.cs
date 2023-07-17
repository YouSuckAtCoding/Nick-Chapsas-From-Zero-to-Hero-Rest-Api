using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contract.Requests
{
    public class UpdateMovieRequest
    {
        public string Title { get; init; }
        public int YearOfRelease { get; init; }
        public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
    }
}
