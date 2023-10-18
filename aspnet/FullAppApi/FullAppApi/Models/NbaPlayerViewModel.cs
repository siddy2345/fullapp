using Microsoft.EntityFrameworkCore;

namespace FullAppApi.Models
{
    public class NbaPlayerViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Franchise { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
