using System;

namespace GraphTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adjacencyArray = new[,]
            {
                {0, 1, 0, 0, 0, 0, 0, 0, 0},
                {1, 0, 1, 1, 1, 1, 0, 0, 0},
                {0, 1, 0, 0, 0, 0, 1, 0, 0},
                {0, 1, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0, 1, 0, 0, 0},
                {0, 1, 0, 0, 1, 0, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0, 0, 0, 1, 0}
            };

            var graph = new Graph(adjacencyArray);

            Console.WriteLine("Поиск в ширину:");
            graph.BreadthFirstSearch();

            Console.WriteLine("Поиск в глубину:");
            graph.DepthFirstSearch();

            Console.WriteLine("Поиск в глубину рекурсивный:");
            graph.DepthFirstSearchRecursive();

            Console.Read();
        }
    }
}