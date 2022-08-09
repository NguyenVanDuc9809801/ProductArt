namespace Main_project.Dtos
{
    public class ProductInfoDtos
    {
        public string? filePath { set; get; }
        public string? ProductName { set; get; } 

        public string? AuthorName { set; get; } 

        public decimal Price { get; set; }
        public int likes { get; set; }
        public int Comments { get; set; }
    }
}