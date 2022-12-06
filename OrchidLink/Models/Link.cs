using System.Reflection.Metadata;

namespace OrchidLink.Models
{
    public class Link
    {
        public Link()
        {
            Id = Guid.NewGuid().ToString();
            Slug = RandomString.Generate();
        }
        public string Id { get; set; }
        public string Destination { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; } = System.DateTime.Now;
        public Campaign? Campaign { get; set; }
    }
}
