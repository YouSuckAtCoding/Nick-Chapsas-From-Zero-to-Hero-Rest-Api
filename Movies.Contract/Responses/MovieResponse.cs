using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contract.Responses
{
    public class MovieResponse
    {
        public required Guid Id { get; init; }
        public string Title { get; init; }
        public int YearOfRelease { get; init; }
        public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
    }
}
