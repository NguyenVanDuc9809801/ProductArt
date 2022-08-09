using Main_project.Dtos;
using Main_project.Models;
using Main_project.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Main_project.Controllers
{

    [Authorize]
    public class ServiceController : Controller
    {
        private readonly ProductService productService;
        private readonly IHostingEnvironment env;

        public ServiceController(ProductService productService, IHostingEnvironment env)
        {
            this.productService = productService;
            this.env = env;
        }

        [HttpGet]
        public IActionResult UpLoadProduct()
        {
            var uploadDtos = new UpLoadProductDtos() { };
            return View(uploadDtos);
        }
        [HttpPost]
        public async Task<IActionResult> UpLoadProduct(UpLoadProductDtos upload)
        {
            var file = Path.Combine(env.ContentRootPath, "uploads", upload.ProductFile[0].FileName);
            using (var filestream = new FileStream(file, FileMode.Create))
            {
                await upload.ProductFile[0].CopyToAsync(filestream);
            }
            var productsArt = new ProductsArt()
            {
                Name = upload.ProductName,
                Title = upload.ProductTitle,
                Description = upload.ProductDescription,
                Price = upload.Price,
                FilePath = file,
                ArtType = upload.ProductType,
                ContentType = upload.ContentType,
                AuthorId = upload.AuthorId,
                AuthorName = upload.AuthorName
            };
            await productService.UploadProduct(productsArt);
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        public async Task<IActionResult> ListProduct(){
           var products =  await productService.GetProductsInfo();
            return View(products);
        }
        
    }

}