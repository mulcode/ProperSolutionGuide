using PSG.BusinessLogicLayer;
using PSG.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PSG.Mvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductLogicLayer nextLayer = new ProductLogicLayer();
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
            ProductLogicLayer nextLayer = new ProductLogicLayer();
            List<Product> products = nextLayer.GetProducts();

            return View(products);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductLogicLayer nextLayer = new ProductLogicLayer();
            Product result = nextLayer.GetProductById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            ProductLogicLayer nextLayer = new ProductLogicLayer();
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
            ProductLogicLayer nextLayer = new ProductLogicLayer();
            bool result = nextLayer.Delete(id);
            if (result != true)
            {
                return BadRequest(new { Message = "failed to delete" });
            }
            return RedirectToAction("Products", "Product");
        }
    }
}