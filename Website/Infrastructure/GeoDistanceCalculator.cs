using System;

namespace Website.Infrastructure
{
  public class GeoDistanceCalculator
  {
    const double PIx = Math.PI;
    const double RADIUS = 6371;

    public static double Radians(double x)
    {
      return x * PIx / 180;
    }

    public static double DistanceBetweenPlaces(double lat1, double lon1, double lat2, double lon2)
    {
      var sLat1 = Math.Sin(Radians(lat1));
      var sLat2 = Math.Sin(Radians(lat2));
      var cLat1 = Math.Cos(Radians(lat1));
      var cLat2 = Math.Cos(Radians(lat2));

      double cLon = Math.Cos(Radians(lon1) - Radians(lon2));

      double cosD = sLat1 * sLat2 + cLat1 * cLat2 * cLon;
      double d = Math.Acos(cosD);

      double dist = RADIUS * d;

      return dist;

      //var dLongitude = eLongitudeRadians - sLongitudeRadians;
      //var dLatitude = eLatitudeRadians - sLatitudeRadians;

      //var result1 = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
      //              Math.Cos(sLatitudeRadians) * Math.Cos(eLatitudeRadians) *
      //              Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

      //// Using 3956 as the number of miles around the earth
      //var result2 = RADIUS * Math.Atan2(Math.Sqrt(result1), Math.Sqrt(1.0 - result1));

      //return result2;
    }
  }
}