using System;

namespace IUP.Toolkits
{
    public static class StringExtensions
    {
        /// <summary>
        /// Получает строку по номеру (нумерация начинается с единицы). Если номер меньше 1 или количество строк 
        /// меньше номера запрашиваемой строки, вызывает ArgumentException.
        /// </summary>
        /// <param name="lineNumber">Номер строки (нумерация начинается с единицы).</param>
        /// <returns>Возвращает строку по указанному номеру.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetLine(this string @string, int lineNumber)
        {
            if (lineNumber < 1)
            {
                throw new ArgumentException("Номер строки не может быть меньше 1.");
            }
            int lineStartIndex = 0;
            int lineEndIndex = @string.IndexOf(Environment.NewLine, lineStartIndex);

            for (int i = 1; i < lineNumber; i += 1)
            {
                if (lineEndIndex == -1)
                {
                    throw new ArgumentException(
                        "Количество строк в строке меньше запрашиваемого номера.", nameof(lineNumber));
                }
                lineStartIndex = lineEndIndex + Environment.NewLine.Length;
                lineEndIndex = @string.IndexOf(Environment.NewLine, lineStartIndex);
            }

            if (lineEndIndex == -1)
            {
                return @string[lineStartIndex..];
            }
            return @string[lineStartIndex..lineEndIndex];
        }
    }
}
