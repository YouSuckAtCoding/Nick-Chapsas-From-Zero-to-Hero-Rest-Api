namespace Movies.Contracts.Requests;

public class GetAllMoviesRequest : PagedRequest
{
    public string? Title { get; init; }

    public int? Year { get; init; }

    public string? SortBy { get; init; }
}
