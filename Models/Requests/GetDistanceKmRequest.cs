namespace DistanceApi.Models.Requests;

public record GetDistanceKmRequest(GeoPoint StartPoint, GeoPoint EndPoint);
