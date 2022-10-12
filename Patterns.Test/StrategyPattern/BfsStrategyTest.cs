using Strategy.MidLevel_Example;

namespace Patterns.Test.StrategyPattern
{
    public class BfsStrategyTest
    {
        private readonly Dictionary<int, int[]> _adjacencySimulator;

        // The graph
        // ┌────┐      ┌────┐
        // │ 15 │      │ 17 │
        // │    ├─────►│    │
        // └──┬─┘      └────┘
        //    │        ┌────┐       ┌────┐     ┌────┐
        //    │        │ 5  │       │ 4  │     │ 8  │
        //    └───────►│    ├──────►│    ├────►│    │
        //             └────┘       └──┬─┘     └────┘
        //                             │       ┌────┐
        //                             │       │ 9  │
        //                             └──────►│    │
        //                                     └────┘

        public BfsStrategyTest()
        {
            // Although declaring a data structure for the graph is more readable,
            // It is sufficient here to simulate a graph with a dictionary. 
            _adjacencySimulator = new Dictionary<int, int[]>
            {
                // Make the graph by forming the relations between nodes
                { 15, new[] { 17, 5 } },
                { 5,  new[] { 4 } },
                { 4,  new[] {8, 9} }
            };
        }

        [Fact]
        public void BfsShouldMeetAllNodes()
        {
            int root = 15;

            // This function simply returns the adjacncy list of a vertex
            Func<int, ICollection<int>> adjacencyCalculator = (node) =>
                _adjacencySimulator.TryGetValue(node, out int[]? adjacencyList)
                    ? (int[])adjacencyList
                    : new List<int>();

            var bfsSearch = new Bfs<int>(adjacencyCalculator);
            var algorithm = new GraphTraverse<int>(bfsSearch);
            var nodes = algorithm.GetNodes(root);

            Assert.NotNull(nodes);
            Assert.NotEmpty(nodes);

            // Sum of all nodes
            var expected = 15 + (5 + 17) + 4 + (8 + 9);
            var actual = nodes.Sum();

            Assert.Equal(expected, actual);
        }
    }
}
