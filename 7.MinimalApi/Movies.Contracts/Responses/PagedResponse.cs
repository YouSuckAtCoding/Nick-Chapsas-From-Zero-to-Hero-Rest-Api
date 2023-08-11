namespace Movies.Contracts.Responses;

public class PagedResponse<TResponse>
{
    public required IEnumerable<TResponse> Items { get; init; } = Enumerable.Empty<TResponse>();
    
    public int? PageSize { get; init; }
    
    public int? Page { get; init; }
    
    public int? Total { get; init; }

    public bool HasNextPage => Total > (Page * PageSize);
}
