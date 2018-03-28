using System;
using System.ComponentModel.DataAnnotations;

namespace DoubleRound.Models
{
    public class DoubleRound
    {
        public int Id { get; set; }
     
        [Required]
        public DateTime BeginDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        
        [Required]
        public string Place { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public string PlaceId { get; set; }

        [Required]
        public string PlaceAddress { get; set; }
    }
}