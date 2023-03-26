using System;
using UnityEngine;

namespace IUP.Toolkits
{
    public static class ExtendedMath
    {
        public static double RoundWithStep(double number, double step)
        {
            return Math.Round(number / step) * step;
        }

        public static Vector2 RotateVector2(Vector2 vector, float rotationInRadian)
        {
            float x = (vector.x * Mathf.Cos(rotationInRadian)) - (vector.y * Mathf.Sin(rotationInRadian));
            float y = (vector.x * Mathf.Sin(rotationInRadian)) + (vector.y * Mathf.Cos(rotationInRadian));
            return new Vector2(x, y);
        }
    }
}
