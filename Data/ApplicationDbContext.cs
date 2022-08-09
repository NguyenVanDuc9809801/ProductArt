using Main_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Main_project.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ProductsArt> ProductsArts { get; set; }

    public DbSet<Bill> Bills { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Blog> Blogs { get; set; }

}