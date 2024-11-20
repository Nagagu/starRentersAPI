using System.ComponentModel.DataAnnotations;

namespace StarRentersAPI.Models
{
    public class Tenant
    {
        [Key] // Marca esta propiedad como la clave primaria
        public string Id { get; set; } // ID del inquilino (combinación de siglas y parte del DNI)

        [Required] // Asegura que el nombre no sea nulo
        [StringLength(100)] // Limita el tamaño del nombre
        public string Name { get; set; }

      
    }
}
