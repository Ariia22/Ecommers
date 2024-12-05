using Microsoft.AspNetCore.Mvc;

namespace Ecommers.Controllers
{
    [Route("Carrito")]
    public class CarritoController : Controller
    {
        // Simulación de base de datos en memoria
        private static List<Producto> carrito = new List<Producto>();

        // Obtener los productos en el carrito con cálculos de precios
        [HttpGet("ObtenerCarrito")]
        public IActionResult ObtenerCarrito()
        {
            var subtotal = carrito.Sum(p => decimal.Parse(p.Precio));
            var iva = subtotal * 0.16m; // IVA del 16%
            var total = subtotal + iva;

            return Json(new
            {
                productos = carrito,
                subtotal = subtotal.ToString("F2"),
                iva = iva.ToString("F2"),
                total = total.ToString("F2")
            });
        }

        // Agregar un producto al carrito
        [HttpPost("AgregarProducto")]
        public IActionResult AgregarProducto([FromBody] Producto producto)
        {
            if (producto == null || string.IsNullOrEmpty(producto.Id))
            {
                return BadRequest(new { error = "Producto inválido" });
            }

            carrito.Add(producto);
            return Ok(new { success = true });
        }

        // Vaciar el carrito
        [HttpPost("VaciarCarrito")]
        public IActionResult VaciarCarrito()
        {
            carrito.Clear();
            return Json(new { success = true });
        }
    }

    // Clase modelo para Producto
    public class Producto
    {
        public string Id { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
    }
}