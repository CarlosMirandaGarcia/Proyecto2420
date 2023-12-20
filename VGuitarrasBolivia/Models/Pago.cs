using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VGuitarrasBolivia.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumeroRecibo { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        [Required]
        public decimal MontoTotal { get; set; }
    }
}
