
namespace Strategy.MidLevel_Example
{
    /// <summary>
    /// A class to traverse a graph.
    /// 
    /// This implementation is based on the strategy pattern and make the code
    /// more extensible if you want to add new search algorithms in the future.
    ///
    /// This class is the context here.
    /// 
    /// </summary>
    /// <typeparam name="T">Type of nodes</typeparam>
    public class GraphTraverse<T>
    {
        private readonly ISearchStrategy<T> _searchAlgorithm;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="searchAlgorithm">The search method for the graph.</param>
        public GraphTraverse(ISearchStrategy<T> searchAlgorithm)
        {
            _searchAlgorithm = searchAlgorithm;
        }

        /// <summary>
        /// Get all the nodes of a graph.
        /// </summary>
        /// <param name="elementId">The root element</param>
        /// <returns>A set of unique nodes that can be reached from the passed node.</returns>
        public HashSet<T> GetNodes(T elementId)
        {
            return _searchAlgorithm.Execute(elementId);
        }
    }
}