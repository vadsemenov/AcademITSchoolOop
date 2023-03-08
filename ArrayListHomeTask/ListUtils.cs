using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHomeTask
{
    public static class ListUtils
    {
        public static List<string> GetFileLinesList(FileInfo file)
        {
            var lines = new List<string>();

            if (!file.Exists)
            {
                throw new FileNotFoundException("Файл не найден", file.Name);
            }

            try
            {
                using var reader = new StreamReader(file.FullName);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return lines;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List не должен быть равен null");
            }

            try
            {
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i] % 2 == 0)
                    {
                        list.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static List<int> GetNotRepeatingNumbersList(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List не должен быть равен null");
            }

            var resultList = new List<int>(list.Count);

            try
            {
                foreach (var number in list)
                {
                    if (!resultList.Contains(number))
                    {
                        resultList.Add(number);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return resultList;
        }
    }
}