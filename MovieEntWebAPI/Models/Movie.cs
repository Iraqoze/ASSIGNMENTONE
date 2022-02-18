using System.ComponentModel.DataAnnotations;

namespace MovieEntWebAPI.Models
{
    public record Movie
    {
        public Guid Id { get; init; }

        [Required]
        [StringLength(100, MinimumLength=3)]
        public string Title { get; init; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; init; }
        public DateTime ReleaseDate { get; init; }

        [Required]
        public string VideoLink { get; init; }

        [Required]
        public string ThumbnailImage { get; init; }
        public Guid CategoryId { get; init; }
    }
}
