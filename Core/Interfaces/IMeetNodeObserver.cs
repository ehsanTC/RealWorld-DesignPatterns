namespace Observer
{
    /// <summary>
    /// Specifies the event or message from sender to receiver 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMeetNodeObserver<in T>
    {
        void MeetNode(T node);
    }
}
