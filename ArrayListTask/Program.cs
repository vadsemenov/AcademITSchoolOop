using System;
using System.Linq;

namespace ArrayListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SimpleArrayList<int>(100) { 1, 2, 3, 4, 5, 6, 7 };

            Console.WriteLine("Элемент по индексу 3: " + list[3]);

            list[3] = 22;
            Console.WriteLine("Заменить элемент по индексу 3: " + list);

            list.RemoveAt(3);
            Console.WriteLine("Удалить элемент по индексу 3: " + list);

            Console.WriteLine("Количество элементов в списке: " + list.Count);

            Console.WriteLine("Вместимость: " + list.Capacity);
            list.TrimExcess();
            Console.WriteLine("Вместимость списка после TrimExcess: " + list.Capacity);

            Console.WriteLine("Список содержит 7: " + list.Contains(7));
            list.Remove(7);
            Console.WriteLine("Список содержит 7 после удаления: " + list.Contains(7));

            Console.WriteLine("Список до вставки элемента: " + list);
            list.Insert(4, 101);
            Console.WriteLine("Вставить 101 по индексу 4: " + list);

            var numbers = list.Select(x => x.ToString()).ToArray();
            Console.WriteLine("Проверка Enumerator: " + string.Join(", ", numbers));

            Console.Read();
        }
    }
}
