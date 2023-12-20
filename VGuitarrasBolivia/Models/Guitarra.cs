using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Foto { get; set; }

        //para manejo de archivos
        [NotMapped]
        [Display(Name = "Cargar Foto")]
        public IFormFile? FotoFile { get; set; }
    }
}
