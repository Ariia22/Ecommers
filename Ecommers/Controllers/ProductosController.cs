using Ecommers.Data;
using Ecommers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ecommers.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para listar productos
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        // Acción para mostrar el formulario de edición
        public IActionResult Edit(int id)
        {
            var product = _context.Productos.FirstOrDefault(p => p.ProductoID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Acción para manejar la edición (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Acción para eliminar un producto
        public IActionResult Delete(int id)
        {
            var product = _context.Productos.FirstOrDefault(p => p.ProductoID == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Acción para manejar la eliminación (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Productos.FirstOrDefault(p => p.ProductoID == id);
            if (product != null)
            {
                _context.Productos.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
