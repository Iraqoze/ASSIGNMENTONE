using System.ComponentModel.DataAnnotations;

namespace MovieEntWebAPI.Dtos
{
    //Category DTOs
    public record CategoryDto(Guid Id, string Title, string Description);
    public record CreateCategoryDto([Required]string Title,[Required] string Description);
    public record UpdateCategoryDto([Required] string Title, [Required] string Description);

    //Movie DTOs
    public record MovieDto(Guid Id, string Title, string Description, DateTime ReleaseDate, string VideoLink, string ThumbnailImage, Guid CategoryId );
    public record CreateMovieDto(string Title, string Description, DateTime ReleaseDate, string VideoLink, string ThumbnailImage);
    public record UpdateMovieDto(string Title, string Description, DateTime ReleaseDate, string VideoLink, string ThumbnailImage, Guid CategoryId);

}
