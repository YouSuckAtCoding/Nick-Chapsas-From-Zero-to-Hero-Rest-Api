namespace Movies.Contracts.Requests;

public class GetAllMoviesRequest : PagedRequest
{
    public required string? Title { get; init; }

    public required int? Year { get; init; }
    
    public required string? SortBy { get; init; }
}
