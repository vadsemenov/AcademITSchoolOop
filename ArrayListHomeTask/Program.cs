using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textFileLines = new FileInfo("..\\..\\1.txt").GetFileLinesList();

            Console.WriteLine("Содержимое файла:");
            foreach (var line in textFileLines)
            {
                Console.WriteLine(line);
            }

            var list = new List<int>() { 1, 5, 2, 1, 3, 5 }.RemoveEvenNumbers();
            Console.WriteLine("Список после удаления четных чисел: " + string.Join(" ", list));

            Console.WriteLine("Список после удаления повторяющихсял чисел: " + string.Join(" ", list.GetNotRepeatingNumbersList()));

            Console.Read();
        }
    }
}
