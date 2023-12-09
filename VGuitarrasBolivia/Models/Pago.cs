using System.ComponentModel.DataAnnotations;

namespace VGuitarrasBolivia.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumeroRecibo { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal MontoTotal { get; set; }
    }
}
