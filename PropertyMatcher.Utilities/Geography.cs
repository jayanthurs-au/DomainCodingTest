using System;

namespace PropertyMatcher.Utilities
{
    public static class Geography
    {
        private const double PIx = 3.141592653589793;
        private const double Radius = 6378.16;

        /// <summary>
        /// Convert degrees to Radians
        /// </summary>
        /// <param name="x">Degrees</param>
        /// <returns>The equivalent in radians</returns>
        private static double Radians(double x)
        {
            return x * PIx / 180;
        }
        /// <summary>
        /// Calculate the distance between two places.
        /// </summary>
        /// <param name="longitude1"></param>
        /// <param name="latitude1"></param>
        /// <param name="longitude2"></param>
        /// <param name="latitude2"></param>
        /// <returns></returns>
        public static double DistanceBetweenCoordinates(
            double longitude1,
            double latitude1,
            double longitude2,
            double latitude2)
        {
            double dlon = Radians(longitude2 - longitude1);
            double dlat = Radians(latitude2 - latitude1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(latitude1)) * Math.Cos(Radians(latitude2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return angle * Radius;
        }

        public static double DistanceBetweenCoordinates(decimal longitude1, decimal latitude1, decimal longitude2, decimal latitude2)
        {
            return DistanceBetweenCoordinates((double) longitude1, (double) latitude1, (double) longitude2,
                (double) latitude2);
        }
    }
}
