using System.ComponentModel.DataAnnotations;

namespace ApiGameCatalog.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game name must be between 3 and 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The producer name must be between 3 and 100 characters.")]
        public string Producer { get; set; }
        [Required]
        [Range(1,1000, ErrorMessage = "The price must be at last 1 real and at most 1000 reais.")]
        public double Price { get; set; }
    }
}