namespace DoubleRound.Models.Contracts
{
    public interface IProvider
    {
        int Id { get; set; }
        string Name { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
        string PlaceId { get; set; }
        string Address { get; set; }
    }
}