using Main_project.Service;
using Microsoft.AspNetCore.Mvc;

namespace Main_project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        //[HttpGet("Detail/{Id}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int Id)
        {
            var product = await productService.GetProductIdAsync(Id);
            return View(product);
        }
    }
}