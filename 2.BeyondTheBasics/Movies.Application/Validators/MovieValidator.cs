using FluentValidation;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        private readonly IMovieRepository _movieRepository;

        public MovieValidator(IMovieRepository movieService)
        {
            _movieRepository = movieService;

            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Genres).NotEmpty();

            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.YearOfRelease).LessThanOrEqualTo(DateTime.UtcNow.Year);

            RuleFor(x => x.Slug).MustAsync(ValidateSlug).WithMessage("This movie already exists in the system");
        }

        private async Task<bool> ValidateSlug(Movie movie, string slug, CancellationToken token = default)
        {
            var existingMovie = await _movieRepository.GetBySlugAsync(slug);

            if (existingMovie is not null)
            {
                return existingMovie.Id == movie.Id;
            }

            return existingMovie is null; 
        }
    }
}
