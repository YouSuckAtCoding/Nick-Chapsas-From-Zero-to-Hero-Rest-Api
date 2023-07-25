using Movies.Application.Models;

namespace Movies.Application.Repositories;

public interface IMovieRepository
{
    Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
    
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken token = default);
    
    Task<Movie?> GetBySlugAsync(string slug, CancellationToken token = default);
    
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
    
    Task<bool> UpdateAsync(Movie movie, CancellationToken token = default);
    
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
}
