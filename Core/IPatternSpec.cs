using Common.Models;

namespace Common
{
    public interface IPatternSpec<T> 
        where T : struct,
        IComparable,
        IComparable<T>,
        IConvertible,
        IEquatable<T>,
        IFormattable
    {
        int GetNumber();
        string GetName();
        string GetDescription();
        void ExecutePattern(Graph<T> input);
    }
}
