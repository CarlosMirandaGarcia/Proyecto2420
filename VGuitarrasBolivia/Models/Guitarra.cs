using System.ComponentModel.DataAnnotations;

namespace VGuitarrasBolivia.Models
{
    public class Guitarra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Modelo { get; set; }
        [Required]
        public string? Cuerdas { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
