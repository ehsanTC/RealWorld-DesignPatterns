using Strategy.MidLevel_Example;
using Strategy.MidLevel_Example.Models;

namespace Patterns.Test.StrategyPattern
{
    public class DfsStrategyTest
    {
        private readonly Graph<int> _graph; 

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

        public DfsStrategyTest()
        {
            _graph = new Graph<int>(
                vertices: new List<int>() { 15, 17, 5, 4, 8, 9 },
                edges: new List<Tuple<int, int>>()
                {
                    Tuple.Create(15, 17), Tuple.Create(15, 5),
                    Tuple.Create(5, 4),
                    Tuple.Create(4, 8), Tuple.Create(4, 9)
                });
        }

        [Fact]
        public void DfsShouldMeetAllNodes()
        {
            ISearchStrategy<int> dfsSearch = new Dfs<int>(_graph);
            GraphTraverse<int>   algorithmRunner = new(dfsSearch);

            int rootElement = 15;
            var nodes = algorithmRunner.GetNodes(rootElement);

            Assert.True(nodes.Count > 0);

            // Expect to meet all nodes
            var expected = _graph.Vertices.Sum();
            var actual = nodes.Sum();

            Assert.Equal(expected, actual);
        }
    }
}
