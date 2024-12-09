using Ecommers.Data;
using Ecommers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Ecommers.Controllers
{
    public class ProductsController : Controller
    {
        // Inyección del contexto de la base de datos
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para mostrar los productos con paginación
        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
        {
            // Obtener el total de productos
            var totalProducts = await _context.Productos.CountAsync();

            // Obtener los productos de la base de datos con paginación
            var pagedProducts = await _context.Productos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Pasar la información de la página a la vista
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)System.Math.Ceiling((double)totalProducts / pageSize);

            return View(pagedProducts);
        }

        // Método para agregar un producto al carrito
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            // Buscar el producto en la base de datos
            var product = await _context.Productos.FindAsync(id);
            if (product != null)
            {
                // Crear un CartItem a partir del producto
                var cartItem = new CartItem
                {
                    Id = product.ProductoID,
                    ProductName = product.Nombre,
                    Price = product.Precio,
                    Description = product.Descripcion,
                    Quantity = 1
                };

                // Llamar al método del controlador de carrito para agregar el producto
                var cartController = new CartController();
                cartController.AddProductToCart(cartItem);
            }

            return RedirectToAction("Index", "Cart");
        }
    }
}
