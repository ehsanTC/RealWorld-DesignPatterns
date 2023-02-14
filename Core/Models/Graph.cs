namespace Common.Models
{
    //
    // The graph data structure is copied from the https://www.koderdojo.com/
    // 
    public class Graph<T> where T : notnull
    {
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        public IEnumerable<T> Vertices => AdjacencyList.Keys;
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new ();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Graph<T> other)
            {
                return this.AdjacencyList.Keys.SequenceEqual(other.AdjacencyList.Keys) &&
                       this.AdjacencyList.Keys.All(key => this.AdjacencyList[key].SetEquals(other.AdjacencyList[key]));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return AdjacencyList.Count > 0
                ? AdjacencyList.Keys.Sum( key =>
                    31 * key.GetHashCode() + 
                    AdjacencyList[key].Sum(value => 17 * value.GetHashCode())
                )
                : 0;
        }
    }
}
