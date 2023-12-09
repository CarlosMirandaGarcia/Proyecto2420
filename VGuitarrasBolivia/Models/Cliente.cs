using VGuitarrasBolivia.Dtos;
using System.ComponentModel.DataAnnotations;

namespace VGuitarrasBolivia.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Ci { get; set; }
        [Required]
        public int Celular { get; set; }
    }
}
