namespace Movies.Contracts.Responses;

public class MovieResponse
{
    public required Guid Id { get; init; }
    
    public required string Title { get; init; }
    
    public required string Slug { get; init; }
    
    public float? Rating { get; init; }
    
    public int? UserRating { get; init; }

    public required int YearOfRelease { get; init; }

    public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}
