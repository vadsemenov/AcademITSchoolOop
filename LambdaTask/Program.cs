using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Name = "Иван",
                    Age = 13
                },
                new Person
                {
                    Name = "Сергей",
                    Age = 16
                },
                new Person
                {
                    Name = "Сергей",
                    Age = 17
                },
                new Person
                {
                    Name = "Петр",
                    Age = 18
                },
                new Person
                {
                    Name = "Никита",
                    Age = 20
                },
                new Person
                {
                    Name = "Василий",
                    Age = 35
                },
                new Person
                {
                    Name = "Дмитрий",
                    Age = 45
                },
                new Person
                {
                    Name = "Алексей",
                    Age = 46
                },
                new Person
                {
                    Name = "Максим",
                    Age = 55
                }
            };

            var uniqueNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToArray();
            Console.WriteLine("Список уникальных имен: " + string.Join(", ", uniqueNames));

            var notAdultPersonsAverageAge = persons
                .Where(p => p.Age < 18)
                .Average(p => p.Age);
            Console.WriteLine("Средний возраст людей младше 18 лет: " + notAdultPersonsAverageAge);

            var averageAgesByName = persons
                .GroupBy(p => p.Name, p => p.Age)
                .ToDictionary(g => g.Key, g => g.Average());
            Console.WriteLine("Содержимое Person Dictionary: " + string.Join(", ", averageAgesByName.Select(x => x.Key + " " + x.Value)));

            var personsWithAgeFrom20To45 = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();
            Console.WriteLine("Имена людей от 20 до 45 в порядке убывания возраста: " + string.Join(" | ", personsWithAgeFrom20To45.Select(x => x.Name + " " + x.Age)));

            Console.Read();
        }
    }
}