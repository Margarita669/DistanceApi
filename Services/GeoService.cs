using DistanceApi.Models;

namespace DistanceApi.Services;

public class GeoService
{
    private const double EarthRadiusKm = 6371;

    public double CalculateDistanceKm(GeoPoint startPoint, GeoPoint endPoint)
    {
        var startLatitude = DegreesToRadians(startPoint.Latitude);
        var startLongitude = DegreesToRadians(startPoint.Longitude);
        var endLatitude = DegreesToRadians(endPoint.Latitude);
        var endLongitude = DegreesToRadians(endPoint.Longitude);

        var haversineValue = Math.Pow(Math.Sin((endLatitude - startLatitude) / 2), 2) +
            Math.Cos(startLatitude) * Math.Cos(endLatitude) * Math.Pow(Math.Sin((endLongitude - startLongitude) / 2), 2);

        var centralAngle =
            2 * Math.Atan2(
                Math.Sqrt(haversineValue),
                Math.Sqrt(1 - haversineValue));

        return EarthRadiusKm * centralAngle;
    }

    private double DegreesToRadians(double degrees)
    {
        return degrees / 180 * Math.PI;
    }
}
