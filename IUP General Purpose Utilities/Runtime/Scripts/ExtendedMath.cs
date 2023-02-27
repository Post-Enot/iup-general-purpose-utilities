using System;

namespace IUP.Toolkits
{
    public static class ExtendedMath
    {
        public static double RoundWithStep(double number, double step)
        {
            return Math.Round(number / step) * step;
        }
    }
}
