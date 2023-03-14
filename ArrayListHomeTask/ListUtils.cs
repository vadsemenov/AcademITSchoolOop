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

            using var reader = new StreamReader(file.FullName);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public static void RemoveEvenNumbers(List<int> list)
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

        public static List<int> GetNotRepeatingNumbersList(List<int> list)
        {
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