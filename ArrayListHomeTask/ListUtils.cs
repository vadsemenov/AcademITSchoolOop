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

            using var reader = new StreamReader(file.FullName);

            var line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public static List<int> RemoveEvenNumbers(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List не должен быть равен null");
            }

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            return list;
        }

        public static List<int> GetNotRepeatingNumbersList(List<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List не должен быть равен null");
            }

            var resultList = new List<int>(list.Count);

            foreach (var number in list)
            {
                if (!resultList.Contains(number))
                {
                    resultList.Add(number);
                }
            }

            return resultList;
        }
    }
}