namespace Movies.Contracts.Requests;

public class PagedRequest
{
    public required int Page { get; init; } = 1;

    public required int PageSize { get; init; } = 10;
}
