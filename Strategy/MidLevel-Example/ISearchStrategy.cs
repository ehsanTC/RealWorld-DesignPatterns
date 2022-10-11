namespace Strategy.MidLevel_Example
{
    /// <summary>
    /// Defines a search algorithm for a graph.
    /// 
    /// The important note here is that the graph abstraction is not exist here
    /// and the required adjacency list is calculated based on a passed method.
    ///
    /// The advantage of using this approach is enabling the algorithm to parse
    /// any type of graph without having a data structure for it and extra traversing
    /// and consuming memory for building the adjacency list is not needed.
    /// </summary>
    /// <typeparam name="T">Type of the graph nodes</typeparam>
    public interface ISearchStrategy<T>
    {
        HashSet<T> Execute(T id);
    }
}
