namespace ArrayListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SimpleArrayList<string> { null, "1", "2", "3", "4", "5", "6", "7" };

            list.Add("8");

            Console.WriteLine(list.IndexOf(null));

            Console.WriteLine(list.Count);

            list.Insert(8, "9");
            list.Insert(9, "10");

            Console.WriteLine(list);

            Console.WriteLine("Элемент по индексу 3: " + list[3]);

            list[3] = "22";
            Console.WriteLine("Заменить элемент по индексу 3: " + list);

            list.RemoveAt(3);
            Console.WriteLine("Удалить элемент по индексу 3: " + list);

            Console.WriteLine("Количество элементов в списке: " + list.Count);

            Console.WriteLine("Вместимость: " + list.Capacity);
            list.TrimExcess();
            Console.WriteLine("Вместимость списка после TrimExcess: " + list.Capacity);

            Console.WriteLine("Список содержит 7: " + list.Contains("7"));
            list.Remove("7");
            Console.WriteLine("Список содержит 7 после удаления: " + list.Contains("7"));

            Console.WriteLine("Список содержит null: " + list.Contains(null));
            list.Remove(null);
            Console.WriteLine("Список содержит null после удаления: " + list.Contains(null));

            Console.WriteLine("Список до вставки элемента: " + list);
            list.Insert(4, "101");
            Console.WriteLine("Вставить 101 по индексу 4: " + list);

            var numbers = list.Select(x => x?.ToString()).ToArray();
            Console.WriteLine("Проверка Enumerator: " + string.Join(", ", numbers));

            list.Clear();
            Console.WriteLine("После Clear: " + list);

            Console.Read();
        }
    }
}