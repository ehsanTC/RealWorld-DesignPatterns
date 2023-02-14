namespace Observer
{
    internal class AddMeetNodeObserver<T> : IMeetNodeObserver<T>
        where T : struct,
        IComparable,
        IComparable<T>,
        IConvertible,
        IEquatable<T>,
        IFormattable
    {
        public double AdditionResult { get; private set; } = default;
        public void MeetNode(T node)
        {
            AdditionResult += node.ToDouble(null);
        }
    }
}
