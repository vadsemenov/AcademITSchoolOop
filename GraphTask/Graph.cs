using System;
using System.Collections.Generic;

namespace GraphTask
{
    public class Graph
    {
        private readonly int[,] _adjacencyArray;
        private readonly int _size;

        public Graph(int[,] adjacencyArray)
        {
            var rowCount = adjacencyArray.GetLength(0);
            var columnCount = adjacencyArray.GetLength(1);

            if (rowCount != columnCount)
            {
                throw new ArgumentException(
                    "Количество строк в матрице смежности должно быть равно количеству стобцов!",
                    nameof(adjacencyArray));
            }

            _adjacencyArray = adjacencyArray;
            _size = adjacencyArray.GetLength(0);
        }

        public void BreadthFirstSearch()
        {
            var queue = new Queue<int>();

            var visited = new bool[_size];

            var visitedVertexCount = 0;

            var nextIndexInVisitedArray = 0;

            while (visitedVertexCount < _size)
            {
                for (var i = nextIndexInVisitedArray; i < _size; i++)
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                        nextIndexInVisitedArray++;
                        break;
                    }
                }

                while (queue.Count > 0)
                {
                    var currentVertex = queue.Dequeue();

                    if (!visited[currentVertex])
                    {
                        for (var i = 0; i < _size; i++)
                        {
                            var element = _adjacencyArray[currentVertex, i];

                            if (element != 0 && !visited[i])
                            {
                                queue.Enqueue(i);
                            }
                        }

                        Console.WriteLine($"Вершина {currentVertex} посещена");
                        visited[currentVertex] = true;

                        visitedVertexCount++;
                    }
                }
            }
        }

        public void DepthFirstSearch()
        {
            var stack = new Stack<int>();

            var visited = new bool[_size];

            var visitedVertexCount = 0;

            var nextIndexInVisitedArray = 0;

            while (visitedVertexCount < _size)
            {
                for (var i = nextIndexInVisitedArray; i < _size; i++)
                {
                    if (!visited[i])
                    {
                        stack.Push(i);

                        nextIndexInVisitedArray++;

                        break;
                    }
                }

                while (stack.Count > 0)
                {
                    var currentVertex = stack.Pop();

                    if (!visited[currentVertex])
                    {
                        for (var i = _size - 1; i >= 0; i--)
                        {
                            var element = _adjacencyArray[currentVertex, i];

                            if (element != 0 && !visited[i])
                            {
                                stack.Push(i);
                            }
                        }

                        Console.WriteLine($"Вершина {currentVertex} посещена");
                        visited[currentVertex] = true;

                        visitedVertexCount++;
                    }
                }
            }
        }

        public void DepthFirstSearchRecursive()
        {
            var visited = new bool[_size];

            for (var i = 0; i < _size; i++)
            {
                Visit(i, visited);
            }
        }

        private void Visit(int vertexIndex, bool[] visited)
        {
            if (visited[vertexIndex])
            {
                return;
            }

            Console.WriteLine($"Вершина {vertexIndex} посещена");

            visited[vertexIndex] = true;

            for (var i = 0; i < _size; i++)
            {
                var element = _adjacencyArray[vertexIndex, i];

                if (element != 0 && !visited[i])
                {
                    Visit(i, visited);
                }
            }
        }
    }
}