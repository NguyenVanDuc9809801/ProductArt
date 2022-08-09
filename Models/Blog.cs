using System.ComponentModel.DataAnnotations;

namespace Main_project.Models;

public class Blog
{

    [Key]
    public int Id { get; set; }
    [Required]
    public string? Tilte { get; set; }
    [Required]
    public string? Content { get; set; }
    [Required]
    public string? Type { get; set; }
    [Required]
    public DateTime Time { get; set; }
    [Required]
    public virtual User? User {get;set;}

}