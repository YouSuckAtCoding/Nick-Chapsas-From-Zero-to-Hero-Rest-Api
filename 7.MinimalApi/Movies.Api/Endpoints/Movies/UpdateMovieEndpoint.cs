using Microsoft.AspNetCore.OutputCaching;
using Movies.Api.Auth;
using Movies.Api.Mapping;
using Movies.Application.Services;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Endpoints.Movies
{
    public static class UpdateMovieEndpoint
    {
        public const string Name = "UpdateMovie";

        public static IEndpointRouteBuilder MapUpdateMovie(this IEndpointRouteBuilder app)
        {
            app.MapPut(ApiEndpoints.Movies.Update, async(Guid id, UpdateMovieRequest request, CancellationToken token,
                IMovieService movieService, HttpContext context,  IOutputCacheStore _outputCacheStore) =>
            {

                var movie = request.MapToMovie(id);
                var userId = context.GetUserId();
                var updatedMovie = await movieService.UpdateAsync(movie, userId, token);
               
                if (updatedMovie is null)
                {
                    return Results.NotFound();
                }

                await _outputCacheStore.EvictByTagAsync("movies", token);
                var response = updatedMovie.MapToResponse();
                return TypedResults.Ok(response);

            }).WithName(Name)
            .Produces<MovieResponse>(StatusCodes.Status200OK)
            .Produces<MovieResponse>(StatusCodes.Status404NotFound)
            .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest)
            .RequireAuthorization(AuthConstants.TrustedMemberPolicyName)
            .WithApiVersionSet(ApiVersioning.versionSet)
            .HasApiVersion(1.0);

            return app;
        }
    }
}
