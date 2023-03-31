namespace GraphTask
{
    public class Graph
    {
        private readonly int[,] _adjacencyMatrix;
        private readonly int _size;

        public Graph(int[,] adjacencyMatrix)
        {
            var rowsCount = adjacencyMatrix.GetLength(0);
            var columnsCount = adjacencyMatrix.GetLength(1);

            if (rowsCount != columnsCount)
            {
                throw new ArgumentException(
                    "Количество строк в матрице смежности должно быть равно количеству столбцов \r\n" +
                    $"Сейчас количество строк = {rowsCount}, количество столбцов = {columnsCount}",
                    nameof(adjacencyMatrix));
            }

            _adjacencyMatrix = adjacencyMatrix;
            _size = adjacencyMatrix.GetLength(0);
        }

        public void BreadthFirstSearch(Action<int> action)
        {
            var queue = new Queue<int>();

            var visited = new bool[_size];

            for (var i = 0; i < _size; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                queue.Enqueue(i);

                while (queue.Count > 0)
                {
                    var currentVertex = queue.Dequeue();

                    if (visited[currentVertex])
                    {
                        continue;
                    }

                    action.Invoke(currentVertex);

                    visited[currentVertex] = true;

                    for (var j = 0; j < _size; j++)
                    {
                        if (_adjacencyMatrix[currentVertex, j] != 0)
                        {
                            queue.Enqueue(j);
                        }
                    }
                }
            }
        }

        public void DepthFirstSearch(Action<int> action)
        {
            var stack = new Stack<int>();

            var visited = new bool[_size];

            for (var i = 0; i < _size; i++)
            {
                if (visited[i])
                {
                    continue;
                }

                stack.Push(i);

                while (stack.Count > 0)
                {
                    var currentVertex = stack.Pop();

                    if (visited[currentVertex])
                    {
                        continue;
                    }

                    action.Invoke(currentVertex);

                    visited[currentVertex] = true;

                    for (var j = _size - 1; j >= 0; j--)
                    {
                        if (_adjacencyMatrix[currentVertex, j] != 0)
                        {
                            stack.Push(j);
                        }
                    }
                }
            }
        }

        public void DepthFirstSearchRecursive(Action<int> action)
        {
            var visited = new bool[_size];

            for (var i = 0; i < _size; i++)
            {
                Visit(i, visited, action);
            }
        }

        private void Visit(int vertexIndex, bool[] visited, Action<int> action)
        {
            if (visited[vertexIndex])
            {
                return;
            }

            action.Invoke(vertexIndex);

            visited[vertexIndex] = true;

            for (var i = 0; i < _size; i++)
            {
                if (_adjacencyMatrix[vertexIndex, i] != 0)
                {
                    Visit(i, visited, action);
                }
            }
        }
    }
}