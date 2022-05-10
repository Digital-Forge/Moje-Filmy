using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Range(1900, 2100)]
        public int ProductionYear { get; set; }
    }
}
