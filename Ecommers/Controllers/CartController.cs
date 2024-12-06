using Ecommers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Ecommers.Controllers
{
    public class CartController : Controller
    {
        // Simula los datos del carrito de forma estática
        private static List<CartItem> Cart = new List<CartItem>
        {

        };

        // Método público para agregar un producto al carrito
        public void AddProductToCart(CartItem item)
        {
            Cart.Add(item);
        }

        // Método para actualizar el conteo de productos en el carrito
        private void UpdateCartCount()
        {
            ViewBag.CartCount = Cart.Sum(item => item.Quantity);  // Total de productos en el carrito
        }

        // Acción para mostrar el carrito
        public IActionResult Index()
        {
            // Calcular el subtotal
            var subtotal = Cart.Sum(item => item.TotalPrice);

            // Calcular IVA (16%)
            var iva = subtotal * 0.16m;

            // Calcular el total
            var total = subtotal + iva;

            // Formatear a pesos mexicanos
            var culture = new CultureInfo("es-MX");
            ViewData["Subtotal"] = subtotal.ToString("C", culture);
            ViewData["IVA"] = iva.ToString("C", culture);
            ViewData["Total"] = total.ToString("C", culture);

            // Actualizar el conteo de productos
            UpdateCartCount();

            // Pasar los productos al ViewBag para usarlos en el dropdown del _Layout
            ViewBag.CartItems = Cart;
            ViewBag.CartCount = Cart.Sum(item => item.Quantity);  // Total de productos en el carrito

            return View(Cart);
        }



        // Acción para agregar un producto al carrito
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var item = Cart.FirstOrDefault(x => x.Id == productId);

            if (item == null)
            {
                // Si el producto no está en el carrito, lo agregamos usando el método AddProductToCart
                var newItem = new CartItem
                {
                    Id = productId,
                    ProductName = "Nuevo Producto",  // Debes obtener los detalles del producto desde tu DB
                    Price = 100.00m, // Lo mismo aquí, obtener el precio del producto
                    Quantity = quantity
                };
                AddProductToCart(newItem);  // Usamos el método para agregar el producto
            }
            else
            {
                // Si el producto ya está en el carrito, solo actualizamos la cantidad
                item.Quantity += quantity;
            }

            // Actualizar el conteo de productos
            UpdateCartCount();

            // Redirigir al carrito
            return RedirectToAction("Index");
        }

        // Acción para incrementar la cantidad de un producto en el carrito
        public IActionResult Increment(int id)
        {
            var item = Cart.FirstOrDefault(x => x.Id == id);

            if (item != null && item.Quantity < 10)
            {
                item.Quantity++;
            }

            // Actualizar el conteo de productos
            UpdateCartCount();

            return RedirectToAction("Index");
        }

        // Acción para decrementar la cantidad de un producto en el carrito
        public IActionResult Decrement(int id)
        {
            var item = Cart.FirstOrDefault(x => x.Id == id);

            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }

            // Actualizar el conteo de productos
            UpdateCartCount();

            return RedirectToAction("Index");
        }

        // Acción para eliminar un producto del carrito
        public IActionResult Remove(int id)
        {
            var item = Cart.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                Cart.Remove(item);
            }

            // Actualizar el conteo de productos
            UpdateCartCount();

            return RedirectToAction("Index");
        }

        // Acción para limpiar el carrito
        public IActionResult ClearCart()
        {
            Cart.Clear();

            // Actualizar el conteo de productos
            UpdateCartCount();

            return RedirectToAction("Index");
        }
    }
}
