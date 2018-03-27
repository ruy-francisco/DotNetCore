using DoubleRound.Models.Contracts;

namespace DoubleRound.Models
{
    public class Provider: IProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PlaceId { get; set; }
        public string Address { get; set; }
    }
}