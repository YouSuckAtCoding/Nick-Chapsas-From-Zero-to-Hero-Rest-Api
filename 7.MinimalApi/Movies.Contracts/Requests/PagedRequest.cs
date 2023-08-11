namespace Movies.Contracts.Requests;

public class PagedRequest
{
    public const int DefaultPage = 1;
    public const int DefaultPageSize = 10;
    public int? Page { get; init; } = DefaultPage;

    public int? PageSize { get; init; } = DefaultPageSize;
}
