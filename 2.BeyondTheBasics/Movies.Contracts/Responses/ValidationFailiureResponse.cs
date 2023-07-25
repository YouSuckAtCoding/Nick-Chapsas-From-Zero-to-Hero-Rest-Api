using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contracts.Responses
{
    public class ValidationFailiureResponse
    {
        public required IEnumerable<ValidationResponse> Errors { get; init; }
    }

    public class ValidationResponse
    {
        public required string Message { get; init; }
        public required string PropertyName { get; init; }
    }
}
