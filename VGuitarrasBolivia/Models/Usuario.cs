using CITIwebApp.Dtos;

namespace CITIwebApp.Models
{
    public class Usuario
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? NombreCompleto { get; set; }
        public RolEmun Rol { get; set; }
    }
}
