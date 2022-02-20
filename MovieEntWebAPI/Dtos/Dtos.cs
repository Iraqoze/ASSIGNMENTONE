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

    //User

    public record UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }        
        public bool IsAuthenticated { get; set; }
        
    }

    public record UpdateUserDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

}
