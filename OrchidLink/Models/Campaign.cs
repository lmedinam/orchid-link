using System.ComponentModel.DataAnnotations;

namespace OrchidLink.Models
{
    public class Campaign
    {
        public Campaign()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = System.DateTime.Now;
    }
}
