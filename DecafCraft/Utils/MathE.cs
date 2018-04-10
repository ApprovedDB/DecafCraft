using System;

namespace DecafCraft.Utils
{
    public static class MathE
    {
        private const double Double180Dpi = 180 * Math.PI;
        private const decimal Decimal180Dpi = (decimal) (180 * Math.PI);

        public static double ToDegrees(double radians)
        {
            return radians * Double180Dpi;
        }

        public static decimal ToDegrees(decimal radians)
        {
            return radians * Decimal180Dpi;
        }

        public static double ToRadians(double degrees)
        {
            return degrees / Double180Dpi;
        }

        public static decimal ToRadians(decimal degrees)
        {
            return degrees / Decimal180Dpi;
        }
    }
}