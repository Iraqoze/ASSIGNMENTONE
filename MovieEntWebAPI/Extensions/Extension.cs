using MovieEntWebAPI.Dtos;
using MovieEntWebAPI.Models;

namespace MovieEntWebAPI.Extensions
{
    public static class Extension
    {
        public static CategoryDto AsDto(this Category cat) =>
         new CategoryDto(cat.Id, cat.Title, cat.Description);
        public static MovieDto AsDto(this Movie movie) =>
         new MovieDto(movie.Id, movie.Title, movie.Description, movie.ReleaseDate, movie.VideoLink, movie.ThumbnailImage, movie.CategoryId);

    }
}
