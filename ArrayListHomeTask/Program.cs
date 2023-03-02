using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var textFileLines = ListUtils.GetFileLinesList(new FileInfo("..\\..\\1.txt"));

            Console.WriteLine("Содержимое файла:");
            foreach (var line in textFileLines)
            {
                Console.WriteLine(line);
            }

            var list = ListUtils.RemoveEvenNumbers(new List<int> { 1, 5, 2, 1, 3, 5 });
            Console.WriteLine("Список после удаления четных чисел: " + string.Join(" ", list));

            Console.WriteLine("Список после удаления повторяющихся чисел: " + string.Join(" ", ListUtils.GetNotRepeatingNumbersList(list)));

            Console.Read();
        }
    }
}
