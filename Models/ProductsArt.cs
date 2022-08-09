using System.ComponentModel.DataAnnotations;

namespace Main_project.Models
{

    public class ProductsArt
    {
        public ProductsArt()
        {
            Users = new HashSet<User>();
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? FilePath { get; set; }
        [Required]
        public string? ArtType { get; set; }
        [Required]
        public string? ContentType { get; set; }
        [Required]
        public string? AuthorName { get; set; }
        [Required]
        public string? AuthorId { get; set; }
        public virtual ICollection<User> Users { get; set; } 

        public virtual ICollection<Comment> Comments { get; set; }
    }
}