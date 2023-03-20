using System;

namespace GraphTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adjacencyMatrix = new[,]
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

            var graph = new Graph(adjacencyMatrix);

            Console.WriteLine("Поиск в ширину:");
            graph.BreadthFirstSearch(VisitVertexAction);

            Console.WriteLine("Поиск в глубину:");
            graph.DepthFirstSearch(VisitVertexAction);

            Console.WriteLine("Поиск в глубину рекурсивный:");
            graph.DepthFirstSearchRecursive(VisitVertexAction);

            Console.Read();
        }

        public static void VisitVertexAction(int currentVertex)
        {
            Console.WriteLine($"Вершина {currentVertex} посещена");
        }

    }
}