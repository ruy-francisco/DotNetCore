using System;
using System.ComponentModel.DataAnnotations;

namespace DoubleRound.Models
{
    public class DoubleRound
    {
        public int Id { get; set; }
     
        [Required]
        public DateTime Begin { get; set; }

        [Required]
        public DateTime End { get; set; }
        
        [Required]
        public string Place { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public string PlaceId { get; set; }

        [Required]
        public string Address { get; set; }
    }
}