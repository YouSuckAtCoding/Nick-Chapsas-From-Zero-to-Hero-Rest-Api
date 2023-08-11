using Movies.Api.Auth;
using Movies.Application.Services;

namespace Movies.Api.Endpoints.Ratings
{
    public static class DeleteRatingEndpoint
    {
        public const string Name = "DeleteMovieRating";

        public static IEndpointRouteBuilder MapDeleteRatings(this IEndpointRouteBuilder app)
        {
            app.MapDelete(ApiEndpoints.Movies.DeleteRating, async (Guid id, CancellationToken token,
                IRatingService ratingService, HttpContext context) =>
            {
                var userId = context.GetUserId();
                var result = await ratingService.DeleteRatingAsync(id, userId!.Value, token);
                return result ? Results.Ok() : Results.NotFound();
            }).WithName(Name)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .RequireAuthorization()
            .WithApiVersionSet(ApiVersioning.versionSet)
            .HasApiVersion(1.0);
            return app;
        }
    }
}
