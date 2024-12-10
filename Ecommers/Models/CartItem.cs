namespace Ecommers.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }  // Relación con Producto
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity; // Calcula el precio total por producto
    }
}
