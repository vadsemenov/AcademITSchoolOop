using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    Name = "Иван",
                    Age = 13
                },
                new Person()
                {
                    Name = "Сергей",
                    Age = 16
                },
                new Person()
                {
                    Name = "Сергей",
                    Age = 17
                },
                new Person()
                {
                    Name = "Петр",
                    Age = 18
                },
                new Person()
                {
                    Name = "Никита",
                    Age = 20
                },
                new Person()
                {
                    Name = "Василий",
                    Age = 35
                },
                new Person()
                {
                    Name = "Дмитрий",
                    Age = 45
                },
                new Person()
                {
                    Name = "Алексей",
                    Age = 46
                },
                new Person()
                {
                    Name = "Максим",
                    Age = 55
                }
            };

            var uniqueNames = persons.Select(x => x.Name).Distinct().ToArray();
            Console.WriteLine("Список уникальных имен: " + string.Join(", ", uniqueNames));

            var averageAgeNotAdultPerson = persons.Where(x => x.Age < 18).Average(x => x.Age);
            Console.WriteLine("Средний возраст людей младше 18 лет: " + averageAgeNotAdultPerson);

            var personsDictionary = persons.GroupBy(x => x.Name, y => y.Age).ToDictionary(x => (x.Key), y => y.Average());
            Console.WriteLine("Содержимое Person Dictionary: " + string.Join(", ", personsDictionary.Select(x => x.Key + " " + x.Value).ToArray()));

            var personsWithAgeFrom20To45 = persons.Where(x => x.Age >= 20 && x.Age <= 45).OrderByDescending(x => x.Age).ToList();
            Console.WriteLine("Имена людей от 20 до 45 в порядке убывания возраста: " + string.Join(" | ", personsWithAgeFrom20To45.Select(x => x.Name + " " + x.Age).ToArray()));

            Console.Read();
        }
    }
}