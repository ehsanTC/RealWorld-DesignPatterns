
using Common.Models;

namespace Strategy.MidLevel_Example
{
    /// <summary>
    /// Another concrete strategy for traversing a graph
    ///
    /// When using this class, I'll use a specific data model for the graph
    /// <see cref="Graph{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of the graph nodes. If you want the algorithm works as
    /// expected you need to override the GetHashCode() and equals() methods for the
    /// T type. (primitive types don't need)</typeparam>
    public class Dfs<T> : ISearchStrategy<T> where T : notnull
    {
        private readonly Graph<T> _graph;

        public Dfs(Graph<T> graph)
        {
            _graph = graph;
        }

        public HashSet<T> Execute(T root)
        {
            var visited = new HashSet<T>();

            if (!_graph.AdjacencyList.ContainsKey(root))
                return visited;

            var stack = new Stack<T>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in _graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
