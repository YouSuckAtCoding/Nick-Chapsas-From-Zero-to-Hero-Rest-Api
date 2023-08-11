using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Endpoints.Movies
{
    public static class GetAllMoviesEndpoint
    {
        public const string Name = "GetMovies";

        public static IEndpointRouteBuilder MapGetAllMovies(this IEndpointRouteBuilder app)
        {
            app.MapGet(ApiEndpoints.Movies.GetAll, async ([AsParameters] GetAllMoviesRequest request, IMovieService movieService,
                HttpContext context, CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var options = request.MapToOptions()
                    .WithUser(userId);
                var movies = await movieService.GetAllAsync(options, token);
                var movieCount = await movieService.GetCountAsync(options.Title, options.YearOfRelease, token);
                var moviesResponse = movies.MapToResponse(request.Page.GetValueOrDefault(PagedRequest.DefaultPage),
                    request.PageSize.GetValueOrDefault(PagedRequest.DefaultPageSize), movieCount);
                return TypedResults.Ok(moviesResponse);

            }).WithName($"{Name}V1").Produces<MoviesResponse>(StatusCodes.Status200OK)
            .WithApiVersionSet(ApiVersioning.versionSet)
            .HasApiVersion(1.0).CacheOutput("MovieCache");

            app.MapGet(ApiEndpoints.Movies.GetAll, async ([AsParameters] GetAllMoviesRequest request, IMovieService movieService,
               HttpContext context, CancellationToken token) =>
            {
                var userId = context.GetUserId();
                var options = request.MapToOptions()
                    .WithUser(userId);
                var movies = await movieService.GetAllAsync(options, token);
                var movieCount = await movieService.GetCountAsync(options.Title, options.YearOfRelease, token);
                var moviesResponse = movies.MapToResponse(request.Page.GetValueOrDefault(PagedRequest.DefaultPage),
                    request.PageSize.GetValueOrDefault(PagedRequest.DefaultPageSize), movieCount);
                return TypedResults.Ok(moviesResponse);

            }).WithName($"{Name}V2").Produces<MoviesResponse>(StatusCodes.Status200OK)
           .WithApiVersionSet(ApiVersioning.versionSet)
           .HasApiVersion(2.0);
            return app;

            


        }
    }
}
