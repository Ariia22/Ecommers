//using Ecommers.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Ecommers.Controllers
//{
//    public class ProductosController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public ProductosController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
//        {
//            var totalProducts = await _context.Productos.CountAsync();
//            var pagedProducts = await _context.Productos
//                .Skip((page - 1) * pageSize)
//                .Take(pageSize)
//                .ToListAsync();

//            ViewBag.CurrentPage = page;
//            ViewBag.TotalPages = (int)System.Math.Ceiling((double)totalProducts / pageSize);

//            return View(pagedProducts);
//        }
//    }
//}
