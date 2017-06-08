using System;

namespace Vedit.Infrastructure
{
    public static class FloatExtensions
    {
        public static double ToRadians(this float angle)
        {
            return Math.PI * angle / 180;
        }
    }
}