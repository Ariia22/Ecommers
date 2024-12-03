using System.ComponentModel.DataAnnotations;

namespace Ecommers.Models
{
    public class Product
    {
        [Key] // Esto indica que ProductoID es la clave primaria
        public int ProductoID { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public string ImagenURL { get; set; }
    }
}
