namespace Main_project.Dtos
{
    public class BlogCreateDtos
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Content { get; set; }
        public string? Type { get; set; }

        public string? UserId { get; set; }
    }
}