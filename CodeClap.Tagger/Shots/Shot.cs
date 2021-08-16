
namespace CodeClap.Tagger.Shots;

public record Shot (Guid Id, string Pilot, string Craft, DateTimeOffset CreatedAt, Location Location);

public record Location(double Longitude, double Latitude);
