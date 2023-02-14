
using Common.Models;

namespace Observer
{
    /// <summary>
    /// Depth-first search algorithm
    /// </summary>
    /// <typeparam name="T">Type of the graph nodes. If you want the algorithm works as
    /// expected you need to override the GetHashCode() and equals() methods for the
    /// T type. (primitive types don't need)</typeparam>
    public class DfsWithEvents<T> where T : notnull
    {
        private readonly Graph<T> _graph;
        private readonly ICollection<IMeetNodeObserver<T>> _observers = new List<IMeetNodeObserver<T>>();

        public DfsWithEvents(Graph<T> graph)
        {
            _graph = graph;
        }

        public void AddObserver(IMeetNodeObserver<T> observer) => 
            _observers.Add(observer);

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

                // Inform the observers that a vertex is met
                foreach (var observer in _observers)
                {
                    observer.MeetNode(vertex);
                }

                foreach (var neighbor in _graph.AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }
    }
}
