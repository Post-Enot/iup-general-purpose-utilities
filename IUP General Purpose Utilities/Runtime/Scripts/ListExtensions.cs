using System.Collections.Generic;

namespace IUP.Toolkits
{
    public static class ListExtensions
    {
        /// <summary>
        /// Перемещает элемент на позицию переданного индекса, передвигая все остальные элементы.
        /// </summary>
        /// <param name="from">Индекс передвигаемого элемента.</param>
        /// <param name="to">Индекс, на который передвигается элемент.</param>
        public static void MoveItemFromTo<T>(this List<T> list, int from, int to)
        {
            T movedItem = list[from];
            list.RemoveAt(from);
            list.Insert(to, movedItem);
        }
    }
}
