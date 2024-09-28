using PSG.BusinessLogicLayer;
using PSG.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using PSG.Shared.Interfaces;

namespace PSG.Mvc.Controllers
{
    public class ProductController : Controller
    {
        IProductBusinessLayer nextLayer;

        public ProductController(IProductBusinessLayer layer)
        {
            nextLayer = layer;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            bool result = nextLayer.Create(product);
            if (result == true)
            {
                return RedirectToAction("Products", "Product");
            }
            return BadRequest(new { Message = "Failed to create" });
        }

        [HttpGet]
        public IActionResult Products()
        {
            List<Product> products = nextLayer.GetProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product result = nextLayer.GetProductById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            bool result = nextLayer.Update(product);

            if (result == true)
            {
                return RedirectToAction("Products", "Product");
            }

            return BadRequest(new { Message = "Update unsuccessful." });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool result = nextLayer.Delete(id);
            if (result != true)
            {
                return BadRequest(new { Message = "failed to delete" });
            }
            return RedirectToAction("Products", "Product");
        }
    }
}