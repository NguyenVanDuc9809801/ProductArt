using Microsoft.AspNetCore.Mvc;

namespace Main_project.Controllers
{
    public class ArtristController : Controller
    {
        public ArtristController(){

        }
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
    }
}