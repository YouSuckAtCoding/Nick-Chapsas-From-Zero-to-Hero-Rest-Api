namespace Movies.Contracts.Responses;

public class MoviesResponse
{
    public required IEnumerable<MoviesResponse> Items { get; init; } = Enumerable.Empty<MoviesResponse>();
}
