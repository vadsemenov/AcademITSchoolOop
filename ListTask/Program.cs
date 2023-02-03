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

            list.Reverse();

            var list2 = list.Copy();

            list2.InsertHead(10);
            Console.WriteLine(list2.GetHeadValue());
            Console.WriteLine(list2.GetValueByIndex(1));
            Console.WriteLine(list.GetHeadValue());

            Console.Read();
        }
    }
}