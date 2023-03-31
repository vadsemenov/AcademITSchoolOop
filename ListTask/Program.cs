namespace ListTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new SingleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            Console.WriteLine($"Размер списка: {list.GetSize()}");

            Console.WriteLine($"Значение первого элемента: {list.GetHeadValue()}");

            Console.WriteLine($"Изменение значения элемента по индексу 2: {list.SetValueByIndex(2, 11)}");
            Console.WriteLine($"Значение элемента по индексу 2 посла изменения: {list.GetValueByIndex(2)}");

            Console.WriteLine($"Удаление элемента по индексу 4: {list.DeleteByIndex(4)}");
            Console.WriteLine($"Значение элемента по индексу 4: {list.GetValueByIndex(4)}");

            list.InsertHead(10);
            Console.WriteLine($"Значение первого элемента: {list.GetHeadValue()}");

            list.InsertByIndex(4, 22);
            Console.WriteLine($"Значение элемента по индексу 4: {list.GetValueByIndex(4)}");

            Console.WriteLine($"Удаление элемента со значением 11: {list.DeleteByValue(11)}");

            Console.WriteLine($"Удаление первого элемента: {list.DeleteHead()}");

            list.Reverse();
            Console.WriteLine($"Значение первого элемента после разворота: {list.GetHeadValue()}");
            Console.WriteLine($"Значение второго элемента после разворота: {list.GetValueByIndex(2)}");

            var list2 = list.Copy();
            Console.WriteLine($"Значение первого элемента исходного листа: {list.GetHeadValue()}");
            Console.WriteLine($"Значение первого элемента скопированного листа: {list2.GetHeadValue()}");

            list2.InsertHead(10);
            Console.WriteLine($"Значение первого элемента исходного листа: {list.GetHeadValue()}");
            Console.WriteLine($"Значение первого элемента скопированного листа: {list2.GetHeadValue()}");
            Console.WriteLine($"Значение четвертого элемента скопированного листа: {list2.GetValueByIndex(4)}");

            Console.Read();
        }
    }
}