using Main_project.Dtos;
using Main_project.Models;
using Main_project.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Main_project.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogService blogService;
        private readonly UserManager<User> userManager;

        public BlogController(BlogService blogService, UserManager<User> userManager)
        {
            this.blogService = blogService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await blogService.GetBlogsInfoAsync();
            return View(blogs);
        }
        [HttpGet("Blog/BlogId/{Id}")]
        public async Task<IActionResult> BlogId(int Id)
        {
            var blog = await blogService.GetBlogIdAsync(Id);
            if (blog == null) return RedirectToAction("Index", "Home");
            return View(blog);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogCreateDtos blogDtos)
        {
            var blog = new Blog()
            {
                Tilte = blogDtos.Title,
                Content = blogDtos.Content,
                Type = blogDtos.Type,
                Time = DateTime.Now,
                User = await userManager.GetUserAsync(User),
            };
            await blogService.CreateBlogAsync(blog);
            return RedirectToAction("GetBlogs", "Blog");
        }
        [HttpGet]
        public IActionResult UpdateBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateBlog(string blog)
        {
            return View();
        }
    }
}