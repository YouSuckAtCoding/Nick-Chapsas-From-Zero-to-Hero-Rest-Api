namespace Movies.Api.Endpoints.Ratings
{
    public static class RatingsEndpointsExtensions
    {
        public static IEndpointRouteBuilder MapRatingEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapRateMovie();
            app.MapDeleteRatings();
            app.MapGetUserRatings();
            return app;
        }
    }
}
