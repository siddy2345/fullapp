namespace FullAppApi.API.DTOs
{
    public class NbaPlayerDto
    {
        public int Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Franchise { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
