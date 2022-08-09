using System.ComponentModel.DataAnnotations;

namespace Main_project.Dtos
{
    public class UpLoadProductDtos
    {
        public string? ProductName { get; set; }

        public string? ProductTitle { get; set; }

        public string? ProductType { get; set; }

        public string? ContentType { get; set; }

        public string? ProductDescription { get; set; }

        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
        public List<IFormFile> ProductFile { get; set; } = new();

        public decimal Price { get; set; }

        public string? AuthorId { get; set; }

        public string? AuthorName { get; set; }

    }
}