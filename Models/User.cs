using Microsoft.AspNetCore.Identity;

namespace Main_project.Models
{

    public class User : IdentityUser
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Bills = new HashSet<Bill>();
            Comments = new HashSet<Comment>();
            ProductArts = new HashSet<ProductsArt>();
        }
        public virtual string? Address { get; set; }
        public virtual string? Sex { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<ProductsArt> ProductArts { get; set; }


    }
}