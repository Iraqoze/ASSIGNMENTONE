using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieEntWebAPI.Models
{
    public record Category
    {
        public Guid Id { get; init; }

        [Required]
        [StringLength(100, MinimumLength =3)]
        public string Title { get; init; }

        [Required]
        [StringLength(100, MinimumLength=10)]
        public string Description { get; init; }

        [ForeignKey("CategoryId")]
        public virtual ICollection<Movie> Movies { get; init; }
    }
}
