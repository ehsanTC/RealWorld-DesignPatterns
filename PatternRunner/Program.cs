using Common;
using Common.Models;
using Observer;

namespace PatternRunner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>(
                vertices: new List<int>() { 15, 17, 5, 4, 8, 9 },
                edges: new List<Tuple<int, int>>()
                {
                    Tuple.Create(15, 17), Tuple.Create(15, 5),
                    Tuple.Create(5, 4),
                    Tuple.Create(4, 8), Tuple.Create(4, 9)
                });

            var patterns = new List<IPatternSpec<int>>
            {
                new ObserverPattern<int>()
            };

            Console.WriteLine("Hello guys, please select the pattern number to starts with:");
            patterns.ForEach(pattern => Console.WriteLine($"{pattern.GetNumber()}) {pattern.GetName()}"));

            try
            {
                var selectedPatternNumber = int.Parse(Console.ReadLine());
                var selectedPattern = patterns.FirstOrDefault(p => p.GetNumber() == selectedPatternNumber);

                if (selectedPattern is null)
                {
                    Console.WriteLine("The selected pattern not exists!");
                    return;
                }

                Console.WriteLine($"You selected the {selectedPattern.GetName()}.\n\n{selectedPattern.GetDescription()}");
                selectedPattern.ExecutePattern(graph);
            }
            catch (Exception)
            {
                Console.WriteLine("The selected number is wrong!");
            }
        }
    }
}