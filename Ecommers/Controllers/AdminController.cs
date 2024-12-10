using Ecommers.Models;
using Ecommers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommers.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para la vista de Index
        public IActionResult Index()
        {
            try
            {
                var products = _context.Productos.ToList(); // Traer todos los productos
                if (products == null || !products.Any())
                {
                    // Si no hay productos, mostrar un mensaje de advertencia
                    ViewData["Message"] = "No hay productos disponibles en la tienda.";
                }
                return View(products);
            }
            catch (Exception ex)
            {
                // Captura cualquier error y registra en el log
                // Aquí puedes usar un Logger para más detalles
                ViewData["Error"] = "Hubo un problema al cargar los productos: " + ex.Message;
                return View();
            }
        }

        // Acción para editar un producto
        public IActionResult Edit(int id)
        {
            try
            {
                var product = _context.Productos.FirstOrDefault(p => p.ProductoID == id);
                if (product == null)
                {
                    // Si no se encuentra el producto, muestra una página de error
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                // Loguear el error
                ViewData["Error"] = "Hubo un problema al cargar el producto: " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

                // Si el modelo no es válido, retornar la misma vista
                return View(product);
            }
            catch (Exception ex)
            {
                // Loguear el error y notificar
                ViewData["Error"] = "Hubo un problema al guardar los cambios: " + ex.Message;
                return View(product);
            }
        }

        // Acción para eliminar un producto
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = _context.Productos.Find(id);
                if (product != null)
                {
                    _context.Productos.Remove(product);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Loguear el error y notificar
                ViewData["Error"] = "Hubo un problema al eliminar el producto: " + ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
