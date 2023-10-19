namespace FullAppApi.DTOs
{
    public class UpdateNbaPlayerDto
    {
        public int Id { get; set; }
        public string Franchise { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
