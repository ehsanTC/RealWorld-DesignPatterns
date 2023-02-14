using Common;
using Common.Models;

namespace Observer
{
    public class ObserverPattern<T> : IPatternSpec<T>
        where T : struct,
        IComparable,
        IComparable<T>,
        IConvertible,
        IEquatable<T>,
        IFormattable
    {
        public int GetNumber() => 1;
        public string GetName() => "Observer pattern";
        public string GetDescription() =>
            "The observer pattern is used when you want to send a  " +
            "message from an object to another that a task is done.";

        public void ExecutePattern(Graph<T> inputGraph)
        {
            var observer = new AddMeetNodeObserver<T>();
            var dfs = new DfsWithEvents<T>(inputGraph);
            dfs.AddObserver(observer);
            dfs.Execute(inputGraph.Vertices.First());

            Console.WriteLine("\nThe graph is iterated over and all of is node are met." +
                              $"\nThe result of adding all the nodes value is {(int)observer.AdditionResult}");
        }
    }
}
