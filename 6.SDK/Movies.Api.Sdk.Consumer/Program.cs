
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Sdk;
using Movies.Api.Sdk.Consumer;
using Movies.Contracts.Requests;
using Refit;
using System.Text.Json;

//var moviesApi = RestService.For<IMoviesApi>("https://localhost:5001");

var services = new ServiceCollection();


services
    .AddHttpClient()
    .AddSingleton<AuthTokenProvider>()
    .AddRefitClient<IMoviesApi>(s => new RefitSettings
    {
        AuthorizationHeaderValueGetter = async (HttpRequestMessage message, CancellationToken token) => await s.GetRequiredService<AuthTokenProvider>().GetTokenAsync()

    }).ConfigureHttpClient(x => x.BaseAddress = new Uri("https://localhost:5001"));

var provider = services.BuildServiceProvider();

var moviesApi = provider.GetRequiredService<IMoviesApi>();

//var movie = await moviesApi.GetMovieAsync("cu-1969");

var newMovie = await moviesApi.CreateMovieAsync(new CreateMovieRequest
{
    Title = "Spooderman 2",
    YearOfRelease = 2002,
    Genres = new[]
    {
        "Action",
        "Retarded"
    }

});

await moviesApi.UpdateMovieAsync(newMovie.Id, new UpdateMovieRequest
{
    Title = "Spooderman 2",
    YearOfRelease = 2002,
    Genres = new[]
    {
        "Action",
        "Retarded",
        "Why"
    }

});

await moviesApi.DeleteMovieAsync(newMovie.Id);

var request = new GetAllMoviesRequest
{
    Title = null,
    Year = null,
    SortBy = null,
    Page = 1,
    PageSize = 3
};

var movies = await moviesApi.GetMoviesAsync(request);

//Console.WriteLine(JsonSerializer.Serialize(movie));

foreach (var item in movies.Items)
{
    Console.WriteLine(JsonSerializer.Serialize(item));
}
