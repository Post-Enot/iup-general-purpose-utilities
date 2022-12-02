using UnityEngine;

namespace IUP.Toolkits
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Делает передаваемый цвет контрастным этому.
        /// </summary>
        /// <param name="color">Цвет, который необходимо сделать контрастным этому.</param>
        /// <returns>Возвращает контрастную версию цвета.</returns>
        public static Color MakeContrast(this Color @this, Color color)
        {
            if (@this.IsDark())
            {
                return MakeLight(color);
            }
            else
            {
                return MakeDark(color);
            }
        }

        /// <summary>
        /// Проверяет, является ли цвет тёмным.
        /// </summary>
        /// <returns>Возвращает True, если цвет тёмный: иначе False.</returns>
        public static bool IsDark(this Color color)
        {
            Color.RGBToHSV(color, out _, out _, out float V);
            return V <= 0.5f;
        }

        /// <summary>
        /// Проверяет, является ли цвет светлым.
        /// </summary>
        /// <returns>Возвращает True, если цвет светлый: иначе False.</returns>
        public static bool IsLight(this Color color)
        {
            Color.RGBToHSV(color, out _, out _, out float V);
            return V >= 0.5f;
        }

        /// <summary>
        /// Создаёт тёмную версию цвета.
        /// </summary>
        /// <returns>Возвращает тёмную версию цвета.</returns>
        public static Color MakeDark(this Color color)
        {
            Color.RGBToHSV(color, out float H, out float S, out float V);
            if (V > 0.5f)
            {
                V = 1f - V;
                color = Color.HSVToRGB(H, S, V);
            }
            return color;
        }

        /// <summary>
        /// Создаёт светлую версию цвета.
        /// </summary>
        /// <returns>Возвращает светлую версию цвета.</returns>
        public static Color MakeLight(this Color color)
        {
            Color.RGBToHSV(color, out float H, out float S, out float V);
            if (V < 0.5f)
            {
                V = 1f - V;
                color = Color.HSVToRGB(H, S, V);
            }
            return color;
        }
    }
}
