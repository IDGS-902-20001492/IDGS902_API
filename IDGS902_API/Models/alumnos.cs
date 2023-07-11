using System.ComponentModel.DataAnnotations;

namespace IDGS902_API.Models
{
    public class alumnos
    {
        [Key]
        public int id { get; set; }
        public string? nombre { get; set; }
        public int edad { get; set; }
        public string? correo { get; set;}
    }
}
