using Ecommers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommers.Controllers
{
    public class ProductosController : Controller
    {
        private static List<Product> _productos;

        public ProductosController()
        {
            if (_productos == null)
            {
                _productos = new List<Product>
        {
            new Product { ProductoID = 1, Nombre = "Producto 1", Descripcion = "Descripción 1", Precio = 100, Stock = 50, ImagenURL = "/images/producto1.jpg" },
            new Product { ProductoID = 2, Nombre = "Producto 2", Descripcion = "Descripción 2", Precio = 200, Stock = 30, ImagenURL = "/images/producto2.jpg" },
            new Product { ProductoID = 3, Nombre = "Producto 3", Descripcion = "Descripción 3", Precio = 300, Stock = 20, ImagenURL = "/images/producto3.jpg" },
            new Product { ProductoID = 4, Nombre = "Producto 4", Descripcion = "Descripción 4", Precio = 400, Stock = 10, ImagenURL = "/images/producto4.jpg" },
            new Product { ProductoID = 5, Nombre = "Producto 5", Descripcion = "Descripción 5", Precio = 500, Stock = 5, ImagenURL = "/images/producto5.jpg" },
            new Product { ProductoID = 1, Nombre = "Producto 6", Descripcion = "Descripción 1", Precio = 100, Stock = 50, ImagenURL = "/images/producto6.jpg" },
            new Product { ProductoID = 2, Nombre = "Producto 7", Descripcion = "Descripción 2", Precio = 200, Stock = 30, ImagenURL = "/images/producto7.jpg" },
            new Product { ProductoID = 3, Nombre = "Producto 8", Descripcion = "Descripción 3", Precio = 300, Stock = 20, ImagenURL = "/images/producto8.jpg" },
            new Product { ProductoID = 1, Nombre = "Producto 9", Descripcion = "Descripción 1", Precio = 100, Stock = 50, ImagenURL = "/images/producto1.jpg" },
            new Product { ProductoID = 2, Nombre = "Producto 10", Descripcion = "Descripción 2", Precio = 200, Stock = 30, ImagenURL = "/images/producto2.jpg" },
            new Product { ProductoID = 3, Nombre = "Producto 11", Descripcion = "Descripción 3", Precio = 300, Stock = 20, ImagenURL = "/images/producto3.jpg" },
            new Product { ProductoID = 1, Nombre = "Producto 12", Descripcion = "Descripción 1", Precio = 100, Stock = 50, ImagenURL = "/images/producto1.jpg" },
            new Product { ProductoID = 2, Nombre = "Producto 13", Descripcion = "Descripción 2", Precio = 200, Stock = 30, ImagenURL = "/images/producto2.jpg" },
            new Product { ProductoID = 3, Nombre = "Producto 14", Descripcion = "Descripción 3", Precio = 300, Stock = 20, ImagenURL = "/images/producto3.jpg" },
        };
            }
        }
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            var pagedProducts = _productos.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalProducts = _productos.Count();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)System.Math.Ceiling((double)totalProducts / pageSize);
            return View(pagedProducts);
        }
    }
}
