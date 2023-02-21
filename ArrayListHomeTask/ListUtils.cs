using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArrayListHomeTask
{
    public static class ListUtils
    {
        public static List<string> GetFileLinesList(this FileInfo file)
        {
            var lines = new List<string>();

            if (!file.Exists)
            {
                return lines;
            }

            using var reader = new StreamReader(file.FullName);

            while (reader.ReadLine() is { } line)
            {
                lines.Add(line);
            }

            return lines;
        }

        public static List<int> RemoveEvenNumbers(this List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            return list;
        }

        public static List<int> GetNotRepeatingNumbersList(this List<int> list)
        {
            var resultList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (!resultList.Contains(list[i]))
                {
                    resultList.Add(list[i]);
                }
            }

            return resultList;
            // return list.Distinct().ToList();
        }
    }
}