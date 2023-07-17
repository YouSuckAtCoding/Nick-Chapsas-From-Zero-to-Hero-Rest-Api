using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contract.Responses
{
    public class MoviesResponse
    {
        public required IEnumerable<MovieResponse> Items { get; init; } = Enumerable.Empty<MovieResponse>();   
    }
}
