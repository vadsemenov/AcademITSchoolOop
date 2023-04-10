namespace HashTableTask;
public class Program
{
    static void Main(string[] args)
    {
        var hashTable = new HashTable<int>(10)
        {
            56,
            56,
            56,
            5,
            6,
            7
        };

        Console.WriteLine("Содержимое HashTable: " + hashTable);

        hashTable.Remove(56);
        Console.WriteLine("После удаления 56: " + hashTable);
        Console.WriteLine("Размер HashTable: " + hashTable.Count);

        Console.WriteLine("HashTable содержит 6: " + hashTable.Contains(6));

        hashTable.Clear();
        Console.WriteLine("HashTable после очистки: " + hashTable);
        Console.WriteLine("Размер HashTable после очистки: " + hashTable.Count);

        Console.Read();
    }
}