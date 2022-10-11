namespace Strategy.MidLevel_Example
{
    /// <summary>
    /// The concrete strategy that implements the breadth-first search
    /// </summary>
    /// <typeparam name="T">Type of the graph nodes. If you want the algorithm works as
    /// expected you need to override the GetHashCode() and equals() methods for the
    /// T type. (primitive types don't need)</typeparam>
    public class Bfs<T> : ISearchStrategy<T>
    {
        /// <summary>
        /// The method to get the adjacency list
        /// </summary>
        private Func<T, ICollection<T>>? _retrieveFunction;

        public Bfs() { }

        public Bfs(Func<T, ICollection<T>> retrieveFunction)
        {
            SetRetrieveFunction(retrieveFunction);
        }

        /// <summary>
        /// Constructs a new bfs searcher with specified retrieve method for the graph vertices.
        /// </summary>
        /// <param name="retrieveFunction">A function to get the adjacency list of nodes.</param>
        public void SetRetrieveFunction(Func<T, ICollection<T>> retrieveFunction)
        {
            _retrieveFunction = retrieveFunction;
        }

        /// <summary>
        /// Execute the bfs algorithm.
        /// </summary>
        /// <param name="id">The root element.</param>
        /// <returns>A set of unique nodes that can be reached from the <para>id</para> node.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public HashSet<T> Execute(T id)
        {
            if (_retrieveFunction is null)
                throw new NullReferenceException(
                    "The function to retrieve the adjacency list for the graph is not set");

            var visited = new HashSet<T>();
            var queue = new Queue<T>();
            queue.Enqueue(id);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                // Time complexity is O(1)
                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                var adjacencyList = _retrieveFunction(vertex);
                foreach (var neighbor in adjacencyList)
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }
    }
}
