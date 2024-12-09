using Ecommers.Data;
using Ecommers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommers.Controllers
{
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Productos.ToList(); // Si tienes productos asignados al vendedor
            return View(products);
        }
    }
}