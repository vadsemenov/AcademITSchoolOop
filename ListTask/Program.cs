namespace ListTask;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new SingleLinkedList<string> { null, "2", "3", "4", "5", "6" };

        Console.WriteLine(list1);

        Console.WriteLine($"Размер списка: {list1.Count}");

        Console.WriteLine($"Значение первого элемента: {list1.GetFirst()}");

        Console.WriteLine($"Удаление первого элемента: {list1.DeleteByIndex(0)}");

        Console.WriteLine($"Изменение значения элемента по индексу 2: {list1.SetByIndex(2, "11")}");
        Console.WriteLine($"Значение элемента по индексу 2 после изменения: {list1}");

        Console.WriteLine($"Удаление элемента по индексу 4: {list1.DeleteByIndex(4)}");
        Console.WriteLine($"Значение элемента по индексу 3: {list1.GetByIndex(3)}");

        Console.WriteLine(list1);
        Console.WriteLine($"Изменение значения элемента по индексу 2: {list1.SetByIndex(2, null)}");
        Console.WriteLine($"Удаление элемента со значением 11: {list1.DeleteByValue(null)}");

        list1.AddFirst("10");
        Console.WriteLine($"Значение первого элемента: {list1.GetFirst()}");

        list1.InsertByIndex(4, "22");
        Console.WriteLine($"Значение элемента по индексу 4: {list1.GetByIndex(4)}");

        list1.Add(null);
        Console.WriteLine($"Удаление элемента со значением null: {list1.DeleteByValue(null)}");

        Console.WriteLine($"Удаление элемента со значением 11: {list1.DeleteByValue("11")}");

        Console.WriteLine($"Удаление первого элемента: {list1.DeleteFirst()}");

        list1.Reverse();
        Console.WriteLine($"Значения после разворота: {list1}");

        Console.WriteLine(list1);
        Console.WriteLine($"Размер списка: {list1.Count}");

        var list2 = list1.Copy();
        Console.WriteLine($"Значения исходного списка: {list1}");
        Console.WriteLine($"Значение скопированного списка: {list2}");

        list2.AddFirst("10");
        Console.WriteLine($"Значения исходного списка: {list1}");
        Console.WriteLine($"Значения скопированного списка: {list2}");
        Console.WriteLine($"Размер скопированного списка: {list2.Count}");

        Console.Read();
    }
}