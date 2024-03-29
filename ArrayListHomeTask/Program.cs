﻿namespace ArrayListHomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo("..\\..\\..\\1.txt");

            try
            {
                var textFileLines = ListUtils.GetFileLinesList(file);

                Console.WriteLine("Содержимое файла:");
                foreach (var line in textFileLines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine("Произошла ошибка: " + fnfe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка: " + e.Message);
            }

            var list = new List<int> { 1, 5, 2, 1, 3, 5 };

            ListUtils.RemoveEvenNumbers(list);
            Console.WriteLine("Список после удаления четных чисел: " + string.Join(" ", list));

            Console.WriteLine("Список после удаления повторяющихся чисел: " +
                              string.Join(" ", ListUtils.GetNotRepeatingNumbersList(list)));

            Console.Read();
        }
    }
}