using System.ComponentModel.DataAnnotations;

namespace DoubleRound.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public string PlaceId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}