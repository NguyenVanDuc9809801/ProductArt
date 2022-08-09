using Main_project.Data;
using Main_project.Dtos;
using Main_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Main_project.Service
{
    public class BlogService
    {
        private readonly ApplicationDbContext dbContext;

        public BlogService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<BlogInfoDtos>> GetBlogsInfoAsync()
        {
            var result = await dbContext.Blogs.Select(blog => new BlogInfoDtos
            {
                Id = blog.Id,
                Tilte = blog.Tilte,
                Type = blog.Type,
                Time = blog.Time
            }).Take(5).ToListAsync();

            return result;
        }
        public async Task<Blog?> GetBlogIdAsync(int Id)
        {
            var result = await dbContext.Blogs.FirstOrDefaultAsync(blog => blog.Id == Id);
            return result;
        }
        public async Task CreateBlogAsync(Blog blog)
        {
            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();
        }
        public async Task UpDateBlogAsync(Blog blog)
        {
             dbContext.Blogs.Update(blog);
             await dbContext.SaveChangesAsync();
        }
        public async Task<bool> DeleteBlogAsync(int Id){
            var blog = await this.GetBlogIdAsync(Id);
            if(blog!=null){
            dbContext.Blogs.Remove(blog);
            return true;
            }else{
                return false;
            }
        }
    }
}