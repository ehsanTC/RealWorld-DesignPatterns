using Common;
using Common.Models;
using Strategy.MidLevel_Example;

namespace Strategy
{
    public class StrategyPattern<T> : IPatternSpec<T>
        where T : struct,
        IComparable,
        IComparable<T>,
        IConvertible,
        IEquatable<T>,
        IFormattable

    {
        public int GetNumber() => 2;

        public string GetName() => "Strategy pattern";

        public string GetDescription() =>
            "The strategy pattern is used when you want to make use of an algorithm " +
            "for a long time.";

        public void ExecutePattern(Graph<T> input)
        {
            Console.WriteLine("\nThe DFS algorithm is selected by default.");
            var iterator = new GraphTraverse<T>(new Dfs<T>(input));
            var nodes = iterator.GetNodes(input.Vertices.First());

            Console.WriteLine("The algorithm is executed and below nodes are met:\n"+
                string.Join(", ", nodes));
        }
    }
}
