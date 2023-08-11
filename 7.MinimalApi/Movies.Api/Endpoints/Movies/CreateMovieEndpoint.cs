using Microsoft.AspNetCore.OutputCaching;
using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Endpoints.Movies
{
    public static class CreateMovieEndpoint
    {
        public const string Name = "CreateMovie";

        public static IEndpointRouteBuilder MapCreateMovie(this IEndpointRouteBuilder app)
        {
            app.MapPost(ApiEndpoints.Movies.Create, async (CreateMovieRequest request, CancellationToken token,
                IMovieService movieService, IOutputCacheStore _outputCacheStore) =>
            {
                var movie = request.MapToMovie();
                await movieService.CreateAsync(movie, token);
                await _outputCacheStore.EvictByTagAsync("movies", token);
                var response = movie.MapToResponse();
                return TypedResults.CreatedAtRoute(response, GetMovieEndpoint.Name, new {idOrSlug = movie.Id});
                
            }).WithName(Name)
            .Produces<MovieResponse>(StatusCodes.Status201Created)
            .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest)
            .RequireAuthorization(AuthConstants.TrustedMemberPolicyName)
            .WithApiVersionSet(ApiVersioning.versionSet)
            .HasApiVersion(1.0);

            return app;
        }
    }
}
