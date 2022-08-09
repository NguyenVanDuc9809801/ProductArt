using System.ComponentModel.DataAnnotations;

namespace Main_project.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Info { get; set; } = default;
        [Required]
        public int UserId { get; set; }
        [Required]
        public virtual User? User { get; set; }
       
        [Required]
        public virtual ProductsArt? ProductsArt{get;set;}
}
}