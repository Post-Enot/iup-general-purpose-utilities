namespace IUP.Toolkits
{
    public static class IntTypesExtension
    {
        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this byte @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this byte @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this sbyte @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this sbyte @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this short @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this short @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this ushort @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this ushort @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this int @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this int @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this uint @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this uint @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this long @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this long @this)
        {
            return @this % 2 == 1;
        }

        /// <summary>
        /// Проверяет, является ли число чётным.
        /// </summary>
        /// <returns>Возвращает true, если число чётное; иначе false.</returns>
        public static bool IsEven(this ulong @this)
        {
            return @this % 2 == 0;
        }

        /// <summary>
        /// Проверяет, является ли число нечётным.
        /// </summary>
        /// <returns>Возвращает true, если число нечётное; иначе false.</returns>
        public static bool IsOdd(this ulong @this)
        {
            return @this % 2 == 1;
        }
    }
}
