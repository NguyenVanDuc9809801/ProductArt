using System.ComponentModel.DataAnnotations;

namespace Main_project.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Content { get; set; }
        [Range(0, 5)]
        public int Star { get; set; }
        [Required]
        public virtual User? User {get;set;}
      
        [Required]
        public virtual ProductsArt? ProductsArt {get;set;}
    }
}